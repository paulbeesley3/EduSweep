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
using NLog.Targets.Wrappers;
using NLog.Windows.Forms;

namespace EduSweep_2.Common
{
    public static class Logging
    {
        /* NLog configuration */
        private static readonly FileTarget logfileApp = new FileTarget("app")
        {
            FileName = Path.Combine(AppFolders.LogFolder, "app.log"),
            FileNameKind = FilePathKind.Absolute,
            DeleteOldFileOnStartup = true,
            Layout = "${level:upperCase=true}|${logger}|${threadid}|${message}"
        };

        private static readonly FileTarget logfileScan = new FileTarget("scan")
        {
            FileName = Path.Combine(AppFolders.LogFolder, "scans", "${shortdate}.log"),
            FileNameKind = FilePathKind.Absolute,
            Layout = "${level:upperCase=true}|${logger}|${threadid}|${message}"
        };

        private static readonly RichTextBoxTarget logFormScan = new RichTextBoxTarget()
        {
            Name = "scan_form",
            AllowAccessoryFormCreation = false,
            AutoScroll = true,
            ControlName = "richTextBoxLog",
            FormName = "TaskProgress",
            UseDefaultRowColoringRules = true,
            Layout = "${level:uppercase=true} | ${message}"
        };

        public static void Initialize(EdUtils.Settings.LogLevel minLevel)
        {
            var config = new LoggingConfiguration();

            var fileScanWrapper = new BufferingTargetWrapper()
            {
                FlushTimeout = 1000,
                OverflowAction = BufferingTargetWrapperOverflowAction.Flush,
                WrappedTarget = logfileScan,
                Name = "scan_file_buffer"
            };

            var formScanWrapper = new BufferingTargetWrapper()
            {
                FlushTimeout = 500,
                OverflowAction = BufferingTargetWrapperOverflowAction.Flush,
                WrappedTarget = logFormScan,
                Name = "scan_form_buffer"
            };

            /* Lowest level of event that will be logged to the scan or application log files */
            LogLevel baseLevel;

            /* Lowest level of event that will be logged to the scan window textbox */
            LogLevel formBaseLevel;

            string enhancedLayout = "${level:upperCase=true}|${logger}|${threadid}|${message}|${exception:format=toString}";

            switch (minLevel)
            {
                case EdUtils.Settings.LogLevel.MINIMAL:
                    baseLevel = LogLevel.Warn;
                    formBaseLevel = LogLevel.Warn;
                    break;
                case EdUtils.Settings.LogLevel.STANDARD:
                    baseLevel = LogLevel.Info;
                    formBaseLevel = LogLevel.Info;
                    break;
                case EdUtils.Settings.LogLevel.ENHANCED:
                    baseLevel = LogLevel.Debug;
                    formBaseLevel = LogLevel.Info;
                    logfileApp.Layout = enhancedLayout;
                    logfileScan.Layout = enhancedLayout;
                    break;
                default:
                    baseLevel = LogLevel.Info;
                    formBaseLevel = LogLevel.Info;
                    break;
            }

            config.AddRule(formBaseLevel, LogLevel.Fatal, formScanWrapper, "EduEngine.*");
            config.AddRule(baseLevel, LogLevel.Fatal, fileScanWrapper, "EduEngine.*", true);

            /* Log rule that directs all other application output to the application log file */
            config.AddRule(baseLevel, LogLevel.Fatal, logfileApp);

            LogManager.Configuration = config;
        }
    }
}
