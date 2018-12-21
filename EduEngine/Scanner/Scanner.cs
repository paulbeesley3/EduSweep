#region copyright-header
/*
 * This file is part of EduSweep.
 * Copyright 2008 - 2019 Paul Beesley
 *
 * EduSweep is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * EduSweep is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with EduSweep. If not, see <https://www.gnu.org/licenses/>.
 */
#endregion

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EduEngine.Detectors;
using EduEngine.Reports;
using EduEngine.Tasks;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.WindowsPlatform;
using NLog;

namespace EduEngine.Scanner
{
    /// <summary>
    /// Core scanner class implementing higher-level file scanning and
    /// directory traversal along with report generation.
    /// </summary>
    public class Scanner : IDisposable
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        /* Scan task and high-level configuration */
        private ScanTask scanTask;
        private ScannerConfiguration scanConfig;
        private ParallelOptions parallelOptions = new ParallelOptions();

        /* Report that is generated after the scan completes */
        private ScanReport scanReport;

        /* Lists of detectors that are used during the scan and/or post-scan stages */
        private List<IDetector> detectors = new List<IDetector>();
        private List<IDetector> postScanDetectors = new List<IDetector>();

        /* Unordered, thread-safe collection of files detected by one or more detectors */
        private ConcurrentBag<FileItem> detectedFiles = new ConcurrentBag<FileItem>();

        /* Unordered, thread-safe collection of directories awaiting processing */
        private ConcurrentBag<DirectoryItem> pendingDirectories = new ConcurrentBag<DirectoryItem>();

        /* Unordered, thread-safe collection of directories discovered during the current parallel iteration */
        private ConcurrentBag<DirectoryItem> discoveredDirectories = new ConcurrentBag<DirectoryItem>();

        /* Unordered, thread-safe collection of directories that have been scanned */
        private ConcurrentBag<DirectoryItem> scannedDirectories = new ConcurrentBag<DirectoryItem>();

        /* Create DirectoryInfo instances for each subdirectory in the current directory */
        private List<DirectoryItem> GetSubDirectories(DirectoryItem directory)
        {
            DirectoryInfo dirInfo;
            var subdirs = new List<DirectoryItem>();

           logger.Trace("Getting subdirectory list for directory: {0}", directory.Path);

            try
            {
                dirInfo = new DirectoryInfo(directory.Path);
                foreach (DirectoryInfo subDirInfo in dirInfo.GetDirectories())
                {
                    logger.Trace("Discovered subdirectory: {0}", subDirInfo.FullName);
                    subdirs.Add(new DirectoryItem(subDirInfo.FullName));
                }
            }
            catch (Exception ex)
            {
                logger.Warn(
                    ex,
                    "Subdirectory enumeration failed: {0}",
                    directory.Path);
            }

            return subdirs;
        }

        /* Create FileItem instances for each file in the given directory */
        private List<FileItem> GetFiles(DirectoryItem directory)
        {
            DirectoryInfo dirInfo;
            FileInfo[] fileInfoArray;
            var files = new List<FileItem>();

            logger.Trace(
                "Getting list of files within directory: {0}",
                directory.Path);

            try
            {
                dirInfo = new DirectoryInfo(directory.Path);
                fileInfoArray = dirInfo.GetFiles();
            }
            catch (Exception ex)
            {
                logger.Warn(
                    ex,
                    "Content enumeration failed: {0}",
                    directory.Path);
                return files;
            }

            foreach (FileInfo fileInfo in fileInfoArray)
            {
                try
                {
                    logger.Trace("Discovered file: {0}", fileInfo.Name);
                    files.Add(new FileItem(fileInfo));
                }
                catch (Exception ex)
                {
                    logger.Trace(
                        ex,
                        "File info retrieval failed for {0}",
                        fileInfo.FullName);
                }
            }
  
            return files;
        }

