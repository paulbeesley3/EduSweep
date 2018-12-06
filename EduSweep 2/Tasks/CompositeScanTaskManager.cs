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
using EduEngine.Tasks;
using NLog;

namespace EduSweep_2.Tasks
{
    public static class CompositeScanTaskManager
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get a list of CompositeScanTask instances, each representing a task.
        /// </summary>
        public static List<CompositeScanTask> GetTaskList()
        {
            var tasks = new List<CompositeScanTask>();

            foreach (ScanTask task in ScanTaskManager.GetTaskList())
            {
                tasks.Add(new CompositeScanTask(task));
            }

            return tasks;
        }

        /// <summary>
        /// Get a single ScanTask.
        /// </summary>
        /// <param name="guid">Unique identifer of the task.</param>
        /// <returns>CompositeScanTask instance corresponding to the GUID.</returns>
        public static CompositeScanTask GetTask(Guid guid)
        {
            ScanTask task = ScanTaskManager.GetTask(guid);
            return new CompositeScanTask(task);
        }
    }
}
