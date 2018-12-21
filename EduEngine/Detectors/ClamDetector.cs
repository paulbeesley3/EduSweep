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
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Signatures;
using nClam;
using NLog;

namespace EduEngine.Detectors
{
    public class ClamDetector : IDetector
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private ClamClient clam;

        public string Name => "ClamAV";

        public DetectionType Type { get; } = DetectionType.CLAMAV;

        public DetectorStatus Status { get; private set; } = DetectorStatus.UNINITIALIZED;

        public ClamDetector(string serverAddress, long serverPort)
        {
            clam = new ClamClient(serverAddress, (int)serverPort);
        }

        public void Initialize(List<SignatureElement> elements)
        {
            logger.Debug("Initializing {0} detector", this.Name);
            try
            {
                Task<bool> pingSuccess = clam.PingAsync();
                pingSuccess.Wait();
                if (pingSuccess.Result == false)
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "ClamAV server not contactable; the detector will not be used.");
                return;
            }

            logger.Info("Successfully connected to ClamAV server");
            this.Status = DetectorStatus.INITIALIZED;
        }

        public (bool detected, Detection detection) Scan(FileItem file)
        {
            ClamScanResult result;

            if (this.Status == DetectorStatus.UNUSED)
            {
                logger.Error("{0} detector in use when it should have been pruned", this.Name);
                return (false, null);
            }

            if (this.Status == DetectorStatus.UNINITIALIZED)
            {
                string message = string.Format(
                    "Trying to use the {0} detector while it is uninitialized",
                    this.Name);

                logger.Error(message);
                throw new Exception(message);
            }

            try
            {
                using (var stream = new FileStream(file.AbsolutePath, FileMode.Open))
                {
                    logger.Trace("Submitting {0} for ClamAV scan", file.AbsolutePath);
                    result = clam.SendAndScanFileAsync(stream).Result;
                    logger.Trace("ClamAV result for {0}: {1}", file.AbsolutePath, result.Result);

                    if (result.Result == ClamScanResults.VirusDetected)
                    {
                        string virusName = result.InfectedFiles.Count > 0 ? result.InfectedFiles[0].VirusName : "Unknown";
                        logger.Error("ClamAV reports {0} is infected with {1}", file.AbsolutePath, virusName);
                        return (true, new Detection(this.Type, this.Name, string.Format("Virus: {0}", virusName)));
                    }
                } 
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Error scanning {0} using ClamAV", file.AbsolutePath);
                return (false, null);
            }

            return (false, null);
        }
    }
}
