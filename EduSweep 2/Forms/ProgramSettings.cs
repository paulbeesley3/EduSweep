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
using System.Threading;
using System.Windows.Forms;
using Config.Net;
using EduSweep_2.Common;
using EduSweep_2.Reports;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Settings;
using nClam;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class ProgramSettings : Form
    {
        private ClamClient clam;
        private CancellationTokenSource clamServerTestCancelToken = new CancellationTokenSource();
        private Logger logger = LogManager.GetCurrentClassLogger();
        private static IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

        public ProgramSettings()
        {
            InitializeComponent();
        }

        private void ProgramSettings_Load(object sender, EventArgs e)
        {
            logger.Info("Form opened");
            FormStatus.ProgramSettingsOpen = true;
            UpdateSizeFields();

            comboBoxLanguage.SelectedIndex = 0;

            /* Set loaded values for logging */
            comboBoxLogLevel.SelectedIndex = (int)appSettings.LoggingLevel;

            /* Set loaded values for quarantine */
            checkBoxQuarantineCleanup.Checked = appSettings.QuarantineCleanupEnabled;
            quarantineAgeLimit.Value = appSettings.MaxQuarantineFileAgeDays;

            /* Set loaded values for reports */
            checkBoxReportCleanup.Checked = appSettings.ReportCleanupEnabled;
            reportAgeLimit.Value = appSettings.MaxReportAgeDays;

            /* Set loaded values for antivirus */
            checkBoxEnableClamAV.Checked = appSettings.UseClamAV;
            textBoxServer.Text = appSettings.ClamAVServerAddress;
            numericUpDownServerPort.Value = appSettings.ClamAVServerPort;

            logger.Trace("Finished loading settings");
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            appSettings.LoggingLevel = (EdUtils.Settings.LogLevel)comboBoxLogLevel.SelectedIndex;

            appSettings.QuarantineCleanupEnabled = checkBoxQuarantineCleanup.Checked;
            appSettings.MaxQuarantineFileAgeDays = (int)quarantineAgeLimit.Value;

            appSettings.ReportCleanupEnabled = checkBoxReportCleanup.Checked;
            appSettings.MaxReportAgeDays = (int)reportAgeLimit.Value;

            appSettings.UseClamAV = checkBoxEnableClamAV.Checked;
            appSettings.ClamAVServerAddress = textBoxServer.Text;
            appSettings.ClamAVServerPort = (long)numericUpDownServerPort.Value;

            logger.Info("Saved settings");
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            logger.Info("Cancelled. Modified settings will not be saved.");
            Close();
        }

        private void backgroundWorkerPurge_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            DirectoryInfo dir;
            double bytesToDelete = 0;
            double bytesDeleted = 0;

            if ((PurgeMode)e.Argument == PurgeMode.QUARANTINE)
            {
                // Remove all files from quarantine
                logger.Info("Purging quarantine folder");
                dir = new DirectoryInfo(AppFolders.QuarantineFolder);
            }
            else
            {
                // Remove all files from the reports folder
                logger.Info("Purging reports folder");
                dir = new DirectoryInfo(AppFolders.ReportFolder);
            }

            foreach (FileInfo fi in dir.GetFiles())
            {
                bytesToDelete += fi.Length;
            }

            logger.Trace("{0} bytes pending deletion", bytesToDelete);

            foreach (FileInfo fi in dir.GetFiles())
            {
                long fileLength = fi.Length;
                try
                {
                    logger.Trace("Deleting file {0}", fi.FullName);
                    fi.Delete();
                    bytesDeleted += fileLength;
                    backgroundWorkerPurge.ReportProgress(
                        Utils.CalculateProgressPercentage(bytesDeleted, bytesToDelete),
                        e.Argument);
                }
                catch (Exception)
                {
                    bytesToDelete -= fileLength;
                    backgroundWorkerPurge.ReportProgress(
                        Utils.CalculateProgressPercentage(bytesDeleted, bytesToDelete),
                        e.Argument);
                    throw;
                }
            }

            e.Result = e.Argument;
        }

        private void backgroundWorkerPurge_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            if ((PurgeMode)e.UserState == PurgeMode.QUARANTINE)
            {
                progressBarQuarantinePurge.Value = e.ProgressPercentage;
            }
            else
            {
                progressBarReportsPurge.Value = e.ProgressPercentage;
            }
        }

        private void backgroundWorkerPurge_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if ((PurgeMode)e.Result == PurgeMode.QUARANTINE)
            {
                progressBarQuarantinePurge.Value = 100;
            }
            else
            {
                progressBarReportsPurge.Value = 100;
            }

            UpdateSizeFields();
            logger.Info("Finished purge operation");
        }

        private void UpdateSizeFields()
        {
            int quarantineFileCount = Quarantine.QuarantineManager.GetCount();
            long quarantineSize = Quarantine.QuarantineManager.GetTotalSize();

            int reportCount = ReportManager.GetCount();
            long reportSize = ReportManager.GetTotalSize();

            labelQuarantineCount.Text = quarantineFileCount == 1 ? "1 item in quarantine" : string.Format("{0} items in quarantine", quarantineFileCount);
            labelQuarantineSize.Text = string.Format("{0} used for quarantine storage", Utils.GetDynamicFileSize(quarantineSize));

            labelReportCount.Text = reportCount == 1 ? "1 report in storage" : string.Format("{0} reports in storage", reportCount);
            labelReportSize.Text = string.Format("{0} used for report storage", Utils.GetDynamicFileSize(reportSize));

            logger.Debug("Updated sizes for quarantine and report folders");
        }

        private void buttonPurgeReports_Click(object sender, EventArgs e)
        {
            progressBarReportsPurge.Value = 0;
            backgroundWorkerPurge.RunWorkerAsync(PurgeMode.REPORTS);
        }

        private void buttonPurgeQuarantine_Click(object sender, EventArgs e)
        {
            progressBarQuarantinePurge.Value = 0;
            backgroundWorkerPurge.RunWorkerAsync(PurgeMode.QUARANTINE);
        }

        private async void buttonServerTest_Click(object sender, EventArgs e)
        {
            string version = string.Empty;

            clam = new ClamClient(textBoxServer.Text, (int)numericUpDownServerPort.Value);

            try
            {
                logger.Info("Testing ClamAV server connection");
                version = await clam.GetVersionAsync(clamServerTestCancelToken.Token);
            }
            catch (Exception ex)
            {
                logger.Warn(
                    ex,
                    "ClamAV server connection test failed using server {0}:{1}",
                    textBoxServer.Text,
                    (int)numericUpDownServerPort.Value);

                textBoxServerPing.Text = "Connection Failed";
                return;
            }

            logger.Info("ClamAV server response: {0}", version);
            textBoxServerPing.Text = version;
        }

        private void ProgramSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Info("Form closed");
            FormStatus.ProgramSettingsOpen = false;
        }
    }
}