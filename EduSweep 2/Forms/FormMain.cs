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

namespace EduSweep_2.Forms
{
    public partial class FormMain : Form
    {
        private static IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

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
        }

        private void SetToolsMenuItemStates()
        {
            if (AppFolders.FileInspectorIsInstalled())
            {
                fileInspectorToolStripMenuItem.ToolTipText = "Launches the File Inspector utility.";
                fileInspectorToolStripMenuItem.Enabled = true;
            }
            else
            {
                fileInspectorToolStripMenuItem.ToolTipText = "File Inspector is not installed.";
                fileInspectorToolStripMenuItem.Enabled = false;
            }

            if (AppFolders.SigStudioIsInstalled())
            {
                launchSignatureStudioToolStripMenuItem.ToolTipText = "Launches the Signature Studio utility.";
                launchSignatureStudioToolStripMenuItem.Enabled = true;
            }
            else
            {
                launchSignatureStudioToolStripMenuItem.ToolTipText = "Signature Studio is not installed.";
                launchSignatureStudioToolStripMenuItem.Enabled = false;
            }
        }

        private void SetTaskControlStates()
        {
            CompositeScanTask task = typedTaskList.SelectedObject;

            if (task == null)
            {
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

            var tp = new TaskProgress(selectedTask);
            tp.Show();

            SetTaskControlStates();
        }

        private void TaskControlActionNew()
        {
            using (var nt = new TaskDesigner())
            {
                nt.ShowDialog(this);
            }

            LoadTaskList();
        }

        private void TaskControlActionEdit()
        {
            CompositeScanTask selectedTask = typedTaskList.SelectedObject;

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
            Application.Exit();
        }

        private void fileInspectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var inspectorProcess = new ProcessStartInfo(AppFolders.FileInspectorPath);
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
                var studioProcess = new ProcessStartInfo(AppFolders.SigStudioPath);
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
            Web.LaunchWebBrowser(appSettings.ProjectHomeLink);
        }

        private void toolStripMenuItemDocs_Click(object sender, EventArgs e)
        {
            Web.LaunchWebBrowser(appSettings.ProjectDocsLink);
        }

        private void toolStripMenuItemIssue_Click(object sender, EventArgs e)
        {
            Web.LaunchWebBrowser(appSettings.ProjectIssueLink);
        }

        private void toolStripMenuItemUpdates_Click(object sender, EventArgs e)
        {
            Web.LaunchWebBrowser(appSettings.ProjectReleasesLink);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new About();
            ab.ShowDialog(this);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormStatus.ProgramSettingsOpen)
            {
                var ps = new ProgramSettings();
                ps.ShowDialog(this);
            }
        }

        private void quarantineBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormStatus.QuarantineManagerOpen)
            {
                var qu = new QuarantineManager();
                qu.Show(this);
            }
        }

        private void reportBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FormStatus.ReportManagerOpen)
            {
                var rp = new TaskReports();
                rp.Show(this);
            }
        }

        private void signatureManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            return;
        }

        #endregion

        #region List View Event Handlers

        private void listViewTasks_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTaskControlStates();
        }

        private void listViewTasks_DoubleClick(object sender, EventArgs e)
        {
            /* Start the task */
        }

        #endregion
    }
}