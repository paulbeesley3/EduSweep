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
using EduSweep_2.Common;
using EduSweep_2.Quarantine;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Settings;
using EdUtils.Types;
using Microsoft.WindowsAPICodePack.Dialogs;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class QuarantineManager : Form
    {
        private static IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
            .UseJsonFile(AppFolders.AppSettingsPath)
            .Build();

        private Logger logger = LogManager.GetCurrentClassLogger();

        private List<QuarantineFileItem> files;

        private TypedObjectListView<QuarantineFileItem> typedFileView;

        public QuarantineManager()
        {
            InitializeComponent();
        }

        private void LoadFilesList()
        {
            logger.Debug("Reloading quarantine file list");
            files = Quarantine.QuarantineManager.GetFileItemList();

            objectListViewFiles.SetObjects(files);

            SetStatusBarText();
            SetButtonStates(objectListViewFiles.SelectedItems.Count);
        }

        private void Quarantine_Load(object sender, EventArgs e)
        {
            logger.Info("Form opened");
            FormStatus.QuarantineManagerOpen = true;

            SetListViewOverlay();

            typedFileView =
                new TypedObjectListView<QuarantineFileItem>(this.objectListViewFiles);

            LoadFilesList();
        }

        private void SetListViewOverlay()
        {
            var overlay = objectListViewFiles.EmptyListMsgOverlay as TextOverlay;
            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            objectListViewFiles.EmptyListMsg = "Quarantine is empty.";
            logger.Trace("Set list view overlay");
        }

        private void SetStatusBarText()
        {
            int fileCount = Quarantine.QuarantineManager.GetCount();

            toolStripStatusLabelCount.Text = fileCount == 1 ?
                "1 file in quarantine" :
                string.Format("{0} files in quarantine", fileCount);
            logger.Trace("Set status bar text");
        }

        private void SetButtonStates(int selectedItemCount)
        {
            logger.Debug("Updating button states");
            toolStripButtonDelete.Enabled = false;
            toolStripButtonDetails.Enabled = false;
            toolStripButtonRestore.Enabled = false;
            toolStripDropDownButtonOnline.Enabled = false;
            toolStripDropDownButtonExtensions.Enabled = false;
            toolStripButtonOpenOriginalLocation.Enabled = false;

            if (selectedItemCount > 0)
            {
                logger.Trace("Button states initially set to single selection");
                toolStripDropDownButtonOnline.Enabled = true;
                toolStripDropDownButtonExtensions.Enabled = true;
                toolStripButtonOpenOriginalLocation.Enabled = true;
                toolStripButtonRestore.Enabled = true;
                toolStripButtonDelete.Enabled = true;

                if (AppFolders.FileInspectorIsInstalled())
                {
                    logger.Trace("File Inspector button enabled");
                    toolStripButtonDetails.ToolTipText = "Opens file in the File Inspector utility.";
                    toolStripButtonDetails.Enabled = true;
                }
                else
                {
                    logger.Trace("File Inspector button disabled");
                    toolStripButtonDetails.ToolTipText = "The File Inspector utility is not installed.";
                }

                if (selectedItemCount > 1)
                {
                    logger.Trace("Button states set to multiple selection");
                    toolStripDropDownButtonOnline.Enabled = false;
                    toolStripDropDownButtonExtensions.Enabled = false;
                    toolStripButtonOpenOriginalLocation.Enabled = false;
                    toolStripButtonDetails.Enabled = false;
                }
            }
            else
            {
                logger.Trace("Button states set to disabled as no item is selected");
            }
        }

        private void HandleRemovalAction(
            IList<QuarantineFileItem> selectedItems, 
            RemovalAction action)
        {
            const string DialogInstructionDelete = "The {0} selected file(s) will be permanently deleted.";
            const string DialogInstructionRestore = "The {0} selected file(s) will be placed back in their original location.";
            const string ErrorMessageDelete = "Unable to delete '{0}.'{1}Detail:{2}";
            const string ErrorMessageRestore = "Unable to restore '{0}'.{1}Detail:{2}";

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
                string.Format(DialogInstructionRestore, selectedItems.Count);

            td.Caption = action == RemovalAction.DELETE ?
                "Delete Selected Files?" :
                "Quarantine Selected Files?";

            td.Text = "Do you want to continue?";

            TaskDialogResult res = td.Show();
            if (res == TaskDialogResult.Yes)
            {
                foreach (QuarantineFileItem file in selectedItems)
                {
                    try
                    {
                        if (action == RemovalAction.RESTORE)
                        {
                            logger.Debug(
                                "Restoring file: {0} to {1}", 
                                file.AbsolutePath,
                                file.OriginalDirectoryPath);

                            Quarantine.QuarantineManager.RestoreFile(file);
                        }
                        else
                        {
                            logger.Debug("Deleting file: {0}", file.AbsolutePath);
                            File.Delete(file.AbsolutePath);
                        }
                    }
                    catch (Exception err)
                    {
                        logger.Error(
                            err,
                            string.Format("File handling failed for '{0}'", file.AbsolutePath));

                        MessageBox.Show(
                            string.Format(
                                action == RemovalAction.DELETE ? ErrorMessageDelete : ErrorMessageRestore,
                                file.AbsolutePath,
                                Environment.NewLine,
                                err.Message),
                            "Quarantine Manager",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1);
                    }
                }

                LoadFilesList();
            }
        }

        private void QuarantineManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Info("Form closed");
            FormStatus.QuarantineManagerOpen = false;
        }

        #region Toolstrip Button Event Handlers

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            var selectedFileNames = new List<string>();

            logger.Debug("Showing add file dialog");
            using (var cfd = new CommonOpenFileDialog("Move Files to Quarantine")
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
                    logger.Trace(
                        "Dialog returned {0} file(s) to move into quarantine",
                        selectedFileNames.Count);
                }
                else
                {
                    logger.Trace("The dialog was cancelled");
                    return;
                }
            }

            ImportFiles(selectedFileNames);
        }

        private void toolStripButtonRestore_Click(object sender, EventArgs e) => HandleRemovalAction(typedFileView.SelectedObjects, RemovalAction.RESTORE);

        private void toolStripButtonDelete_Click(object sender, EventArgs e) => HandleRemovalAction(typedFileView.SelectedObjects, RemovalAction.DELETE);

        private void toolStripButtonDetails_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted detail lookup when no file selected.");
                return;
            }

            try
            {
                Inspector.LaunchFileInspector(selectedItem.AbsolutePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format(
                        "Unable to start the File Inspector utility.{0}Detail: {1}",
                        Environment.NewLine,
                        ex.Message),
                    "Quarantine Manager",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripButtonOpenOriginalLocation_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted original location access when no file selected.");
                return;
            }

            logger.Debug("Starting explorer process to show {0}", selectedItem.OriginalDirectoryPath);
            Process.Start("explorer.exe", selectedItem.OriginalDirectoryPath);
        }

        private void toolStripMenuItemGoogle_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted online lookup when no file selected.");
                return;
            }

            Web.LookupSearchTerm(
                selectedItem.Name,
                OnlineSearchProvider.GOOGLE);
        }

        private void toolStripMenuItemBing_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted online lookup when no file selected.");
                return;
            }

            Web.LookupSearchTerm(
                selectedItem.Name,
                OnlineSearchProvider.BING);
        }

        private void toolStripMenuItemDDG_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted online lookup when no file selected.");
                return;
            }

            Web.LookupSearchTerm(
                selectedItem.Name,
                OnlineSearchProvider.DUCKDUCKGO);
        }

        private void toolStripMenuItemExtFilExt_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted online lookup when no file selected.");
                return;
            }

            Web.LookupSearchTerm(
                selectedItem.Extension.Name,
                OnlineSearchProvider.FILEXT);
        }

        private void toolStripMenuItemExtFileInfo_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted online lookup when no file selected.");
                return;
            }

            Web.LookupSearchTerm(
                selectedItem.Extension.Name,
                OnlineSearchProvider.FILEINFO);
        }

        private void toolStripMenuItemExtFES_Click(object sender, EventArgs e)
        {
            QuarantineFileItem selectedItem = typedFileView.SelectedObject;
            if (selectedItem == null)
            {
                logger.Error("Attempted online lookup when no file selected.");
                return;
            }

            Web.LookupSearchTerm(
                selectedItem.Extension.Name,
                OnlineSearchProvider.FILEEXTENSION);
        }

        #endregion

        #region ListView Event Handlers

        private void objectListViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.Trace("Selected listview item changed");
            SetButtonStates(objectListViewFiles.SelectedItems.Count);
        }

        private void objectListViewFiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            logger.Debug("{0} files were dropped onto the listview", files.Length);
            foreach (var file in files)
            {
                logger.Trace("Dropped file: {0}", file);
            }

            ImportFiles(files);
        }

        private void objectListViewFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        #endregion

        private void ImportFiles(IList<string> fileNames)
        {
            foreach (string fileName in fileNames)
            {
                try
                {
                    logger.Debug("Importing file {0}", fileName);
                    Quarantine.QuarantineManager.ImportFile(new FileInfo(fileName));
                }
                catch (Exception ex)
                {
                    logger.Error(ex, string.Format("Quarantine failed for '{0}'", fileName));

                    MessageBox.Show(
                        string.Format(
                            "Unable to move '{0}' into quarantine{1}{2}",
                            fileName,
                            Environment.NewLine,
                            ex.Message),
                        "Quarantine Manager",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error,
                        MessageBoxDefaultButton.Button1);
                }
            }

            LoadFilesList();
        }
    }
}
