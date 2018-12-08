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
using System.Windows.Forms;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class AddNetworkPath : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private bool cancelled = false;

        public AddNetworkPath()
        {
            InitializeComponent();
        }

        public string Path
        {
            get
            {
                if (cancelled)
                {
                    logger.Debug("Returning empty path because the dialog was cancelled");
                    return string.Empty;
                }

                logger.Debug("Returning {0]", textBoxPath.Text);
                return textBoxPath.Text;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            cancelled = true;
            logger.Info("Form closed (cancelled)");
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            logger.Info("Form closed (saved)");
            Close();
        }

        private void AddNetworkPath_Load(object sender, EventArgs e)
        {
            ActiveControl = textBoxPath;
            logger.Info("Form opened");
        }

        private void textBoxPath_TextChanged(object sender, EventArgs e)
        {
            buttonAdd.Enabled = textBoxPath.Text.Length > 0;
        }
    }
}
