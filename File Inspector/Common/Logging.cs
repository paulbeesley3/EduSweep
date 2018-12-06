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

using System.IO;
using EdUtils.Filesystem;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace File_Inspector.Common
{
    public static class Logging
    {
        /* NLog configuration */
        private static readonly FileTarget logfileApp = new FileTarget("app")
        {
            FileName = Path.Combine(AppFolders.LogFolder, "inspector_app.txt"),
            FileNameKind = FilePathKind.Absolute,
            DeleteOldFileOnStartup = true
        };

        private static LoggingConfiguration config = new LoggingConfiguration();

        public static void Initialize()
        {
            /* Log rule that directs all application output to the application log file */
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfileApp);

            LogManager.Configuration = config;
        }
    }
}
