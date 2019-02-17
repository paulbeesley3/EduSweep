﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.TrID;
using EdUtils.WindowsPlatform;
using Microsoft.WindowsAPICodePack.Dialogs;
using nClam;

namespace File_Inspector
{
    public partial class FileInspector : Form
    {
        private FileItem fileItem;

        public FileInspector()
        {
            InitializeComponent();
        }

        public FileInspector(string arg)
        {
            InitializeComponent();
            if (arg.Length > 0 && File.Exists(arg))
            {
                OpenFile(arg);
                ScanFile();
            }
        }

        private void FileInspector_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                toolStripInspector.RenderMode = ToolStripRenderMode.Professional;
            }
        }

        private void OpenFile(string filePath)
        {
            var fi = new FileInfo(filePath);
            fileItem = new FileItem(fi)
            {
                Owner = Paths.GetOwner(fi)
            };

            listViewAnalysis.Items.Clear();
            listViewFileTypes.Items.Clear();

            Text = string.Format("{0} - File Inspector", fileItem.Name);
            labelMajorStatus.Text = fileItem.Name;
            pictureBoxSummary.Image = Icons.GetFileIconImage(fileItem);
        }

        private void ScanFile()
        {
            progressBarTaskProgress.Style = ProgressBarStyle.Marquee;
            toolStripInspector.Enabled = false;
            toolStripStatusLabelScan.Text = string.Format("Scanning {0}...", fileItem.Name);

            try
            {
                backgroundWorkerPopulate.RunWorkerAsync();
            }
            catch
            {
            }
        }

        private void backgroundWorkerPopulate_DoWork(object sender, DoWorkEventArgs e)
        {
            addLVI addListViewItemDelegate = AddListViewItem;

            TrIDLib.AnalyseFile(fileItem);

            /* Full path */
            var fullPath = new ListViewItem("Location");
            var fullPathValue = new ListViewItem.ListViewSubItem
                {
                    Text = fileItem.ParentDirectoryPath
                };
            fullPath.SubItems.Add(fullPathValue);
            fullPath.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { fullPath });

            /* Windows extension */
            var windowsExtension = new ListViewItem("Indicated Extension");
            var windowsExtensionValue = new ListViewItem.ListViewSubItem
                {
                    Text = fileItem.Extension.Name
                };
            windowsExtension.SubItems.Add(windowsExtensionValue);
            windowsExtension.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { windowsExtension });

            /* Detected extension */
            var detectedExtension = new ListViewItem("Detected Extension");
            var detectedExtensionValue = new ListViewItem.ListViewSubItem();

            if (fileItem.TridExtensions.Count > 0)
            {
                detectedExtensionValue.Text = fileItem.TridExtensions[0].DottedName;
            }
            else
            {
                detectedExtensionValue.Text = "Unknown";
            }

            detectedExtension.SubItems.Add(detectedExtensionValue);
            detectedExtension.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { detectedExtension });

            /* MIME Type */
            var mimeType = new ListViewItem("Detected MIME Type");
            var mimeTypeValue = new ListViewItem.ListViewSubItem
                 { Text = fileItem.MIMEType };
            mimeType.SubItems.Add(mimeTypeValue);
            mimeType.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { mimeType });

            /* Size */
            var size = new ListViewItem("Size");
            var sizeValue = new ListViewItem.ListViewSubItem
                                                         { Text = Utils.GetDynamicFileSize(fileItem.AbsolutePath) };
            size.SubItems.Add(sizeValue);
            size.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { size });

            /* Creation date + time */
            var creationDateTime = new ListViewItem("Creation Date");
            var creationDateTimeValue = new ListViewItem.ListViewSubItem
                                                                     {
                                                                         Text = fileItem.CreationTimeAsText
                                                                     };
            creationDateTime.SubItems.Add(creationDateTimeValue);
            creationDateTime.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { creationDateTime });

            /* Access date + time */
            var accessDateTime = new ListViewItem("Last Access Date");
            var accessDateTimeValue = new ListViewItem.ListViewSubItem
                                                                   {
                                                                       Text = fileItem.LastAccessTimeAsText
                                                                   };
            accessDateTime.SubItems.Add(accessDateTimeValue);
            accessDateTime.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { accessDateTime });

            /* Modify date + time */
            var modifiedDateTime = new ListViewItem("Last Modification Date");
            var modifiedDateTimeValue = new ListViewItem.ListViewSubItem
                                                                     {
                                                                         Text = fileItem.LastWriteTimeAsText
                                                                     };
            modifiedDateTime.SubItems.Add(modifiedDateTimeValue);
            modifiedDateTime.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { modifiedDateTime });

            /* Attributes */
            var attributes = new ListViewItem("Windows Attributes");
            var attributesValue = new ListViewItem.ListViewSubItem
                                                               {
                                                                   Text = fileItem.AttributesAsText
                                                               };
            attributes.SubItems.Add(attributesValue);
            attributes.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { attributes });

            /* Root */
            var pathRoot = new ListViewItem("Host");
            var pathRootValue = new ListViewItem.ListViewSubItem
                                                             {
                                                                 Text = fileItem.RootLocation
                                                             };
            pathRoot.SubItems.Add(pathRootValue);
            pathRoot.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { pathRoot });

            /* Owner */
            var owner = new ListViewItem("Owner");
            var ownerValue = new ListViewItem.ListViewSubItem
                                                          {
                                                              Text = fileItem.Owner
                                                          };
            owner.SubItems.Add(ownerValue);
            owner.SubItems.Add("No");
            BeginInvoke(addListViewItemDelegate, new object[] { owner });

            /* Flash */
            var flash = new ListViewItem("Embedded Flash");

            if (FlashDetector.ContainsEmbeddedFlash(fileItem.AbsolutePath))
            {
                var flashValue = new ListViewItem.ListViewSubItem
                {
                    Text = "Embedded Flash Detected"
                };

                flash.SubItems.Add(flashValue);
            }
            else
            {
                var flashValue = new ListViewItem.ListViewSubItem
                {
                    Text = "Clean"
                };

                flash.SubItems.Add(flashValue);
            }

            BeginInvoke(addListViewItemDelegate, new object[] { flash });
        }

        public delegate void addLVI(ListViewItem lvi);

        private void AddListViewItem(ListViewItem lvi)
        {
            listViewAnalysis.Items.Add(lvi);
        }

        private void toolStripButtonOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.Reset();
            openFileDialog.ShowDialog(this);
            if (openFileDialog.FileName.Length > 0)
            {
                OpenFile(openFileDialog.FileName);
                ScanFile();
            }
        }

        private void backgroundWorkerPopulate_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            double totalPoints = 0;

            /* The total number of points must be summed first so that percentages can be used later */
            foreach (var extension in fileItem.TridExtensions)
            {
                totalPoints += extension.Points;
            }

            foreach (var extension in fileItem.TridExtensions)
            {
                var lvi = new ListViewItem();
                double percentage = (extension.Points * 100) / totalPoints;
                double roundedPercentage = Math.Round(percentage, 1);
                lvi.Text = string.Format("{0}%", roundedPercentage);

                var lvsiExt = new ListViewItem.ListViewSubItem
                {
                    Text = extension.Name
                };
                lvi.SubItems.Add(lvsiExt);

                var lvsiDescription = new ListViewItem.ListViewSubItem
                {
                    Text = extension.Description
                };
                lvi.SubItems.Add(lvsiDescription);

                listViewFileTypes.Items.Add(lvi);
            }

            toolStripInspector.Enabled = true;
            toolStripButtonRefresh.Enabled = true;
            toolStripButtonSums.Enabled = true;
            toolStripButtonDelete.Enabled = true;
            toolStripSplitButtonview.Enabled = true;

            progressBarTaskProgress.Style = ProgressBarStyle.Blocks;
            toolStripStatusLabelScan.Text = "File Scan Complete";
        }

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
            OpenFile(fileItem.AbsolutePath);
            ScanFile();
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            TaskDialogResult res;

            using (var td = new TaskDialog())
            {
                TaskDialogStandardButtons button = TaskDialogStandardButtons.None;
                button |= TaskDialogStandardButtons.Yes;
                button |= TaskDialogStandardButtons.No;
                td.StartupLocation = TaskDialogStartupLocation.CenterOwner;
                td.OwnerWindowHandle = this.Handle;

                td.Icon = TaskDialogStandardIcon.Information;

                const string Title = "Delete File";
                string instruction = "The file '" + fileItem.Name + "' will be permanently deleted";
                const string Content = "Do you want to continue?";

                td.StandardButtons = button;
                td.InstructionText = instruction;
                td.Caption = Title;
                td.Text = Content;

                res = td.Show();
            }

            if (res == TaskDialogResult.Yes)
            {
                try
                {
                    File.Delete(fileItem.AbsolutePath);
                }
                catch (Exception deleteFileException)
                {
                    MessageBox.Show("The file could not be deleted." + Environment.NewLine + "Detail: " + deleteFileException.Message, "EduSweep 2", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
                finally
                {
                    Close();
                }
            }
        }

        private void openWithNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("notepad.exe", fileItem.AbsolutePath);
            }
            catch (Exception startProcessException)
            {
                MessageBox.Show("The file could not be opened." + Environment.NewLine + "Detail: " + startProcessException.Message, "EduSweep 2", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void toolStripSplitButtonview_ButtonClick(object sender, EventArgs e)
        {
            var fileHandlerProcessInfo = new ProcessStartInfo
            {
                FileName = fileItem.AbsolutePath,
                ErrorDialog = false
            };

            var fileHandlerProcess = new Process
            {
                StartInfo = fileHandlerProcessInfo
            };

            using (fileHandlerProcess)
            {
                try
                {
                    fileHandlerProcess.Start();
                }
                catch (Exception startProcessException)
                {
                    MessageBox.Show("The file could not be opened." + Environment.NewLine + "Detail: " + startProcessException.Message, "EduSweep 2", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void toolStripButtonSums_Click(object sender, EventArgs e)
        {
            var sums = new Checksums(fileItem);
            sums.ShowDialog(this);
        }
    }
}
