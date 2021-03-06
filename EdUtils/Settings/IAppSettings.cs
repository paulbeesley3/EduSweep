﻿#region copyright-header
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

using Config.Net;

namespace EdUtils.Settings
{
    public interface IAppSettings
    {
        #region Logging

        /// <summary>
        /// Amount of detail to capture in both app and scan logs.
        /// </summary>
        [Option(DefaultValue = LogLevel.STANDARD)]
        LogLevel LoggingLevel { get; set; }

        #endregion

        #region Reports

        /// <summary>
        /// Enables and disables automatic deletion after reports reach a certain age.
        /// </summary>
        [Option(DefaultValue = false)]
        bool ReportCleanupEnabled { get; set; }

        /// <summary>
        /// Maximum time, in days, before a report is deleted.
        /// </summary>
        [Option(DefaultValue = (int)30)]
        int MaxReportAgeDays { get; set; }

        #endregion

        #region Quarantine

        /// <summary>
        /// Enables and disables automatic deletion after quarantine items reach a certain age.
        /// </summary>
        [Option(DefaultValue = false)]
        bool QuarantineCleanupEnabled { get; set; }

        /// <summary>
        /// Maximum time, in days, before a file in quarantine is deleted.
        /// </summary>
        [Option(DefaultValue = (int)30)]
        int MaxQuarantineFileAgeDays { get; set; }

        #endregion

        #region Antivirus

        /// <summary>
        /// Enables and disables ClamAV integration for the whole application.
        /// </summary>
        [Option(DefaultValue = false)]
        bool UseClamAV { get; set; }

        /// <summary>
        /// The IP address or server name of the clamd host.
        /// </summary>
        [Option(DefaultValue = "localhost")]
        string ClamAVServerAddress { get; set; }

        /// <summary>
        /// The port on which clamd is listening.
        /// </summary>
        [Option(DefaultValue = (long)3310)]
        long ClamAVServerPort { get; set; }

        #endregion

        #region Links

        /// <summary>
        /// Link to the project homepage
        /// </summary>
        [Option(DefaultValue = "https://github.com/paulbeesley3/EduSweep")]
        string ProjectHomeLink { get; set; }

        /// <summary>
        /// Link to the project documentation
        /// </summary>
        [Option(DefaultValue = "https://edusweep.readthedocs.io/")]
        string ProjectDocsLink { get; set; }

        /// <summary>
        /// Link to the project issue tracker
        /// </summary>
        [Option(DefaultValue = "https://github.com/paulbeesley3/EduSweep/issues")]
        string ProjectIssueLink { get; set; }

        /// <summary>
        /// Link to the project releases page
        /// </summary>
        [Option(DefaultValue = "https://github.com/paulbeesley3/EduSweep/releases")]
        string ProjectReleasesLink { get; set; }

        /// <summary>
        /// Link to the donation page
        /// </summary>
        [Option(DefaultValue = "https://paypal.me/paulbeesley3")]
        string ProjectDonationLink { get; set; }

        #endregion

        #region Forms

        /// <summary>
        /// Last-used width of the Report Manager form
        /// </summary>
        [Option(DefaultValue = 700U)]
        uint TaskReportsWidth { get; set; }

        /// <summary>
        /// Last-used height of the Report Manager form
        /// </summary>
        [Option(DefaultValue = 660U)]
        uint TaskReportsHeight { get; set; }

        /// <summary>
        /// Last-used width of the FormMain form
        /// </summary>
        [Option(DefaultValue = 720U)]
        uint FormMainWidth { get; set; }

        /// <summary>
        /// Last-used height of the FormMain form
        /// </summary>
        [Option(DefaultValue = 340U)]
        uint FormMainHeight { get; set; }

        /// <summary>
        /// Last-used width of the Quarantine Manager form
        /// </summary>
        [Option(DefaultValue = 840U)]
        uint QuarantineManagerWidth { get; set; }

        /// <summary>
        /// Last-used height of the Quarantine Manager form
        /// </summary>
        [Option(DefaultValue = 400U)]
        uint QuarantineManagerHeight { get; set; }

        /// <summary>
        /// Last-used width of the Task Progress form
        /// </summary>
        [Option(DefaultValue = 725U)]
        uint TaskProgressWidth { get; set; }

        /// <summary>
        /// Last-used height of the Task Progress form
        /// </summary>
        [Option(DefaultValue = 470U)]
        uint TaskProgressHeight { get; set; }

        /// <summary>
        /// State data for tasks list view on FormMain, encoded as a
        /// hexadecimal string.
        /// </summary>
        [Option(DefaultValue = "")]
        string FormMainListViewState { get; set; }

        /// <summary>
        /// State data for reports list view in TaskReports, encoded as a
        /// hexadecimal string.
        /// </summary>
        [Option(DefaultValue = "")]
        string TaskReportsListViewState { get; set; }

        /// <summary>
        /// State data for files list view in QuarantineManager, encoded
        /// as a hexadecimal string.
        /// </summary>
        [Option(DefaultValue = "")]
        string QuarantineManagerListViewState { get; set; }

        #endregion
    }
}
