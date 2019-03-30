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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using BrightIdeasSoftware;
using EduEngine.Events;
using EduEngine.Scanner;
using EduEngine.Tasks;
using EduSweep_2.Common;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Settings;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;
using NLog.Windows.Forms;

namespace EduSweep_2.Forms
{
    public partial class TaskProgress : Form
    {
        private const string WindowTitleBase = "Scan";

        /* Scan task information */
        private List<DirectoryItem> targetDirectories;
        private ScanTask runningTask;

        /* Scanner status tracking and control */
        private Scanner scanner;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private ScanStatus scanStatus;
        private List<DirectoryItem> scannedDirectories = new List<DirectoryItem>();

        /* Detected items from the scan */
        private List<FileItem> detections = new List<FileItem>();
     
        private TypedObjectListView<FileItem> typedResultsView;

        private bool resultsTimerStopping = false;

        private Logger logger = LogManager.GetCurrentClassLogger();

        private SettingsManager settingsManager = SettingsManager.Instance;

        public TaskProgress(ScanTask task)
        {
            InitializeComponent();

            var scanConfig = new ScannerConfiguration()
            {
                UseClamAV = settingsManager.app.UseClamAV,
                ClamAVServerAddress = settingsManager.app.ClamAVServerAddress,
                ClamAVServerPort = settingsManager.app.ClamAVServerPort
            };

            this.runningTask = task;
            this.targetDirectories = runningTask.TargetDirectories;
            this.scanner = new Scanner(runningTask, scanConfig);

            this.Text = string.Format(
                "{0}: {1}",
                WindowTitleBase,
                runningTask.Name);

            SetListViewStringConverters();

            foreach (var column in listViewResults.AllColumns)
            {
                column.GroupFormatter = delegate (OLVGroup group, GroupingParameters parms)
                {
                    group.Task = "Select Group";
                };
            }
        }

        private void SetListViewStringConverters()
        {
            olvResultsColumnSize.AspectToStringConverter = delegate (object obj)
            {
                return Utils.GetDynamicFileSize((long)obj);
            };

            olvResultsColumnSize.GroupKeyGetter = delegate (object x) {
                var file = (FileItem)x;
                return Utils.GetFileSizeClass(file.Length);
            };

            olvResultsColumnSize.GroupKeyToTitleConverter = delegate (object groupKey)
            {
                var sizeClass = (FileSizeClass)groupKey;

                switch (sizeClass)
                {
                    case FileSizeClass.BYTE:
                        return "Less than 1KB";
                    case FileSizeClass.KBYTE:
                        return "Less than 1MB";
                    case FileSizeClass.MBYTE:
                        return "Less than 1GB";
                    case FileSizeClass.GBYTE:
                        return "Over 1GB";
                    default:
                        return "Unknown size class";
                }
            };
        }

        private void TaskProgress_Load(object sender, EventArgs e)
        {
            typedResultsView = new TypedObjectListView<FileItem>(this.listViewResults);

            logger.Trace("Set width to {0}", settingsManager.app.TaskProgressWidth);
            logger.Trace("Set height to {0}", settingsManager.app.TaskProgressHeight);
            this.Size = new Size()
            {
                Width = (int)settingsManager.app.TaskProgressWidth,
                Height = (int)settingsManager.app.TaskProgressHeight
            };

            listViewLocations.SetObjects(targetDirectories);
            listViewResults.SetObjects(detections);

            SetListViewOverlay();

            RichTextBoxTarget.ReInitializeAllTextboxes(this);

            /* Subscribe to ScanTask status changed event */
            runningTask.StatusChanged += Task_OnStatusChanged;

            StartScan();
        }

        private void StartScan()
        {
            timerLocations.Start();
            timerResults.Start();

            backgroundWorkerInitialize.RunWorkerAsync();
        }

        private void EndScan()
        {
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            toolStripProgressBar.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar.Value = 100;

            timerLocations.Stop();
            resultsTimerStopping = true;
        }

        private void TaskProgress_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (scanStatus == ScanStatus.PAUSED)
            {
                scanner.Pause();
                tokenSource.Cancel();
            }

            if (scanStatus == ScanStatus.RUNNING)
            {
                tokenSource.Cancel();
            }

            /* Unsubscribe from the task's status change event */
            runningTask.StatusChanged -= Task_OnStatusChanged;

            if (WindowState == FormWindowState.Normal)
            {
                settingsManager.app.TaskProgressWidth = (uint)Width;
                settingsManager.app.TaskProgressHeight = (uint)Height;
            }
        }

