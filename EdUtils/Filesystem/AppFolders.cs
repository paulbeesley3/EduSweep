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
using NLog;

namespace EdUtils.Filesystem
{
    /* 
     * Abstraction for the folders where "working files" are stored. This includes application settings, quarantine items, scan tasks, etc.
     * The BaseWorkingFolder is the parent of all other working folders and will be either the user's AppData\Roaming\EduSweep folder or,
     * if portable mode is enabled, the directory from which the main executable is running.
     */
    public class AppFolders
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static bool PortableMode
        {
            get
            {
                logger.Trace("Property read on PortableMode");
                if (File.Exists(Path.Combine(ProgramFolder, "PORTABLE")))
                {
                    return true;
                }

                return false;
            }
        }

        public static string ProgramFolder
        {
            get
            {
                logger.Trace("Property read on ProgramFolder");
                return AppDomain.CurrentDomain.BaseDirectory;
            }
        }

        public static string BaseWorkingFolder
        {
            get
            {
                logger.Trace("Property read on BaseWorkingFolder");

                if (PortableMode)
                {
                    return Path.Combine(ProgramFolder, "AppData");
                }

                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EduSweep");
            }
        }

        public static string SettingsFolder
        {
            get
            {
                logger.Trace("Property read on SettingsFolder");
                return Path.Combine(BaseWorkingFolder, "Settings");
            }
        }

        public static string QuarantineFolder
        {
            get
            {
                logger.Trace("Property read on QuarantineFolder");
                return Path.Combine(BaseWorkingFolder, "Quarantine");
            }
        }

        public static string ReportFolder
        {
            get
            {
                logger.Trace("Property read on ReportFolder");
                return Path.Combine(BaseWorkingFolder, "Reports");
            }
        }

        public static string TaskFolder
        {
            get
            {
                logger.Trace("Property read on TaskFolder");
                return Path.Combine(BaseWorkingFolder, "Tasks");
            }
        }

        public static string SignatureFolder
        {
            get
            {
                logger.Trace("Property read on SignatureFolder");
                return Path.Combine(ProgramFolder, "Signatures");
            }
        }

        public static string CustomSignatureFolder
        {
            get
            {
                logger.Trace("Property read on CustomSignatureFolder");
                return Path.Combine(BaseWorkingFolder, "Custom Signatures");
            }
        }

        public static List<DirectoryInfo> SignatureFolderList
        {
            get
            {
                logger.Trace("Property read on SignatureFolderList");
                var list = new List<DirectoryInfo>
                {
                    new DirectoryInfo(SignatureFolder),
                    new DirectoryInfo(CustomSignatureFolder)
                };

                return list;
            }
        }

        public static string LogFolder
        {
            get
            {
                logger.Trace("Property read on LogFolder");
                return Path.Combine(BaseWorkingFolder, "Logs");
            }
        }

        public static string FileInspectorPath
        {
            get
            {
                logger.Trace("Property read on FileInspectorPath");
                return Path.Combine(ProgramFolder, "finspector.exe");
            }
        }

        public static string SigStudioPath
        {
            get
            {
                logger.Trace("Property read on SigStudioPath");
                return Path.Combine(ProgramFolder, "sigstudio.exe");
            }
        }

        public static string AppSettingsPath
        {
            get
            {
                logger.Trace("Property read on AppSettingsPath");
                return Path.Combine(SettingsFolder, "app.json");
            }
        }

        public static bool WorkingFolderIsWritable()
        {
            logger.Debug("Testing writability of working folder");
            try
            {
                using (File.Create(Path.Combine(BaseWorkingFolder, "writable.tmp")))
                {
                    /* Just creating an empty file to see if an exception is raised */
                    logger.Trace("Working folder temporary file created");
                }

                File.Delete(Path.Combine(BaseWorkingFolder, "writable.tmp"));
                logger.Trace("Working folder temporary file deleted");
            }
            catch (Exception e)
            {
                logger.Error(
                    e,
                    string.Format("Working folder is not writable ({0})", BaseWorkingFolder));

                return false;
            }

            logger.Info("Working folder appears writable");
            return true;
        }

        public static bool FileInspectorIsInstalled()
        {
            return File.Exists(FileInspectorPath);
        }

        public static bool SigStudioIsInstalled()
        {
            return File.Exists(SigStudioPath);
        }

        public static void CreateWorkingFolders()
        {
            try
            {
                logger.Trace("Creating task folder");
                Directory.CreateDirectory(TaskFolder);
                logger.Trace("Creating custom signature folder");
                Directory.CreateDirectory(CustomSignatureFolder);
                logger.Trace("Creating quarantine folder");
                Directory.CreateDirectory(QuarantineFolder);
                logger.Trace("Creating report folder");
                Directory.CreateDirectory(ReportFolder);
                logger.Trace("Creating log folder");
                Directory.CreateDirectory(LogFolder);
                logger.Trace("Creating settings folder");
                Directory.CreateDirectory(SettingsFolder);
            }
            catch (Exception err)
            {
                logger.Error(err, "Failed to create a required working folder in base folder {0}", BaseWorkingFolder);
                throw;
            }
        }
    }
}
