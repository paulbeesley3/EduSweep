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
using System.Windows.Forms;
using EdUtils.Signatures;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class AddSignature : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private Signature selectedSignature;
        private List<Signature> availableSignatures = new List<Signature>();
        private SignatureType sigType = SignatureType.ALL;

        public AddSignature()
        {
            InitializeComponent();
        }

        public Signature GetSelectedSignature()
        {
            logger.Trace("Selected signature requested");
            return selectedSignature;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            logger.Debug("Closing with no signature selected");
            selectedSignature = null;
            Close();
        }

        private void AddSignature_Load(object sender, EventArgs e)
        {
            if (comboBoxSignatures.Items.Count > 0)
            {
                comboBoxSignatures.SelectedIndex = 0;
                buttonAdd.Enabled = true;
            }

            LoadSignatureList();
            UpdateUI();

            logger.Info("Form opened");
        }

        private void LoadSignatureList()
        {
            availableSignatures = SignatureManager.GetSignatureList(sigType);

            comboBoxSignatures.DataSource = null;
            comboBoxSignatures.Items.Clear();
            comboBoxSignatures.DataSource = availableSignatures;
            comboBoxSignatures.DisplayMember = "DisplayName";

            UpdateUI();
            logger.Debug("Signature list reloaded");
        }

        private void UpdateUI()
        {
            if (comboBoxSignatures.Items.Count > 0)
            {
                logger.Trace("Setting UI element states for populated signature list");
                selectedSignature = (Signature)comboBoxSignatures.SelectedItem;
                if (selectedSignature == null)
                {
                    logger.Trace("No signature selected currently");
                    return;
                }

                textBoxDescription.Text = selectedSignature.Description;
                labelDetectionCount.Text =
                    string.Format("Signature contains {0} element(s).", selectedSignature.Elements.Count);
                buttonAdd.Enabled = true;
            }
            else
            {
                logger.Trace("Setting UI element states for empty signature list");
                textBoxDescription.Clear();
                labelDetectionCount.Text = "No signatures matched the search criteria.";
                buttonAdd.Enabled = false;
            }
        }

        private void comboBoxSignatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSignature = (Signature)comboBoxSignatures.SelectedItem;
            if (selectedSignature != null)
            {
                logger.Trace("Selected signature: {0}", selectedSignature.Name);
                UpdateUI();
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            logger.Debug("Closing with signature selected");
            Close();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked)
            {
                logger.Trace("Loading all signatures");
                sigType = SignatureType.ALL;
                LoadSignatureList();
            }
        }

        private void radioButtonBuiltin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBuiltin.Checked)
            {
                logger.Trace("Loading only builtin signatures");
                sigType = SignatureType.BUILTIN;
                LoadSignatureList();
            }    
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCustom.Checked)
            {
                logger.Trace("Loading only custom signatures");
                sigType = SignatureType.CUSTOM;
                LoadSignatureList();
            }
        }

        private void AddSignature_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Info("Form closed");
        }
    }
}
