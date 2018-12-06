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
using System.Reflection;
using System.Windows.Forms;
using EdUtils.Filesystem;
using EdUtils.WindowsPlatform;
using NLog;
using Signature_Studio.Common;
using Signature_Studio.Forms;

namespace Signature_Studio
{
    internal static class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            /* Set up the logging framework */
            Logging.Initialize();
            logger.Info("Application started");
            logger.Info("App Version: {0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            logger.Info("Portable Mode: {0}", AppFolders.PortableMode);
            logger.Info("Base Working Directory: {0}", AppFolders.BaseWorkingFolder);

            logger.Info("System Name: {0}", WMI.QuerySystemName());
            logger.Info("Operating System: {0}", WMI.QueryWindowsVersion());
            logger.Info("OS Service Pack: {0}", WMI.QueryWindowsServicePack());
            logger.Info("System Memory: {0}", WMI.QueryInstalledMemory());
            logger.Info("BIOS ID: {0}", WMI.QueryInstalledBIOS());
            logger.Info("System Role: {0}", WMI.QueryDomainRole());

            if (!AppFolders.WorkingFolderIsWritable())
            {
                logger.Error("Working directory was not writable. Terminating...");
                return;
            }

            logger.Info("Launching main user interface");
            Application.Run(new FormMain());
            logger.Info("Application closed cleanly");
        }
    }
}
