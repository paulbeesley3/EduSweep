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
using System.Diagnostics;
using EdUtils.Filesystem;
using NLog;

namespace EduSweep_2.Common
{
    internal static class Inspector
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Launch the File Inspector utility to scan a given file
        /// </summary>
        /// <param name="path">Absolute path to the file to scan</param>
        public static void LaunchFileInspector(string path)
        {
            ProcessStartInfo inspectorProcess;

            if (path.Equals(string.Empty))
            {
                logger.Debug("Starting File Inspector without a target file");
                inspectorProcess = new ProcessStartInfo(AppFolders.FileInspectorPath);
            }
            else
            {
                logger.Debug("Starting File Inspector on file: {0}", path);
                inspectorProcess = new ProcessStartInfo(
                    AppFolders.FileInspectorPath,
                    path);
            }

            try
            {
                Process.Start(inspectorProcess);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to start the File Inspector");
                throw;
            }
        }
    }
}
