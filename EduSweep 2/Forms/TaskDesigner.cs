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
using System.Linq;
using System.Windows.Forms;
using BrightIdeasSoftware;
using EduEngine.Scanner;
using EduEngine.Tasks;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Signatures;
using EdUtils.WindowsPlatform;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class TaskDesigner : Form
    {
        private enum EditMode
        {
            CREATE,
            MODIFY
        }

        private const string WindowTitleBase = "Task Editor";

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private EditMode mode;

        private bool quickAddTargetPathIsValid;

        private ScanTask task;

        private TypedObjectListView<DirectoryItem> typedListViewTargets;
        private TypedObjectListView<SignatureElement> typedListViewSignatures;

        public TaskDesigner()
        {
            InitializeComponent();

            mode = EditMode.CREATE;
            this.task = new ScanTask("New Task");

            typedListViewTargets = new TypedObjectListView<DirectoryItem>(this.listViewTargets);
            typedListViewSignatures = new TypedObjectListView<SignatureElement>(this.listViewElements);

            this.olvColumnLocal.AspectToStringConverter = delegate(object x)
            {
                var type = (PathType)x;
                switch (type)
                {
                    case PathType.UNAVAILABLE:
                        return "Not Available";
                    case PathType.LOCAL:
                        return "Local";
                    case PathType.REMOTE_MAPPED:
                        return "Mapped";
                    case PathType.REMOTE_UNC:
                        return "Remote";
                    case PathType.UNKNOWN:
                    default:
                        return "Unknown";
                }
            };

            this.olvColumnType.AspectToStringConverter = delegate(object x)
            {
                var type = (DetectionType)x;
                switch (type)
                {
                    case DetectionType.EXTENSION:
                        return "File Extension";
                    case DetectionType.KEYWORD:
                        return "Filename Keyword";
                    case DetectionType.HASH:
                        return "File Checksum";
                    case DetectionType.CLAMAV:
                        return "Virus";
                    default:
                        return "Unknown";
                }
            };
        }

        public TaskDesigner(ScanTask task) : this()
        {
            mode = EditMode.MODIFY;
            this.task = task;
        }

        private void NewTask_Load(object sender, EventArgs e)
        {
            ActiveControl = textBoxName;

            if (mode == EditMode.MODIFY)
            {
                textBoxName.Text = task.Name;
                listViewTargets.SetObjects(task.TargetDirectories);
                listViewElements.SetObjects(task.Elements);
            }

            SetListViewOverlay();
            SetWindowNameText();
            SetCueText();

            RefreshGeneralPage();
            RefreshTargetsPage();
            RefreshElementsPage();
        }

        private void AddFiles(IList<string> paths)
        {
            var elements = new List<SignatureElement>();

            foreach (string path in paths)
            {
                var info = new FileInfo(path);
                var file = new FileItem(info)
                {
                    Owner = Paths.GetOwner(info)
                };

                string sum = Checksums.GetChecksumFromFile(file, Checksums.ChecksumType.SHA1);
                elements.Add(new HashSignatureElement(file, sum));
            }

            task.Elements = 
                task.Elements.Union(elements, new SignatureElementComparer()).ToList();
        }

        #region Window Control

        private void SetListViewOverlay()
        {
            var overlay = listViewElements.EmptyListMsgOverlay as TextOverlay;
            var targetOverlay = listViewTargets.EmptyListMsgOverlay as TextOverlay;

            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            targetOverlay.BorderWidth = 0;
            targetOverlay.BackColor = Color.Empty;
            targetOverlay.TextColor = Color.Black;

            listViewElements.EmptyListMsg = "Add at least one signature element to detect during the scan.";
            listViewTargets.EmptyListMsg = "Add at least one directory to be scanned.";
        }

        private void RefreshGeneralPage()
        {
            comboBoxParallel.SelectedIndex = (int)task.ParallelLevel;
            checkBoxAntivirus.Checked = task.UseClamAV;
        }

        private void RefreshTargetsPage()
        {
            SetSaveButtonState();

            if (task.TargetDirectories.Count > 0 && listViewTargets.SelectedItems.Count > 0)
            {
               toolStripButtonRemovePath.Enabled = true;
               toolStripButtonRecursive.Enabled = true;
            }
            else
            {
                toolStripButtonRemovePath.Enabled = false;
                toolStripButtonRecursive.Enabled = false;
            }
        }

        private void RefreshElementsPage()
        {
            toolStripButtonRemove.Enabled =
                task.Elements.Count > 0 &&
                listViewElements.SelectedItems.Count > 0;
        }

        private void SetCueText()
        {
            PromptText.SetCue(textBoxName, "My Example Task");
            PromptText.SetCue(textBoxQuickTarget, @"E:\Home Directories\ or \\server\\share");
        }

        private void SetWindowNameText()
        { 
            if (task.Name.Length > 0)
            {
                string title = string.Format("{0}: {1}", WindowTitleBase, task.Name);
                this.Text = title;
                labelHeader.Text = title;
            }
            else
            {
                labelHeader.Text = WindowTitleBase;
                this.Text = WindowTitleBase;
            }
        }

        private void SetSaveButtonState()
        {
            bool allowSave = true;

            if (listViewTargets.Items.Count == 0)
            {
                allowSave = false;
            }

            if (string.IsNullOrEmpty(task.Name))
            {
                allowSave = false;
            }

            if (listViewElements.Items.Count == 0)
            {
                allowSave = false;
            }

            buttonSave.Enabled = allowSave;
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            task.Name = textBoxName.Text;
            SetWindowNameText();
            SetSaveButtonState();
        }

        private void AddDirectoryToTask(string path)
        {
            if (Paths.IsAccessible(path))
            {
                if (Paths.IsDirectory(path))
                {
                    var target = new DirectoryItem(path);
                    if (!task.TargetDirectories.Contains(target))
                    {
                        task.TargetDirectories.Add(target);
                    }
                    else
                    {
                        logger.Debug(
                            string.Format(
                            "Directory '{0}' is already included in the scan task.",
                            path));
                    }
                }
                else
                {
                    logger.Warn(
                    string.Format(
                        "Attempted to add file to task targets: {0}.",
                        path));
                }
            }
            else
            {
                logger.Warn(
                    string.Format(
                        "Invalid path not added to task targets: {0}.",
                        path));
            }
        }

        private void AddDirectoriesToTask(IList<string> paths)
        {
            foreach (string path in paths)
            {
                AddDirectoryToTask(path);
            }

            listViewTargets.SetObjects(task.TargetDirectories);
            RefreshTargetsPage();
        }

        #endregion

        #region Button Event Handlers

        private void buttonSave_Click(object sender, EventArgs e)
        {
            task.Save(AppFolders.TaskFolder);
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            tabControlTask.SelectedIndex--;

            if (tabControlTask.SelectedIndex == tabControlTask.TabCount - 1)
            {
                buttonNext.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
            }

            if (tabControlTask.SelectedIndex == 0)
            {
                buttonBack.Enabled = false;
            }
            else
            {
                buttonBack.Enabled = true;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            tabControlTask.SelectedIndex++;

            if (tabControlTask.SelectedIndex == tabControlTask.TabCount - 1)
            {
                buttonNext.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
            }

            if (tabControlTask.SelectedIndex == 0)
            {
                buttonBack.Enabled = false;
            }
            else
            {
                buttonBack.Enabled = true;
            }
        }

        #endregion

        private void toolStripButtonRemovePath_Click(object sender, EventArgs e)
        {
            var targets = new List<DirectoryItem>(typedListViewTargets.SelectedObjects);

            task.TargetDirectories = task.TargetDirectories.Except(targets).ToList();

            listViewTargets.SetObjects(task.TargetDirectories);

            RefreshTargetsPage();
        }

        private void toolStripButtonAddNetworkPath_Click(object sender, EventArgs e)
        {
            string path;

            using (var addNetworkPathDialog = new AddNetworkPath())
            {
                addNetworkPathDialog.ShowDialog(this);
                path = addNetworkPathDialog.Path;
            }

            if (!string.IsNullOrEmpty(path))
            {
                AddDirectoryToTask(path);
            }

            listViewTargets.SetObjects(task.TargetDirectories);

            RefreshTargetsPage();
        }

        private void toolStripButtonAddPath_Click(object sender, EventArgs e)
        {
            var selectedDirectoryPaths = new List<string>();

            using (var cfd = new CommonOpenFileDialog("Add Directories to Task")
            {
                EnsurePathExists = true,
                EnsureReadOnly = true,
                IsFolderPicker = true,
                AllowNonFileSystemItems = false,
                Multiselect = true,
                NavigateToShortcut = false,
            })
            {
                if (cfd.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
                {
                    selectedDirectoryPaths = new List<string>(cfd.FileNames);
                    AddDirectoriesToTask(selectedDirectoryPaths);
                }
            }
        }

        private void textBoxQuickTarget_KeyPress(object sender, KeyPressEventArgs e)
        {
            /* Enter or Return */
            if (e.KeyChar == 13)
            {
                textBoxQuickTarget.Text.Trim();
                if (textBoxQuickTarget.Text.Length > 0 && quickAddTargetPathIsValid)
                {
                    AddDirectoryToTask(textBoxQuickTarget.Text);
                    textBoxQuickTarget.Clear();
                    timerPathCheck.Stop();
                    timerPathCheck.Start();
                }

                listViewTargets.SetObjects(task.TargetDirectories);

                RefreshTargetsPage();

                e.Handled = true;
            }
        }

        private void textBoxQuickTarget_TextChanged(object sender, EventArgs e)
        {
            timerPathCheck.Stop();
            timerPathCheck.Start();
        }

        private void timerPathCheck_Tick(object sender, EventArgs e)
        {
            timerPathCheck.Stop();

            textBoxQuickTarget.ForeColor = SystemColors.WindowText;
            textBoxQuickTarget.BackColor = SystemColors.Window;
            quickAddTargetPathIsValid = false;

            if (textBoxQuickTarget.Text.Length > 0)
            {
                if (Paths.IsAccessible(textBoxQuickTarget.Text))
                {
                    textBoxQuickTarget.ForeColor = SystemColors.WindowText;
                    textBoxQuickTarget.BackColor = Color.PaleGreen;
                    quickAddTargetPathIsValid = true;
                }
            }
        }

        private void tabControlTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlTask.SelectedIndex == tabControlTask.TabCount - 1)
            {
                buttonNext.Enabled = false;
            }
            else
            {
                buttonNext.Enabled = true;
            }

            if (tabControlTask.SelectedIndex == 0)
            {
                buttonBack.Enabled = false;
            }
            else
            {
                buttonBack.Enabled = true;
            }
        }

        private void listViewBinaries_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void toolStripButtonSubdirs_Click(object sender, EventArgs e)
        {
            var targets = new List<DirectoryItem>(typedListViewTargets.SelectedObjects);

            foreach (DirectoryItem target in targets)
            {
                target.Recursive = !target.Recursive;
            }

            listViewTargets.RefreshSelectedObjects();

            RefreshTargetsPage();
        }

        private void comboBoxParallel_SelectedIndexChanged(object sender, EventArgs e)
        {
            task.ParallelLevel = (ParallelLevel)comboBoxParallel.SelectedIndex;
        }

        private void listViewTargets_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listViewTargets_DragDrop(object sender, DragEventArgs e)
        {
            string[] directories = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            foreach (string directory in directories)
            {
                AddDirectoryToTask(directory);
            }

            listViewTargets.SetObjects(task.TargetDirectories);

            RefreshTargetsPage();
        }

        private void listViewTargets_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshTargetsPage();
        }

        private void checkBoxAntivirus_CheckedChanged(object sender, EventArgs e)
        {
            task.UseClamAV = checkBoxAntivirus.Checked;
        }

        private void toolStripButtonAddKeywordSignature_Click(object sender, EventArgs e)
        {
            Signature selectedSignature;

            using (var signatureSelector = new AddSignature())
            {
                signatureSelector.ShowDialog(this);
                selectedSignature = signatureSelector.GetSelectedSignature();
            }

            if (selectedSignature != null)
            {
                task.Elements = 
                    task.Elements.Union(selectedSignature.Elements, new SignatureElementComparer()).ToList();

                listViewElements.SetObjects(task.Elements);
                RefreshElementsPage();
                SetSaveButtonState();
            }
        }

        private void listViewElements_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshElementsPage();
        }

        private void toolStripButtonAddFile_Click(object sender, EventArgs e)
        {
            var selectedFileNames = new List<string>();

            using (var cfd = new CommonOpenFileDialog("Add Files to Scan Task")
            {
                EnsureReadOnly = true,
                IsFolderPicker = false,
                AllowNonFileSystemItems = false,
                EnsureFileExists = true,
                Multiselect = true,
                NavigateToShortcut = false,
            })
            {
                if (cfd.ShowDialog(this.Handle) == CommonFileDialogResult.Ok)
                {
                    selectedFileNames = new List<string>(cfd.FileNames);
                }
                else
                {
                    return;
                }
            }

            AddFiles(selectedFileNames);
            listViewElements.SetObjects(task.Elements);
            RefreshElementsPage();
        }

        private void toolStripButtonAddKeyword_Click(object sender, EventArgs e)
        {
            /* TODO */
        }

        private void toolStripButtonAddExtension_Click(object sender, EventArgs e)
        {
            /* TODO */
        }

        private void toolStripButtonRemove_Click(object sender, EventArgs e)
        {
            SignatureElement element = typedListViewSignatures.SelectedObject;

            task.Elements.Remove(element);
            listViewElements.SetObjects(task.Elements);
            RefreshElementsPage();
        }
    }
}