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
using System.Linq;
using Config.Net;
using EduEngine.Reports;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Settings;
using EdUtils.Types;
using Newtonsoft.Json;
using NLog;

namespace EduSweep_2.Reports
{
    /// <summary>
    /// Provides functions used to manage scan reports.
    /// </summary>
    public static class ReportManager
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

        /// <summary>
        /// Get the number of stored reports.
        /// </summary>
        public static int GetCount()
        {
            return GetReportList().Count;
        }

        /// <summary>
        /// Get the total disk space used by the stored reports.
        /// </summary>
        public static long GetTotalSize()
        {
            long sizeInBytes = 0;

            var di = new DirectoryInfo(AppFolders.ReportFolder);
            foreach (FileInfo file in di.GetFiles("*.json", SearchOption.TopDirectoryOnly))
            {
                sizeInBytes += file.Length;
            }

            return sizeInBytes;
        }

        /// <summary>
        /// Get a list of ScanReport instances, each representing a report.
        /// </summary>
        public static List<ScanReport> GetReportList()
        {
            var repList = new List<ScanReport>();

            var di = new DirectoryInfo(AppFolders.ReportFolder);
            foreach (FileInfo file in di.GetFiles("*.json", SearchOption.TopDirectoryOnly))
            {
                repList.Add(LoadReport(file));
            }

            return repList;
        }

        /// <summary>
        /// Get a single ScanReport.
        /// </summary>
        /// <param name="guid">Unique identifer of the report.</param>
        /// <returns>ScanReport instance corresponding to the GUID.</returns>
        public static ScanReport GetReport(Guid guid)
        {
            List<ScanReport> reports = GetReportList();
            foreach (ScanReport report in reports)
            {
                if (report.Guid.Equals(guid))
                {
                    return report;
                }
            }

            throw new FileNotFoundException("Missing report");
        }

        /// <summary>
        /// Delete a report file.
        /// </summary>
        /// <param name="file"></param>
        public static void RemoveReport(ScanReport report)
        {
            try
            {
                File.Delete(Path.Combine(AppFolders.ReportFolder, string.Format("{0}.json", report.Guid)));
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Failed to delete report file: {0}", report.Guid);
                throw;
            }
        }

        /// <summary>
        /// Remove all reports older than the threshold.
        /// </summary>
        public static void PurgeExpiredReports(int ageThresholdDays)
        {
            var expiredReports = from report in GetReportList()
                                 where report.Age.Ticks > (ageThresholdDays * TimeSpan.TicksPerDay)
                                 select report;

            foreach (var expiredReport in expiredReports)
            {
                RemoveReport(expiredReport);
            }
        }

        /// <summary>
        /// Create a ScanReport instance by deserializing a JSON representation on disk.
        /// </summary>
        /// <param name="file">FileInfo instance representing the serialized ScanReport on disk.</param>
        /// <returns>A deserialized ScanReport instance.</returns>
        private static ScanReport LoadReport(FileInfo file)
        {
            string json;

            using (var fileReader = new StreamReader(file.FullName, true))
            {
                json = fileReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<ScanReport>(json, SerializerSettings.Settings);
        }
    }
}