        /// <summary>
        /// Create a new Scanner instance in the default, uninitialized state.
        /// </summary>
        /// <param name="task">Contains the directories to scan and other task-specific options</param>
        /// <param name="config">Contains configuration settings specific to the scanner itself</param>
        public Scanner(ScanTask task, ScannerConfiguration config)
        {
            logger.Info("Creating scan engine...");
            logger.Info("Engine v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            
            this.scanTask = task;
            this.scanConfig = config;
            SetScannerStatus(ScanStatus.UNINITIALZED);
        }

        /// <summary>
        /// Prepare the Scanner for use.
        /// Must be called before Scan() otherwise the required
        /// initialization will not have been performed.
        /// </summary>
        public void Initialize()
        {
            logger.Info("Loading task: {0}", scanTask.Name);

            if (scanTask.TargetDirectories.Count == 0)
            {
                logger.Error("Task has zero target directories");
                SetScannerStatus(ScanStatus.FAILED);
                return;
            }

            SetParallelLimits();

            logger.Info("Loading target directories");
            LoadTargetDirectories();

            logger.Info("Loading detector modules");
            LoadDetectors();

            logger.Debug("Pruning detector list");
            PruneDetectorList(ref detectors);

            logger.Debug("Pruning post-scan detector list");
            PruneDetectorList(ref postScanDetectors);

            logger.Info("Engine initialised");
            SetScannerStatus(ScanStatus.INITIALIZED);
        }

        /// <summary>
        /// Returns a thread-safe copy of the collection of directories that
        /// have been scanned so far.
        /// </summary>
        /// <returns></returns>
        public ConcurrentBag<DirectoryItem> GetScannedDirectories()
        {
            logger.Trace("Request made for scanned directory bag");
            return scannedDirectories;
        }

        /// <summary>
        /// Returns a thread-safe copy of the collection of files that
        /// have been detected so far.
        /// </summary>
        /// <returns></returns>
        public ConcurrentBag<FileItem> GetDetectedFiles()
        {
            logger.Trace("Request made for detected file bag");
            return detectedFiles;
        }

        private void SetParallelLimits()
        {
            int physicalCores = WMI.QueryPhysicalProcessorCount();

            switch (scanTask.ParallelLevel)
            {
                case ParallelLevel.FULL:
                default:
                    return;
                case ParallelLevel.REDUCED:
                    logger.Info("Parallelism capped at physical core count");
                    parallelOptions.MaxDegreeOfParallelism = Math.Max(1, physicalCores);
                    break;
                case ParallelLevel.NONE:
                    logger.Info("Operating in single-threaded mode");
                    parallelOptions.MaxDegreeOfParallelism = (int)Math.Max(1, physicalCores / 2.0);
                    break;
            }

            logger.Debug("Maximum degree of parallelism set to {0} ", parallelOptions.MaxDegreeOfParallelism);
        }

        private void SetScannerStatus(ScanStatus newStatus)
        {
            logger.Trace("Scanner status set to {0}", newStatus.ToString());
            scanTask.Status = newStatus;
        }

        private void ScanDirectory(DirectoryItem dir)
        {
            dir.Status = DirectoryItemStatus.INPROGRESS;
            logger.Trace("Beginning scan of directory: {0}", dir.Path);

            while (scanTask.Status == ScanStatus.PAUSED &&
                !parallelOptions.CancellationToken.IsCancellationRequested)
            {
                logger.Trace("Thread is held in pause loop");
                Thread.Sleep(10);
            }

            /* Enqueue subdirectories */
            if (dir.Recursive)
            {
                List<DirectoryItem> subDirectories = GetSubDirectories(dir);
                foreach (var directory in subDirectories)
                {
                    discoveredDirectories.Add(directory);
                }
            }
            else
            {
                logger.Trace("Skipping subdirectories of {0} as it is not marked for recursion", dir.Path);
            }

            foreach (var fileItem in GetFiles(dir))
            {
                logger.Trace("Beginning scan of file: {0}", fileItem.AbsolutePath);
                ScanFile(fileItem, FileScanMode.DEFAULT);
            }

            logger.Trace("Finished scan of directory: {0}", dir.Path);
            scannedDirectories.Add(dir);
            dir.Status = DirectoryItemStatus.COMPLETED;
        }

        private void ScanFile(FileItem file, FileScanMode mode)
        {
            var detections = new List<Detection>();
            List<IDetector> detectorList;

            switch (mode)
            {
                case FileScanMode.DEFAULT:
                    detectorList = detectors;
                    break;
                case FileScanMode.POSTSCAN:
                    detectorList = postScanDetectors;
                    break;
                default:
                    throw new Exception("Invalid detector list");
            }

            foreach (var detector in detectorList)
            {
                logger.Trace("Invoking {0} detector to scan {1}", detector.Name, file.AbsolutePath);
                var (detected, detection) = detector.Scan(file);
                if (detected)
                {
                    logger.Trace("Detection on file: {0}", file.AbsolutePath);
                    detections.Add(detection);
                }
            }

            if (mode == FileScanMode.DEFAULT)
            {
                if (detections.Count > 0)
                {
                    try
                    {
                        logger.Trace("Getting ownership information for file with detections: {0}", file.AbsolutePath);
                        file.Owner = Paths.GetOwner(new FileInfo(file.AbsolutePath));
                    }
                    catch (Exception ex)
                    {
                        logger.Warn(
                            ex,
                            "Couldn't get owner info for detected file {0}",
                            file.AbsolutePath);
                    }

                    file.Detections = detections;
                    detectedFiles.Add(file);
                    logger.Trace("Added {0} to detected files bag", file.AbsolutePath);
                }
            }
            else
            {
                file.Detections = file.Detections.Union(detections).ToList();
            }
        }

        private void ScanDetectedFile(FileItem file)
        {
            ScanFile(file, FileScanMode.POSTSCAN);
        }

        private void Cleanup()
        {
            /* Save changes to the scan task */
            logger.Info("Performing cleanup actions");
            scanTask.LastCompletionTime = DateTime.Now;
            scanTask.LastWriteTime = DateTime.Now;
            scanTask.LastRunOwner = Utils.GetCurrentUserName();
            scanTask.Save(AppFolders.TaskFolder);

            /* Produce the report */
            logger.Info("Storing scan report");
            scanReport = new ScanReport(scanTask, detectedFiles.ToList(), scannedDirectories.Count);
            scanReport.Save(AppFolders.ReportFolder);

            logger.Info("Scan completed");
            SetScannerStatus(ScanStatus.COMPLETED);
        }

        /// <summary>
        /// Load the target directories from the scan task so that they are
        /// ready as the first directories to be examined when the scan
        /// begins.
        /// </summary>
        private void LoadTargetDirectories()
        {
            foreach (var dir in scanTask.TargetDirectories)
            {
                logger.Trace("Adding target directory: {0}", dir.Path);
                pendingDirectories.Add(dir);
            }
        }

        private void LoadDetectors()
        {
            detectors.Add(new ExtensionDetector());
            detectors.Add(new KeywordDetector());
            detectors.Add(new HashDetector());

            if (scanTask.UseClamAV && scanConfig.UseClamAV)
            {
                postScanDetectors.Add(new ClamDetector(
                    scanConfig.ClamAVServerAddress,
                    scanConfig.ClamAVServerPort));
            }

            foreach (IDetector detector in detectors)
            {
                logger.Trace("Initializing detector: {0}", detector.Name);
                detector.Initialize(scanTask.Elements);
            }

            foreach (IDetector detector in postScanDetectors)
            {
                logger.Trace("Initializing post-scan detector: {0}", detector.Name);
                detector.Initialize(scanTask.Elements);
            }
        }

        /// <summary>
        /// Examine the referenced list and remove any detectors that are
        /// unused or failed to initialize properly.
        /// </summary>
        /// <param name="list">Reference to the list of detectors to prune</param>
        private void PruneDetectorList(ref List<IDetector> list)
        {
            foreach (var detector in list)
            {
                if (detector.Status == DetectorStatus.UNINITIALIZED)
                {
                    logger.Trace(
                        "{0} failed initialization and will be pruned.",
                        detector.Name);
                }

                if (detector.Status == DetectorStatus.UNUSED)
                {
                    logger.Trace(
                        "{0} is not required and will be pruned.",
                        detector.Name);
                }
            }

            list = list.Where(x => x.Status == DetectorStatus.INITIALIZED).ToList();
        }

        /// <summary>
        /// Begin the scan process. The caller should be subscribed to the
        /// StatusChanged event in order to be notified of subsequent changes
        /// in the scanner state such as completion or an error.
        /// </summary>
        /// <param name="cancelToken">
        /// Token to be used if the caller wants to interrupt and abort the scan process
        /// </param>
        public void Scan(CancellationToken cancelToken)
        {
            if (scanTask.Status != ScanStatus.INITIALIZED)
            {
                logger.Error(
                    "Attempted to start scan while in an invalid state: ({0})",
                    scanTask.Status.ToString());
                SetScannerStatus(ScanStatus.FAILED);
                return;
            }

            parallelOptions.CancellationToken = cancelToken;
            scanTask.LastStartTime = DateTime.Now;
            logger.Info("Scan running...");
            SetScannerStatus(ScanStatus.RUNNING);

            while (!pendingDirectories.IsEmpty)
            {
                if (cancelToken.IsCancellationRequested)
                {
                    logger.Info("Cancellation request accepted. Terminating...");
                    break;
                }

                try
                {
                    Parallel.ForEach(
                    pendingDirectories,
                    parallelOptions,
                    ScanDirectory);
                }
                catch (OperationCanceledException)
                {
                    logger.Info("Running parallel operation cancelled");
                }

                /* 
                 * Clear the pendingDirectories bag and fill a new instance with the
                 * discovered subdirectories from the previous ScanDirectory calls.
                 */
                logger.Trace("Refilling pending directory queue");
                pendingDirectories = new ConcurrentBag<DirectoryItem>();
                foreach (DirectoryItem directory in discoveredDirectories)
                {
                    pendingDirectories.Add(directory);
                }

                discoveredDirectories = new ConcurrentBag<DirectoryItem>();
            }

            logger.Debug("Directory scan complete");

            if (!cancelToken.IsCancellationRequested)
            {
                logger.Info("Performing post-scan actions");

                try
                {
                    Parallel.ForEach(
                    detectedFiles,
                    parallelOptions,
                    ScanDetectedFile);
                }
                catch (OperationCanceledException)
                {
                    logger.Warn("Running parallel operation cancelled");
                }
            }

            Cleanup();  
        }

        public void Pause()
        {
            switch (scanTask.Status)
            {
                case ScanStatus.PAUSED:
                    logger.Info("Scan resumed");
                    scanTask.Status = ScanStatus.RUNNING;
                    break;
                case ScanStatus.RUNNING:
                    logger.Info("Scan paused");
                    scanTask.Status = ScanStatus.PAUSED;
                    break;
                default:
                    logger.Error(
                    "Scanner is not in a valid state to be paused or resumed ({0})",
                    scanTask.Status.ToString());
                    break;
            }
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                /*
                 * TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                 * TODO: set large fields to null.
                 */

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }

        #endregion
    }
}
