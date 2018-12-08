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
using System.Reflection;
using System.Windows.Forms;
using NLog;

namespace EduSweep_2.Forms
{
    public partial class About : Form
    {
        private Logger logger = LogManager.GetCurrentClassLogger();

        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {
            var lviAppVersion = new ListViewItem("Main Application");
            var lviLibVersion = new ListViewItem("EdUtils Library");
            var lviEngineVersion = new ListViewItem("EduEngine Library");

            AssemblyName libName = typeof(EdUtils.Filesystem.AppFolders).Assembly.GetName();
            AssemblyName engineName = typeof(EduEngine.Scanner.Scanner).Assembly.GetName();

            var lvsiApp = new ListViewItem.ListViewSubItem(lviAppVersion, Assembly.GetExecutingAssembly().GetName().Version.ToString());
            var lvsiLib = new ListViewItem.ListViewSubItem(lviLibVersion, libName.Version.ToString());
            var lvsiEngine = new ListViewItem.ListViewSubItem(lviEngineVersion, engineName.Version.ToString());

            lviAppVersion.SubItems.Add(lvsiApp);
            lviLibVersion.SubItems.Add(lvsiLib);
            lviEngineVersion.SubItems.Add(lvsiEngine);

            listViewVersions.Items.Add(lviAppVersion);
            listViewVersions.Items.Add(lviLibVersion);
            listViewVersions.Items.Add(lviEngineVersion);

            logger.Info("Form opened");
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            logger.Info("Form closed");
            Close();
        }
    }
}
