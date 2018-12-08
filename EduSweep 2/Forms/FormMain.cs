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
using System.Windows.Forms;
using BrightIdeasSoftware;
using Config.Net;
using EduEngine.Scanner;
using EduSweep_2.Common;
using EduSweep_2.Tasks;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Settings;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class FormMain : Form
    {
        private static IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private List<CompositeScanTask> tasks = new List<CompositeScanTask>();

        private TypedObjectListView<CompositeScanTask> typedTaskList;

        public FormMain()
        {
            InitializeComponent();

            this.olvColumnStatus.AspectToStringConverter = delegate(object obj)
            {
                var status = (ScanStatus)obj;

                switch (status)
                {
                    case ScanStatus.UNINITIALZED:
                    case ScanStatus.INITIALIZED:
                        return "Not Started";
                    case ScanStatus.RUNNING:
                        return "Running";
                    case ScanStatus.PAUSED:
                        return "Paused";
                    case ScanStatus.COMPLETED:
                        return "Completed";
                    case ScanStatus.FAILED:
                        return "Failed";
                    default:
                        return "Unknown";
                }
            };
        }

        private void SetListViewOverlay()
        {
            var overlay = listViewTasks.EmptyListMsgOverlay as TextOverlay;
            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            listViewTasks.EmptyListMsg = "No tasks. Use the 'New' button to create one.";
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            logger.Info("Form opened");

            toolStripStatusLabelWorkDirectory.Text = AppFolders.BaseWorkingFolder;

            SetListViewOverlay();
            SetToolsMenuItemStates();

            typedTaskList = new TypedObjectListView<CompositeScanTask>(this.listViewTasks);

            LoadTaskList();
        }

        #region UI Refresh

        private void LoadTaskList()
        {
            tasks = CompositeScanTaskManager.GetTaskList();
            listViewTasks.SetObjects(tasks);
            SetTaskControlStates();

            logger.Debug("Loaded task list");
        }

        private void SetToolsMenuItemStates()
        {
            if (AppFolders.FileInspectorIsInstalled())
            {
                logger.Trace("File Inspector menu item enabled");
                fileInspectorToolStripMenuItem.ToolTipText = "Launches the File Inspector utility.";
                fileInspectorToolStripMenuItem.Enabled = true;
            }
            else
            {
                logger.Trace("File Inspector menu item disabled");
                fileInspectorToolStripMenuItem.ToolTipText = "File Inspector is not installed.";
                fileInspectorToolStripMenuItem.Enabled = false;
            }

            if (AppFolders.SigStudioIsInstalled())
            {
                logger.Trace("Signature Studio menu item enabled");
                launchSignatureStudioToolStripMenuItem.ToolTipText = "Launches the Signature Studio utility.";
                launchSignatureStudioToolStripMenuItem.Enabled = true;
            }
            else
            {
                logger.Trace("Signature Studio menu item disabled");
                launchSignatureStudioToolStripMenuItem.ToolTipText = "Signature Studio is not installed.";
                launchSignatureStudioToolStripMenuItem.Enabled = false;
            }
        }

        private void SetTaskControlStates()
        {
            CompositeScanTask task = typedTaskList.SelectedObject;

            if (task == null)
            {
                logger.Trace("Disabling task buttons and menu items");
                toolStripButtonStartTask.Enabled = false;
                startToolStripMenuItem.Enabled = false;

                toolStripButtonEditTask.Enabled = false;
                editToolStripMenuItem.Enabled = false;

                toolStripButtonDeleteTask.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;

                toolStripButtonClone.Enabled = false;
                cloneToolStripMenuItem.Enabled = false;
            }
            else
            {
                switch (task.Status)
                {
                    case ScanStatus.INITIALIZED:
                    case ScanStatus.RUNNING:
                    case ScanStatus.PAUSED:
                        logger.Trace("Setting buttons and menu items to running state");

                        toolStripButtonStartTask.Enabled = false;
                        toolStripButtonEditTask.Enabled = false;
                        toolStripButtonClone.Enabled = false;
                        toolStripButtonDeleteTask.Enabled = false;

                        startToolStripMenuItem.Enabled = false;
                        editToolStripMenuItem.Enabled = false;
                        cloneToolStripMenuItem.Enabled = false;
                        deleteToolStripMenuItem.Enabled = false;
                        break;

                    case ScanStatus.UNINITIALZED:
                    case ScanStatus.COMPLETED:
                    case ScanStatus.FAILED:
                    default:
                        logger.Trace("Setting buttons and menu items to inactive state");

                        toolStripButtonStartTask.Enabled = true;
                        toolStripButtonEditTask.Enabled = true;
                        toolStripButtonClone.Enabled = true;
                        toolStripButtonDeleteTask.Enabled = true;

                        startToolStripMenuItem.Enabled = true;
                        editToolStripMenuItem.Enabled = true;
                        cloneToolStripMenuItem.Enabled = true;
                        deleteToolStripMenuItem.Enabled = true;
                        break;
                }
            }
        }

        #endregion

        #region Task Control Actions

        private void TaskControlActionStart()
        {
            CompositeScanTask selectedTask = typedTaskList.SelectedObject;

            logger.Debug("Starting task {0}", selectedTask.Task.Name);
            var tp = new TaskProgress(selectedTask);
            tp.Show();

            SetTaskControlStates();
        }

        private void TaskControlActionNew()
        {
            logger.Debug("Starting task designer (new task)");
            using (var nt = new TaskDesigner())
            {
                nt.ShowDialog(this);
            }

            LoadTaskList();
        }

        private void TaskControlActionEdit()
        {
            CompositeScanTask selectedTask = typedTaskList.SelectedObject;

            logger.Debug("Starting task designer (editing {0})", selectedTask.Task.Name);
            using (var nt = new TaskDesigner(selectedTask.Task))
            {
                nt.ShowDialog(this);
            }

            LoadTaskList();
        }

        private void TaskControlActionClone()
        {
            CompositeScanTask selectedTask = typedTaskList.SelectedObject;

            try
            {
                logger.Debug("Cloning task {0}", selectedTask.Task.Name);
                ScanTaskManager.CloneTask(selectedTask.Task, AppFolders.TaskFolder);
                LoadTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "'{0}' could not be cloned.{1}Detail:{2}",
                        selectedTask.Task.Name,
                        Environment.NewLine,
                        ex.Message),
                    "Task Manager",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void TaskControlActionDelete()
        {
            TaskDialogResult result;
            CompositeScanTask selectedTask = typedTaskList.SelectedObject;

            logger.Trace("Displaying task deletion confirmation dialog");
            using (var dialog = new TaskDialog())
            {
                TaskDialogStandardButtons button = TaskDialogStandardButtons.None;
                button |= TaskDialogStandardButtons.Yes;
                button |= TaskDialogStandardButtons.No;
                dialog.StandardButtons = button;
                dialog.StartupLocation = TaskDialogStartupLocation.CenterOwner;
                dialog.OwnerWindowHandle = this.Handle;

                dialog.Icon = TaskDialogStandardIcon.Information;

                const string Title = "Delete Task";
                string instruction = "The scan task '" + listViewTasks.SelectedItems[0].Text + "' is about to be deleted";
                const string Content = "Do you want to continue?";

                dialog.InstructionText = instruction;
                dialog.Caption = Title;
                dialog.Text = Content;

                result = dialog.Show();
            }
                       
            if (result == TaskDialogResult.Yes)
            {
                try
                {
                    logger.Debug("Removing task {0}", selectedTask.Task.Name);
                    ScanTaskManager.RemoveTask(selectedTask.Task);
                    LoadTaskList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        string.Format(
                            "'{0}' could not be deleted.{1}Detail:{2}",
                            selectedTask.Task.Name,
                            Environment.NewLine,
                            ex.Message),
                        "Task Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }
            else
            {
                logger.Trace("Removal of task '{0}' cancelled by user", selectedTask.Task.Name);
            }
        }

        #endregion

        #region Scan Task Toolstrip Event Handlers

        private void toolStripButtonStartTask_Click(object sender, EventArgs e)
        {
            TaskControlActionStart();
        }

        private void toolStripButtonNewTask_Click(object sender, EventArgs e)
        {
            TaskControlActionNew();
        }

        private void toolStripButtonEditTask_Click(object sender, EventArgs e)
        {
            TaskControlActionEdit();
        }

        private void toolStripButtonClone_Click(object sender, EventArgs e)
        {
            TaskControlActionClone();
        }

        private void toolStripButtonDeleteTask_Click(object sender, EventArgs e)
        {
            TaskControlActionDelete();
        }

        private void toolStripButtonDonate_Click(object sender, EventArgs e)
        {
            logger.Debug("Launching web browser for donation (thanks!)");
            Web.LaunchWebBrowser(appSettings.ProjectDonationLink);
        }

        #endregion

        #region Menu Event Handlers

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskControlActionNew();
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskControlActionStart();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskControlActionEdit();
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskControlActionClone();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskControlActionDelete();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Application exit requested");
            Application.Exit();
        }

        private void fileInspectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = AppFolders.FileInspectorPath;
                logger.Debug("Starting File Inspector process: {0}", path);
                var inspectorProcess = new ProcessStartInfo(path);
                Process.Start(inspectorProcess);
            }
            catch (Exception err)
            {
                MessageBox.Show(
                    string.Format("Unable to start File Inspector.{0}Detail: {1}", Environment.NewLine, err.Message),
                    "File Inspector",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void launchSignatureStudioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = AppFolders.SigStudioPath;
                logger.Debug("Starting Signature Studio process: {0}", path);
                var studioProcess = new ProcessStartInfo(path);
                Process.Start(studioProcess);
            }
            catch (Exception err)
            {
                MessageBox.Show(
                    string.Format("Unable to start Signature Studio.{0}Detail: {1}", Environment.NewLine, err.Message),
                    "Signature Studio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripMenuItemHomepage_Click(object sender, EventArgs e)
        {
            logger.Debug("Launching web browser for project home");
            Web.LaunchWebBrowser(appSettings.ProjectHomeLink);
        }

        private void toolStripMenuItemDocs_Click(object sender, EventArgs e)
        {
            logger.Debug("Launching web browser for documentation");
            Web.LaunchWebBrowser(appSettings.ProjectDocsLink);
        }

        private void toolStripMenuItemIssue_Click(object sender, EventArgs e)
        {
            logger.Debug("Launching web browser for issue reporting");
            Web.LaunchWebBrowser(appSettings.ProjectIssueLink);
        }

        private void toolStripMenuItemUpdates_Click(object sender, EventArgs e)
        {
            logger.Debug("Launching web browser for version check");
            Web.LaunchWebBrowser(appSettings.ProjectReleasesLink);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Debug("Displaying about dialog");
            var ab = new About();
            ab.ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormStatus.ProgramSettingsOpen)
            {
                logger.Debug("Displaying settings dialog");
                var ps = new ProgramSettings();
                ps.ShowDialog(this);
            }
        }

        private void quarantineBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormStatus.QuarantineManagerOpen)
            {
                logger.Debug("Displaying quarantine manager window");
                var qu = new QuarantineManager();
                qu.Show(this);
            }
            else
            {
                logger.Trace("Cancelled opening quarantine manager. An instance is already open.");
            }
        }

        private void reportBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormStatus.ReportManagerOpen)
            {
                logger.Debug("Displaying reports window");
                var rp = new TaskReports();
                rp.Show(this);
            }
            else
            {
                logger.Trace("Cancelled opening report manager. An instance is already open.");
            }
        }

        #endregion

        #region List View Event Handlers

        private void listViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Trace("Task selection updated");
            SetTaskControlStates();
        }

        private void listViewTasks_DoubleClick(object sender, EventArgs e)
        {
            logger.Trace("Task double clicked");
        }

        #endregion

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Info("Form closed");
        }
    }
}