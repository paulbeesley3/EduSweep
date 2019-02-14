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
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;
using EduEngine.Reports;
using EduSweep_2.Common;
using EduSweep_2.Reports;
using EdUtils.Helpers;
using EdUtils.Settings;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class TaskReports : Form
    {
        private const string WindowTitleBase = "Report Manager";
        private Logger logger = LogManager.GetCurrentClassLogger();

        private List<ScanReport> reports;

        private TypedObjectListView<ScanReport> typedReportView;

        private SettingsManager settingsManager = SettingsManager.Instance;

        public TaskReports()
        {
            InitializeComponent();
        }

        private void TaskReports_Load(object sender, EventArgs e)
        {
            FormStatus.ReportManagerOpen = true;
            this.Text = WindowTitleBase;

            logger.Trace("Set width to {0}", settingsManager.app.TaskReportsWidth);
            logger.Trace("Set height to {0}", settingsManager.app.TaskReportsHeight);
            this.Size = new Size()
            {
                Width = (int)settingsManager.app.TaskReportsWidth,
                Height = (int)settingsManager.app.TaskReportsHeight
            };

            SetListViewOverlay();

            typedReportView = new TypedObjectListView<ScanReport>(this.listViewReports);

            LoadReportsList();

            if (!string.IsNullOrWhiteSpace(settingsManager.app.TaskReportsListViewState))
            {
                logger.Debug("Restoring saved list view state");
                byte[] stateData =
                    Utils.HexStringToByteArray(settingsManager.app.TaskReportsListViewState);
                listViewReports.RestoreState(stateData);
            }

            logger.Info("Form opened");
        }

        private void LoadReportsList()
        {
            logger.Trace("Loading reports list");
            reports = ReportManager.GetReportList();
            listViewReports.SetObjects(reports);

            webBrowserReport.Navigate("about:blank");
            webBrowserReport.Refresh();
            SetButtonStates(listViewReports.SelectedItems.Count);
            UpdateStatusBarText();
            logger.Debug("Loaded reports list");
        }

        private void SetListViewOverlay()
        {
            var overlay = listViewReports.EmptyListMsgOverlay as TextOverlay;
            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            listViewReports.EmptyListMsg = "No reports available.";
            logger.Trace("Set overlay for list view");
        }

        private void UpdateStatusBarText()
        {
            int reportCount = ReportManager.GetCount();

            toolStripStatusLabelCount.Text = reportCount == 1 ?
                "1 report available" :
                string.Format("{0} reports available", reportCount);
            logger.Trace("Set status bar text");
        }

        private void SetButtonStates(int selectedItemCount)
        {
            if (selectedItemCount > 0)
            {
                logger.Trace("Enabled buttons");
                toolStripButtonSave.Enabled = true;
                toolStripButtonPrint.Enabled = true;
                toolStripButtonPrintPreview.Enabled = true;
                toolStripButtonDelete.Enabled = true;
            }
            else
            {
                logger.Trace("Disabled buttons");
                toolStripButtonSave.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonPrintPreview.Enabled = false;
                toolStripButtonPrint.Enabled = false;
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            TaskDialogResult res;

            using (var td = new TaskDialog())
            {
                TaskDialogStandardButtons button = TaskDialogStandardButtons.None;
                button |= TaskDialogStandardButtons.Yes;
                button |= TaskDialogStandardButtons.No;
                td.StandardButtons = button;
                td.StartupLocation = TaskDialogStartupLocation.CenterOwner;
                td.OwnerWindowHandle = this.Handle;

                td.Icon = TaskDialogStandardIcon.Information;

                td.Caption = "Delete Selected Report?";
                td.InstructionText = "The selected report will be permanently deleted.";
                td.Text = "Do you want to continue?";

                res = td.Show();
            }

            if (res == TaskDialogResult.Yes)
            {
                try
                {
                    logger.Debug("Removing report: {0}", typedReportView.SelectedObject.Name);
                    ReportManager.RemoveReport(typedReportView.SelectedObject);
                }
                catch (Exception deleteException)
                {
                    logger.Error(
                        deleteException,
                        string.Format("Unable to delete '{0}'", typedReportView.SelectedObject.Name));

                    MessageBox.Show(
                        string.Format(
                            "Unable to delete report '{0}'.{1}Detail:{2}",
                            typedReportView.SelectedObject.Name,
                            Environment.NewLine,
                            deleteException.Message),
                        WindowTitleBase,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    LoadReportsList();
                }
            }
        }

        private void toolStripButtonPrint_Click(object sender, EventArgs e)
        {
            logger.Debug("Displaying print dialog");
            webBrowserReport.ShowPrintDialog();
        }

        private void toolStripButtonPrintPreview_Click(object sender, EventArgs e)
        {
            logger.Debug("Displaying print preview dialog");
            webBrowserReport.ShowPrintPreviewDialog();
        }

        private void toolStripButtonBrowser_Click(object sender, EventArgs e)
        {
            ScanReport report = typedReportView.SelectedObject;
            saveFileDialogReport.FileName = string.Format("{0}.html", report.Task.Name);

            DialogResult dr = saveFileDialogReport.ShowDialog(this);
            if (dr == DialogResult.OK)
            {
                try
                {
                    using (var sw = new StreamWriter(saveFileDialogReport.FileName, false))
                    {
                        logger.Debug(
                            "Exporting report {0} to {1}", 
                            report.Name, 
                            saveFileDialogReport.FileName);

                        sw.Write(webBrowserReport.DocumentText);
                        sw.Flush();
                    }
                }
                catch (Exception err)
                {
                    logger.Error(err, "Unable to export report as a web page.");
                    MessageBox.Show(
                        string.Format(
                            "The report could not be saved as a web page.{0}Detail:{1}",
                            Environment.NewLine,
                            err.Message),
                        "Report Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void TaskReports_FormClosing(object sender, FormClosingEventArgs e)
        {
            settingsManager.app.TaskReportsWidth = (uint)Width;
            settingsManager.app.TaskReportsHeight = (uint)Height;

            logger.Debug("Storing list view state");
            byte[] stateData = listViewReports.SaveState();
            settingsManager.app.TaskReportsListViewState =
                Utils.ByteArrayToHexString(stateData);

            FormStatus.ReportManagerOpen = false;
            logger.Info("Form closed");
        }

        private void listViewReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemCount = listViewReports.SelectedItems.Count;

            logger.Trace("Selected listview item changed");

            if (selectedItemCount > 0)
            {
                ScanReport report = typedReportView.SelectedObject;

                this.Text = string.Format("{0}: {1}", WindowTitleBase, report.Name);

                webBrowserReport.Navigate("about:blank");
                webBrowserReport.Document.OpenNew(false);
                webBrowserReport.Document.Write(report.GenerateHTML());
                webBrowserReport.Refresh();
            }

            SetButtonStates(selectedItemCount);
            UpdateStatusBarText();
        }
    }
}
