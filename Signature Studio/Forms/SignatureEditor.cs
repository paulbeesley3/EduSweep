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
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Signatures;
using EdUtils.Types;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Signature_Studio.Forms
{
    public partial class SignatureEditor : Form
    {
        private Signature signature;
        private bool editing;
        private bool modified;

        private List<ExtensionSignatureElement> extensions = new List<ExtensionSignatureElement>();
        private List<KeywordSignatureElement> keywords = new List<KeywordSignatureElement>();
        private List<HashSignatureElement> files = new List<HashSignatureElement>();

        private TypedObjectListView<ExtensionSignatureElement> typedExtensionList;
        private TypedObjectListView<KeywordSignatureElement> typedKeywordList;
        private TypedObjectListView<HashSignatureElement> typedFileList;

        public SignatureEditor()
        {
            InitializeComponent();
        }

        public SignatureEditor(Signature signature) : this()
        {
            this.signature = signature;
        }

        private void SignatureEditor_Load(object sender, EventArgs e)
        {
            typedExtensionList = new TypedObjectListView<ExtensionSignatureElement>(listViewExtensions);
            typedKeywordList = new TypedObjectListView<KeywordSignatureElement>(listViewKeywords);
            typedFileList = new TypedObjectListView<HashSignatureElement>(listViewFiles);

            /*
             * If a signature instance was provided for editing, load it. Otherwise a
             * new signature instance should be created.
             */
            if (signature == null)
            {
                signature = new Signature();
            }
            else
            {
                editing = true;
                LoadExistingSignature();
            }

            listViewExtensions.SetObjects(extensions);
            listViewKeywords.SetObjects(keywords);
            listViewFiles.SetObjects(files);

            SetListViewOverlay();
            SetSaveButtonState();
            textBoxName.Select();

            modified = false;
        }

        private void LoadExistingSignature()
        {
            textBoxName.Text = signature.Name;
            textBoxDescription.Text = signature.Description;
            buttonCreate.Text = "Save";

            if (signature.Category.Equals(string.Empty))
            {
                signature.Category = "Uncategorised";
            }

            textBoxCategory.Text = signature.Category;

            foreach (SignatureElement element in signature.Elements)
            {
                switch (element.Type)
                {
                    case DetectionType.EXTENSION:
                        var extElement = element as ExtensionSignatureElement;
                        if (extElement == null)
                        {
                            break;
                        }

                        extensions.Add(extElement);
                        break;
                    case DetectionType.KEYWORD:
                        var keyElement = element as KeywordSignatureElement;
                        if (keyElement == null)
                        {
                            break;
                        }

                        keywords.Add(keyElement);
                        break;
                    case DetectionType.HASH:
                        var hashElement = element as HashSignatureElement;
                        if (hashElement == null)
                        {
                            break;
                        }

                        files.Add(hashElement);
                        break;
                    case DetectionType.CLAMAV:
                    default:
                        break;
                }
            }

            extensions = signature.Elements.OfType<ExtensionSignatureElement>().ToList();
            keywords = signature.Elements.OfType<KeywordSignatureElement>().ToList();
            files = signature.Elements.OfType<HashSignatureElement>().ToList();
        }

        private void SetListViewOverlay()
        {
            var extensionOverlay = listViewExtensions.EmptyListMsgOverlay as TextOverlay;
            var fileOverlay = listViewFiles.EmptyListMsgOverlay as TextOverlay;
            var keywordOverlay = listViewKeywords.EmptyListMsgOverlay as TextOverlay;

            extensionOverlay.BorderWidth = 0;
            extensionOverlay.BackColor = Color.Empty;
            extensionOverlay.TextColor = Color.Black;

            fileOverlay.BorderWidth = 0;
            fileOverlay.BackColor = Color.Empty;
            fileOverlay.TextColor = Color.Black;

            keywordOverlay.BorderWidth = 0;
            keywordOverlay.BackColor = Color.Empty;
            keywordOverlay.TextColor = Color.Black;

            listViewExtensions.EmptyListMsg = "Detect file extensions such as 'pdf' or '.png'.";
            listViewFiles.EmptyListMsg = "Detect specific files based on their size and SHA1 hash.";
            listViewKeywords.EmptyListMsg = "Detect keywords in a filename.";
        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {
            signature.Name = textBoxName.Text;
            modified = true;
            SetSaveButtonState();
        }

        private void textBoxCategory_TextChanged(object sender, EventArgs e)
        {
            signature.Category = textBoxCategory.Text;
            modified = true;
        }

        private void SetSaveButtonState()
        {
            int elementCount;

            if (string.IsNullOrEmpty(signature.Name))
            {
                buttonCreate.Enabled = false;
                return;
            }

            elementCount = extensions.Count + keywords.Count + files.Count;
            buttonCreate.Enabled = elementCount > 0;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (editing)
            {
                /* Prevent duplicate elements by removing existing ones */
                signature.Elements.Clear();
            }

            if (signature.Category.Equals(string.Empty))
            {
                signature.Category = "Uncategorised";
            }

            foreach (HashSignatureElement file in files)
            {
                signature.Elements.Add(file);
            }

            foreach (ExtensionSignatureElement ext in extensions)
            {
                signature.Elements.Add(ext);
            }

            foreach (KeywordSignatureElement keyword in keywords)
            {
                signature.Elements.Add(keyword);
            }

            signature.LastWriteTime = DateTime.Now;

            try
            {
                signature.Save(AppFolders.CustomSignatureFolder);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    string.Format(
                        "Unable to save the signature file to custom signature directory.{0}Detail: {1}",
                        Environment.NewLine,
                        AppFolders.CustomSignatureFolder),
                    "Signature Editor",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                Close();
            }

            if (editing)
            {
                /* Don't give the option to create more signatures */
                Close();
            }
            else
            {
                TaskDialogResult res;
                using (var dialog = new TaskDialog())
                {
                    TaskDialogStandardButtons button = TaskDialogStandardButtons.None;
                    button |= TaskDialogStandardButtons.Yes;
                    button |= TaskDialogStandardButtons.No;

                    dialog.Icon = TaskDialogStandardIcon.Information;

                    const string Title = "Signature Editor";
                    string instruction = "Signature saved";
                    const string Content = "Create another?";

                    dialog.StandardButtons = button;
                    dialog.InstructionText = instruction;
                    dialog.Caption = Title;
                    dialog.Text = Content;

                    res = dialog.Show();
                }

                if (res == TaskDialogResult.Yes)
                {
                    Reset();
                }
                else
                {
                    Close();
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            if (modified)
            {
                TaskDialogResult res;
                using (var dialog = new TaskDialog())
                {
                    TaskDialogStandardButtons button = TaskDialogStandardButtons.None;
                    button |= TaskDialogStandardButtons.Yes;
                    button |= TaskDialogStandardButtons.No;
                    dialog.StartupLocation = TaskDialogStartupLocation.CenterOwner;
                    dialog.OwnerWindowHandle = this.Handle;

                    dialog.Icon = TaskDialogStandardIcon.Warning;

                    const string Title = "Signature Editor";
                    string instruction = "The current signature has unsaved changes which will be " +
                        "discarded if this window is closed.";
                    const string Content = "Close the editor and discard these changes?";

                    dialog.StandardButtons = button;
                    dialog.InstructionText = instruction;
                    dialog.Caption = Title;
                    dialog.Text = Content;
                    dialog.StartupLocation = TaskDialogStartupLocation.CenterOwner;
                    dialog.OwnerWindowHandle = this.Handle;

                    res = dialog.Show();
                }

                if (res == TaskDialogResult.Yes)
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void Reset()
        {
            signature = new Signature();

            textBoxName.Clear();
            textBoxDescription.Clear();

            /* Preserve the category when resetting */
            signature.Category = textBoxCategory.Text;

            files.Clear();
            extensions.Clear();
            keywords.Clear();

            listViewExtensions.SetObjects(extensions);
            listViewKeywords.SetObjects(keywords);
            listViewFiles.SetObjects(files);

            SetRemoveExtensionButtonState();
            SetRemoveKeywordButtonState();
            SetRemoveFileButtonState();
            SetSaveButtonState();

            modified = false;
        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {
            signature.Description = textBoxDescription.Text;
            modified = true;
        }

        #region Toolstrip Button Event Handlers

        private void toolStripButtonAddExtension_Click(object sender, EventArgs e)
        {
            AddExtension();
        }

        private void toolStripButtonAddKeyword_Click(object sender, EventArgs e)
        {
            AddKeyword();
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

            listViewFiles.SetObjects(files);
            SetSaveButtonState();
        }

        private void AddFiles(IList<string> paths)
        {
            var elements = new List<HashSignatureElement>();

            foreach (string path in paths)
            {
                var file = new FileItem(new FileInfo(path));

                string sum = Checksums.GetChecksumFromFile(file, Checksums.ChecksumType.SHA1);
                elements.Add(new HashSignatureElement(file, sum));
            }

            files = files.Union(elements, new HashSignatureElementComparer()).ToList();
            modified = true;
        }

        private void toolStripButtonRemoveExtension_Click(object sender, EventArgs e)
        {
            ExtensionSignatureElement element = typedExtensionList.SelectedObject;

            if (element != null)
            {
                extensions.Remove(element);
                listViewExtensions.SetObjects(extensions);
                SetRemoveExtensionButtonState();
                SetSaveButtonState();
                modified = true;
            }
        }

        private void toolStripButtonRemoveKeyword_Click(object sender, EventArgs e)
        {
            KeywordSignatureElement element = typedKeywordList.SelectedObject;

            if (element != null)
            {
                keywords.Remove(element);
                listViewKeywords.SetObjects(keywords);
                SetRemoveKeywordButtonState();
                SetSaveButtonState();
                modified = true;
            }
        }

        private void toolStripButtonRemoveFile_Click(object sender, EventArgs e)
        {
            var filesToRemove = new List<HashSignatureElement>(typedFileList.SelectedObjects);

            files = files.Except(filesToRemove).ToList();

            listViewFiles.SetObjects(files);
            modified = true;

            SetRemoveFileButtonState();
            SetSaveButtonState();
        }

        #endregion

        private void listViewExtensions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRemoveExtensionButtonState();
        }

        private void listViewKeywords_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRemoveKeywordButtonState();
        }

        private void listViewFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetRemoveFileButtonState();
        }

        private void SetRemoveExtensionButtonState()
        {
            toolStripButtonRemoveExtension.Enabled =
                listViewExtensions.SelectedItems.Count > 0;
        }

        private void SetRemoveKeywordButtonState()
        {
            toolStripButtonRemoveKeyword.Enabled =
                listViewKeywords.SelectedItems.Count > 0;
        }

        private void SetRemoveFileButtonState()
        {
            toolStripButtonRemoveFile.Enabled =
                listViewFiles.SelectedItems.Count > 0;
        }

        private void toolStripTextBoxExtension_TextChanged(object sender, EventArgs e)
        {
            toolStripButtonAddExtension.Enabled =
                toolStripTextBoxExtension.TextLength > 0;
        }

        private void toolStripTextBoxKeyword_TextChanged(object sender, EventArgs e)
        {
            toolStripButtonAddKeyword.Enabled =
                toolStripTextBoxKeyword.TextLength > 0;
        }

        private void AddExtension()
        {
            string extensionName = toolStripTextBoxExtension.Text;

            if (string.IsNullOrEmpty(extensionName))
            {
                return;
            }

            var extension = new ExtensionSignatureElement(new Extension(extensionName));

            extensions.Add(extension);

            listViewExtensions.SetObjects(extensions);

            toolStripTextBoxExtension.Clear();
            SetSaveButtonState();
            toolStripTextBoxExtension.Select();
            this.ActiveControl = toolStripTextBoxExtension.Control;

            modified = true;
        }

        private void AddKeyword()
        {
            string keyword = toolStripTextBoxKeyword.Text;

            if (string.IsNullOrEmpty(keyword))
            {
                return;
            }

            var word = new KeywordSignatureElement(keyword);

            keywords.Add(word);
            listViewKeywords.SetObjects(keywords);

            toolStripTextBoxKeyword.Clear();
            SetSaveButtonState();
            toolStripTextBoxKeyword.Select();
            this.ActiveControl = toolStripTextBoxKeyword.Control;

            modified = true;
        }

        private void toolStripTextBoxExtension_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddExtension();
            }
        }

        private void toolStripTextBoxKeyword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddKeyword();
            }
        }
    }
}