        private void HandleRemovalAction(IList<FileItem> selectedItems, RemovalAction action)
        {
            const string DialogInstructionDelete = "The {0} selected file(s) will be permanently deleted.";
            const string DialogInstructionQuarantine = "The {0} selected file(s) will be moved into quarantine.";
            const string ErrorMessageDelete = "Unable to delete '{0}.'{1}Detail:{2}";
            const string ErrorMessageQuarantine = "Unable to delete '{0}'.{1}Detail:{2}";

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

                td.InstructionText = action == RemovalAction.DELETE ?
                    string.Format(DialogInstructionDelete, selectedItems.Count) :
                    string.Format(DialogInstructionQuarantine, selectedItems.Count);

                td.Caption = action == RemovalAction.DELETE ?
                    "Delete Selected Files?" :
                    "Quarantine Selected Files?";

                td.Text = "Do you want to continue?";

                res = td.Show();
            }

            if (res == TaskDialogResult.Yes)
            {
                foreach (FileItem file in selectedItems)
                {
                    try
                    {
                        if (action == RemovalAction.QUARANTINE)
                        {
                            Quarantine.QuarantineManager.ImportFile(file);
                        }
                        else
                        {
                            File.Delete(file.AbsolutePath);
                        }

                        detections.Remove(file);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(
                            string.Format(
                                action == RemovalAction.DELETE ? ErrorMessageDelete : ErrorMessageQuarantine,
                                file.AbsolutePath,
                                Environment.NewLine,
                                err.Message),
                            "Task Progress",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                    }
                }

                listViewResults.SetObjects(detections);
                UpdateResultsCount();
                updateResultButtonStatus();
            }
        }

        private void UpdateUIProgress(int percentage)
        {
            toolStripProgressBar.Value = percentage;
            this.Text = string.Format("{0}: {1}%", runningTask.Name, percentage);
        }

        private void SetListViewOverlay()
        {
            var overlay = listViewResults.EmptyListMsgOverlay as TextOverlay;
            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            listViewResults.EmptyListMsg = "No results available. If the scan is running then results will be displayed on completion.";
        }

        private void UpdateResultsCount()
        {
            tabPageResults.Text = string.Format("Scan Results ({0})", detections.Count);
        }

        #region Scanner Event Handlers

