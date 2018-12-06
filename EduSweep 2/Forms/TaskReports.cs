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
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class TaskReports : Form
    {
        private const string WindowTitleBase = "Report Manager";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private List<ScanReport> reports;

        private TypedObjectListView<ScanReport> typedReportView;

        public TaskReports()
        {
            InitializeComponent();
        }

        private void TaskReports_Load(object sender, EventArgs e)
        {
            FormStatus.ReportManagerOpen = true;
            this.Text = WindowTitleBase;

            SetListViewOverlay();

            typedReportView = new TypedObjectListView<ScanReport>(this.listViewReports);

            LoadReportsList();
        }

        private void LoadReportsList()
        {
            reports = ReportManager.GetReportList();
            listViewReports.SetObjects(reports);

            webBrowserReport.Navigate("about:blank");
            webBrowserReport.Refresh();
            SetButtonStates(listViewReports.SelectedItems.Count);
            UpdateStatusBarText();
        }

        private void SetListViewOverlay()
        {
            var overlay = listViewReports.EmptyListMsgOverlay as TextOverlay;
            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            listViewReports.EmptyListMsg = "No reports available.";
        }

        private void UpdateStatusBarText()
        {
            int reportCount = ReportManager.GetCount();

            toolStripStatusLabelCount.Text = reportCount == 1 ?
                "1 report available" :
                string.Format("{0} reports available", reportCount);
        }

        private void SetButtonStates(int selectedItemCount)
        {
            if (selectedItemCount > 0)
            {
                toolStripButtonSave.Enabled = true;
                toolStripButtonPrint.Enabled = true;
                toolStripButtonPrintPreview.Enabled = true;
                toolStripButtonDelete.Enabled = true;
            }
            else
            {
                toolStripButtonSave.Enabled = false;
                toolStripButtonDelete.Enabled = false;
                toolStripButtonPrintPreview.Enabled = false;
                toolStripButtonPrint.Enabled = false;
            }
        }

        private void toolStripButtonDelete_Click_1(object sender, EventArgs e)
        {
            var td = new TaskDialog();

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

            TaskDialogResult res = td.Show();
            if (res == TaskDialogResult.Yes)
            {
                try
                {
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
            webBrowserReport.ShowPrintDialog();
        }

        private void toolStripButtonPrintPreview_Click(object sender, EventArgs e)
        {
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
            FormStatus.ReportManagerOpen = false;
        }

        private void listViewReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemCount = listViewReports.SelectedItems.Count;

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
