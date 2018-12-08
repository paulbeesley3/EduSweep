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

namespace EduSweep_2.Forms
{
    public partial class AddSignature : Form
    {
        private Signature selectedSignature;
        private List<Signature> availableSignatures = new List<Signature>();
        private SignatureType sigType = SignatureType.ALL;

        public AddSignature()
        {
            InitializeComponent();
        }

        public Signature GetSelectedSignature()
        {
            return selectedSignature;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
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
        }

        private void LoadSignatureList()
        {
            availableSignatures = SignatureManager.GetSignatureList(sigType);

            comboBoxSignatures.DataSource = null;
            comboBoxSignatures.Items.Clear();
            comboBoxSignatures.DataSource = availableSignatures;
            comboBoxSignatures.DisplayMember = "Name";
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (comboBoxSignatures.Items.Count > 0)
            {
                selectedSignature = (Signature)comboBoxSignatures.SelectedItem;
                if (selectedSignature == null)
                {
                    return;
                }

                textBoxDescription.Text = selectedSignature.Description;
                labelDetectionCount.Text =
                    string.Format("Signature contains {0} element(s).", selectedSignature.Elements.Count);
                buttonAdd.Enabled = true;
            }
            else
            {
                textBoxDescription.Clear();
                labelDetectionCount.Text = "No signatures matched the search criteria.";
                buttonAdd.Enabled = false;
            }
        }

        private void comboBoxSignatures_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedSignature = (Signature)comboBoxSignatures.SelectedItem;
            UpdateUI();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButtonAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonAll.Checked)
            {
                sigType = SignatureType.ALL;
                LoadSignatureList();
            }
        }

        private void radioButtonBuiltin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBuiltin.Checked)
            {
                sigType = SignatureType.BUILTIN;
                LoadSignatureList();
            }    
        }

        private void radioButtonCustom_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonCustom.Checked)
            {
                sigType = SignatureType.CUSTOM;
                LoadSignatureList();
            }
        }
    }
}