        private void Task_OnStatusChanged(object sender, StatusChangedArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Task_OnStatusChanged(sender, e);
                });
                return;
            }

            /*
             * Store a local copy of the scan status as it is used when handling
             * interactions with the UI.
             */
            this.scanStatus = e.Status;

            switch (scanStatus)
            {
                case ScanStatus.UNINITIALZED:
                case ScanStatus.INITIALIZED:
                    buttonPause.Enabled = false;
                    buttonStop.Enabled = false;
                    toolStripStatuslabelStatus.Text = "Scan task starting...";
                    toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                    break;
                case ScanStatus.RUNNING:
                    /* 
                     * If the previous state was PAUSED then the timers will be
                     * stopped and must be restarted.
                     */
                    if (!timerLocations.Enabled)
                    {
                        timerLocations.Start();
                    }

                    if (!timerResults.Enabled)
                    {
                        timerResults.Start();
                    }

                    buttonPause.Text = "Pause";
                    buttonPause.Enabled = true;
                    buttonStop.Enabled = true;
                    toolStripProgressBar.Style = ProgressBarStyle.Marquee;
                    break;
                case ScanStatus.PAUSED:
                    timerLocations.Stop();
                    timerResults.Stop();
                    buttonPause.Text = "Resume";
                    buttonPause.Enabled = true;
                    buttonStop.Enabled = true;
                    toolStripStatuslabelStatus.Text = "Scan task paused";
                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    break;
                case ScanStatus.COMPLETED:
                    /* Unsubscribe from the task's status change event */
                    runningTask.StatusChanged -= Task_OnStatusChanged;
                    EndScan();
                    break;
                case ScanStatus.FAILED:
                    buttonPause.Enabled = false;
                    buttonStop.Enabled = false;
                    toolStripProgressBar.Style = ProgressBarStyle.Continuous;
                    toolStripProgressBar.Value = 0;
                    timerLocations.Stop();
                    timerResults.Stop();
                    /* Unsubscribe from the task's status change event */
                    runningTask.StatusChanged -= Task_OnStatusChanged;
                    toolStripStatuslabelStatus.Text = "Scan task failed";
                    break;
            }
        }

        #endregion

        #region UI Event Handlers

        private void objectListViewResults_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            updateResultButtonStatus();
        }

        private void updateResultButtonStatus()
        {
            int count = listViewResults.CheckedItems.Count;

            /* Testing to see if at least one item is selected */
            if (count > 0)
            {
                buttonResultsDetails.Enabled = true;
                buttonShowFile.Enabled = true;
                buttonResultsDelete.Enabled = true;
                buttonResultsQuarantine.Enabled = true;
            }
            else
            {
                buttonResultsDelete.Enabled = false;
                buttonResultsQuarantine.Enabled = false;
                buttonResultsDetails.Enabled = false;
                buttonShowFile.Enabled = false;
            }

            /* Testing to see if multiple items are selected */
            if (count > 1)
            {
                buttonResultsDetails.Enabled = false;
                buttonShowFile.Enabled = false;
            }
        }

        private void buttonStopTask_Click(object sender, EventArgs e)
        {
            buttonPause.Enabled = false;
            buttonStop.Enabled = false;
            toolStripStatuslabelStatus.Text = "Cancellation requested. Please wait...";

            /* 
             * If the previous state was PAUSED then the timers will be
             * stopped and must be restarted.
             */
            if (!timerLocations.Enabled)
            {
                timerLocations.Start();
            }

            if (!timerResults.Enabled)
            {
                timerResults.Start();
            }

            /* Tell the scanner to stop */
            tokenSource.Cancel();
        }

        private void buttonPauseTask_Click(object sender, EventArgs e)
        {
            /* Tell the scanner to pause (or unpause) */
            scanner.Pause();
        }

        private void buttonResultsQuarantine_Click(object sender, EventArgs e)
        {
            HandleRemovalAction(typedResultsView.CheckedObjects, RemovalAction.QUARANTINE);
        }

        private void buttonShowFile_Click(object sender, EventArgs e)
        {
            FileItem selectedItem = typedResultsView.CheckedObject;

            if (File.Exists(selectedItem.AbsolutePath))
            {
                Process.Start("explorer.exe", string.Format("/select,\"{0}\"", selectedItem.AbsolutePath));
            }
        }

        private void buttonResultsDetails_Click(object sender, EventArgs e)
        {
            try
            {
                Inspector.LaunchFileInspector(typedResultsView.CheckedObject.AbsolutePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Unable to start the File Inspector. You may need to reinstall EduSweep.{0}Detail: {1}",
                        Environment.NewLine,
                        ex.Message),
                    "Task Progress",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void buttonResultsDelete_Click(object sender, EventArgs e)
        {
            HandleRemovalAction(typedResultsView.CheckedObjects, RemovalAction.DELETE);
        }

        #endregion

        private void backgroundWorkerInitialize_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            scanner.Initialize();
        }

        private void backgroundWorkerInitialize_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            backgroundWorkerScan.RunWorkerAsync();
        }

        private void backgroundWorkerScan_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            scanner.Scan(tokenSource.Token);
        }

        private void timerResults_Tick(object sender, EventArgs e)
        {
            detections = scanner.GetDetectedFiles().ToList();
            UpdateResultsCount();

            /*
             * The timer must stop itself to avoid a race condition when the scan
             * completes very quickly. If the scan completes before the timer interval
             * has been reached at least once then the results list will be empty.
             */
            if (resultsTimerStopping)
            {
                timerResults.Stop();
                listViewResults.Enabled = true;
                listViewResults.SetObjects(detections);
                listViewResults.Sort(olvResultsColumnExtension, SortOrder.Ascending);

                toolStripStatuslabelStatus.Text = "Scan task complete";
            }
        }

        private void timerLocations_Tick(object sender, EventArgs e)
        {
            scannedDirectories = scanner.GetScannedDirectories().ToList();

            toolStripStatuslabelStatus.Text = string.Format("Scanning... ({0} directories processed)", scannedDirectories.Count);
        }

        private void listViewResults_HeaderCheckBoxChanging(object sender, HeaderCheckBoxChangingEventArgs e)
        {
            listViewResults.ItemChecked -= this.objectListViewResults_ItemChecked;

            if (e.NewCheckState == CheckState.Checked)
            {
                listViewResults.CheckAll();
            }
            else if (e.NewCheckState == CheckState.Unchecked)
            {
                listViewResults.UncheckAll();
            }

            listViewResults.ItemChecked += this.objectListViewResults_ItemChecked;
            updateResultButtonStatus();
        }

        private void toolStripMenuItemSelect_Click(object sender, EventArgs e)
        {
            listViewResults.CheckHeaderCheckBox(olvResultsColumnName);
        }

        private void toolStripMenuItemClearSelection_Click(object sender, EventArgs e)
        {
            listViewResults.UncheckHeaderCheckBox(olvResultsColumnName);
        }

        private void listViewResults_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model == null)
            {
                /* Clicked on background */
                return;
            }

            e.MenuStrip = contextMenuStripResults;
        }

        private void listViewResults_GroupTaskClicked(object sender, GroupTaskClickedEventArgs e)
        {
            listViewResults.ItemChecked -= this.objectListViewResults_ItemChecked;

            foreach (var groupItem in e.Group.Items)
            {
                groupItem.Checked = true;
            }

            listViewResults.ItemChecked += this.objectListViewResults_ItemChecked;
            updateResultButtonStatus();
        }
    }
}