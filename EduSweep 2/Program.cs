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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Config.Net;
using EduSweep_2.Common;
using EduSweep_2.Forms;
using EduSweep_2.Reports;
using EdUtils.Filesystem;
using EdUtils.Settings;
using EdUtils.WindowsPlatform;
using NLog;

namespace EduSweep_2
{
    public static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static SettingsManager settingsManager;

        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* Set up the logging framework */
            Logging.Initialize(EdUtils.Settings.LogLevel.STANDARD);
            logger.Info("Application started");

            /* Load application-level settings */
            try
            {
                settingsManager = SettingsManager.Instance;
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    "Application settings couldn't be loaded from {0}.",
                    AppFolders.AppSettingsPath);

                if (File.Exists(AppFolders.AppSettingsPath))
                {
                    logger.Debug("The application settings file exists.");
                }

                return;
            }

            /* Re-initialize the logger now that the desired log level is known */
            Logging.Initialize(settingsManager.app.LoggingLevel);

            /* Log some machine info */
            logger.Info("App Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            logger.Info("Portable Mode: {0}", AppFolders.PortableMode);
            logger.Info("Base Working Directory: {0}", AppFolders.BaseWorkingFolder);

            logger.Info("System Name: {0}", WMI.QuerySystemName());
            logger.Info("Operating System: {0}", WMI.QueryWindowsVersion());
            logger.Info("OS Service Pack: {0}", WMI.QueryWindowsServicePack());
            logger.Info("System Memory: {0}", WMI.QueryInstalledMemory());
            logger.Info("BIOS ID: {0}", WMI.QueryInstalledBIOS());
            logger.Info("System Role: {0}", WMI.QueryDomainRole());

            /* Make sure there is write access to the working folder */
            if (!AppFolders.WorkingFolderIsWritable())
            {
                logger.Error("Working directory was not writable. Terminating...");
                return;
            }

            /* Ensure that required working folders are present */
            AppFolders.CreateWorkingFolders();

            /* Remove outdated reports */
            if (settingsManager.app.ReportCleanupEnabled)
            {
                ReportManager.PurgeExpiredReports(settingsManager.app.MaxReportAgeDays);
            }

            Quarantine.QuarantineManager.PurgeUntrackedFiles();

            /* Remove outdated files from quarantine */
            if (settingsManager.app.QuarantineCleanupEnabled)
            {
                Quarantine.QuarantineManager.PurgeExpiredFiles(settingsManager.app.MaxQuarantineFileAgeDays);
            }

            logger.Info("Launching main user interface");
            Application.Run(new FormMain());
            logger.Info("Application closed cleanly");
        }
    }
}