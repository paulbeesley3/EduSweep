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
using Config.Net;
using EduEngine.Scanner;
using EduSweep_2.Common;
using EduSweep_2.Tasks;
using EdUtils.Filesystem;
using EdUtils.Settings;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog.Windows.Forms;

namespace EduSweep_2.Forms
{
    public partial class TaskProgress : Form
    {
        private const string WindowTitleBase = "Scan";

        /* Scan task information */
        private List<DirectoryItem> targetDirectories;
        private CompositeScanTask compositeTask;

        /* Scanner status tracking and control */
        private Scanner scanner;
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private ScanStatus scanStatus;
        private List<DirectoryItem> scannedDirectories = new List<DirectoryItem>();

        /* Log entries and detected items from the scan */
        private List<TaskLogEntry> taskLogEntries = new List<TaskLogEntry>();
        private List<FileItem> detections = new List<FileItem>();

        /* Published events */
        public event EventHandler<StatusChangedArgs> StatusChanged;
     
        private TypedObjectListView<DirectoryItem> typedLocationView;
        private TypedObjectListView<FileItem> typedResultsView;

        private bool resultsTimerStopping = false;

        private static IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

        public TaskProgress(CompositeScanTask task)
        {
            InitializeComponent();

            var scanConfig = new ScannerConfiguration()
            {
                UseClamAV = appSettings.UseClamAV,
                ClamAVServerAddress = appSettings.ClamAVServerAddress,
                ClamAVServerPort = appSettings.ClamAVServerPort
            };

            this.compositeTask = task;
            this.targetDirectories = compositeTask.Task.TargetDirectories;
            this.scanner = new Scanner(compositeTask.Task, scanConfig);

            this.Text = string.Format(
                "{0}: {1}",
                WindowTitleBase,
                compositeTask.Task.Name);
        }

        private void TaskProgress_Load(object sender, EventArgs e)
        {
            typedLocationView = new TypedObjectListView<DirectoryItem>(this.listViewResults);
            typedResultsView = new TypedObjectListView<FileItem>(this.listViewResults);

            listViewLocations.SetObjects(targetDirectories);
            listViewResults.SetObjects(detections);

            SetListViewOverlay();

            RichTextBoxTarget.ReInitializeAllTextboxes(this);

            /* Subscribe to Scanner events */
            var statusChangedHandler = new EventHandler<StatusChangedArgs>(Scanner_OnStatusChanged);

            scanner.StatusChanged += statusChangedHandler;

            StartScan();
        }

        private void StartScan()
        {
            toolStripProgressBar.Style = ProgressBarStyle.Marquee;

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
                // engine.resume();
            }

            if (scanStatus == ScanStatus.RUNNING)
            {
                tokenSource.Cancel();
            }

            // engine.stop();
        }

        private void ShowInFileInspector(FileItem item)
        {
            try
            {
                Inspector.LaunchFileInspector(item.AbsolutePath);
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

        private void HandleRemovalAction(IList<FileItem> selectedItems, RemovalAction action)
        {
            const string DialogInstructionDelete = "The {0} selected file(s) will be permanently deleted.";
            const string DialogInstructionQuarantine = "The {0} selected file(s) will be moved into quarantine.";
            const string ErrorMessageDelete = "Unable to delete '{0}.'{1}Detail:{2}";
            const string ErrorMessageQuarantine = "Unable to delete '{0}'.{1}Detail:{2}";

            var td = new TaskDialog();

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

            TaskDialogResult res = td.Show();
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
            }
        }

        private void UpdateUIProgress(int percentage)
        {
            toolStripProgressBar.Value = percentage;
            this.Text = string.Format("{0}: {1}%", compositeTask.Task.Name, percentage);

            if (percentage >= 100)
            {
                // The task has finished
                buttonStop.Enabled = false;
                buttonPause.Enabled = false;
            }
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

        private void Scanner_OnStatusChanged(object sender, StatusChangedArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    Scanner_OnStatusChanged(sender, e);
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
                    break;
                case ScanStatus.RUNNING:
                    buttonPause.Text = "Pause";
                    buttonPause.Enabled = true;
                    buttonStop.Enabled = true;
                    break;
                case ScanStatus.PAUSED:
                    buttonPause.Text = "Resume";
                    buttonPause.Enabled = false;
                    buttonStop.Enabled = true;
                    toolStripStatuslabelStatus.Text = "Scan task paused";
                    break;
                case ScanStatus.COMPLETED:
                    EndScan();
                    break;
                case ScanStatus.FAILED:
                    buttonPause.Enabled = false;
                    buttonStop.Enabled = false;
                    toolStripStatuslabelStatus.Text = "Scan task failed";
                    break;
            }

            /* Raise this form's own event which should be picked up by FormMain */
            StatusChanged?.Invoke(this, e);
        }

        #endregion

        #region UI Event Handlers

        private void objectListViewResults_ItemChecked(object sender, ItemCheckedEventArgs e)
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
            ShowInFileInspector(typedResultsView.CheckedObject);
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

                toolStripStatuslabelStatus.Text = "Scan task complete";
            }
        }

        private void timerLocations_Tick(object sender, EventArgs e)
        {
            scannedDirectories = scanner.GetScannedDirectories().ToList();

            toolStripStatuslabelStatus.Text = string.Format("Scanning... ({0} directories processed)", scannedDirectories.Count);
        }
    }
}