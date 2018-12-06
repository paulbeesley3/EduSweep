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
using System.Windows.Forms;
using BrightIdeasSoftware;
using Config.Net;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Settings;
using EdUtils.Signatures;
using NLog;

namespace Signature_Studio.Forms
{
    public partial class FormMain : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        private static IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

        private List<Signature> availableSignatures = new List<Signature>();

        private TypedObjectListView<Signature> typedListViewSignatures;

        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadSignatureList()
        {
            availableSignatures = SignatureManager.GetSignatureList(SignatureType.CUSTOM);
            listViewSignatures.SetObjects(availableSignatures);
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            typedListViewSignatures = new TypedObjectListView<Signature>(listViewSignatures);

            toolStripStatusLabel.Text = AppFolders.CustomSignatureFolder;

            LoadSignatureList();
            SetListViewOverlay();
            SetToolstripButtonStates();
        }

        private void SetListViewOverlay()
        {
            var overlay = listViewSignatures.EmptyListMsgOverlay as TextOverlay;
            overlay.BorderWidth = 0;
            overlay.BackColor = Color.Empty;
            overlay.TextColor = Color.Black;

            listViewSignatures.EmptyListMsg = "No custom signatures have been created yet.";
        }

        private void SetToolstripButtonStates()
        {
            if (listViewSignatures.SelectedItems.Count > 0)
            {
                toolStripButtonEdit.Enabled = true;
                toolStripButtonDelete.Enabled = true;
            }
            else
            {
                toolStripButtonEdit.Enabled = false;
                toolStripButtonDelete.Enabled = false;
            }
        }

        private void listViewSignatures_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetToolstripButtonStates();
        }

        private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
        {
            LoadSignatureList();
            SetToolstripButtonStates();
        }

        private void exitToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void toolStripButtonNew_Click(object sender, System.EventArgs e)
        {
            var editor = new SignatureEditor();
            editor.ShowDialog(this);

            LoadSignatureList();
            SetToolstripButtonStates();
        }

        private void projectHomepageToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Web.LaunchWebBrowser(appSettings.ProjectHomeLink);
        }

        private void reportAnIssueToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Web.LaunchWebBrowser(appSettings.ProjectIssueLink);
        }

        private void documentationToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            Web.LaunchWebBrowser(appSettings.ProjectDocsLink);
        }

        private void toolStripButtonEdit_Click(object sender, System.EventArgs e)
        {
            var selectedSignature = typedListViewSignatures.SelectedObject;

            var editor = new SignatureEditor(selectedSignature);
            editor.ShowDialog(this);

            LoadSignatureList();
            SetToolstripButtonStates();
        }

        private void toolStripButtonDelete_Click(object sender, System.EventArgs e)
        {
            var selectedSignature = typedListViewSignatures.SelectedObject;

            try
            {
                SignatureManager.RemoveSignature(selectedSignature);
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    "Unable to remove signature {0}",
                    selectedSignature.Name);
            }

            LoadSignatureList();
            SetToolstripButtonStates();
        }
    }
}
