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
using System.IO;
using EduEngine.Tasks;
using EdUtils.Filesystem;
using EdUtils.Types;
using Newtonsoft.Json;
using NLog;

namespace EduSweep_2.Tasks
{
    public static class ScanTaskManager
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the number of stored scan tasks.
        /// </summary>
        public static int GetCount()
        {
            return GetTaskList().Count;
        }

        /// <summary>
        /// Get a list of ScanTask instances, each representing a task.
        /// </summary>
        public static List<ScanTask> GetTaskList()
        {
            var taskList = new List<ScanTask>();

            var di = new DirectoryInfo(AppFolders.TaskFolder);
            foreach (FileInfo file in di.GetFiles("*.json", SearchOption.TopDirectoryOnly))
            {
                taskList.Add(LoadScanTask(file));
            }

            return taskList;
        }

        /// <summary>
        /// Get a single ScanTask.
        /// </summary>
        /// <param name="guid">Unique identifer of the task.</param>
        /// <returns>ScanTask instance corresponding to the GUID.</returns>
        public static ScanTask GetTask(Guid guid)
        {
            List<ScanTask> tasks = GetTaskList();
            foreach (ScanTask task in tasks)
            {
                if (task.Guid.Equals(guid))
                {
                    return task;
                }
            }

            throw new FileNotFoundException("Missing scan task");
        }

        /// <summary>
        /// Delete a scan task.
        /// </summary>
        /// <param name="task">The ScanTask instance to be deleted.</param>
        public static void RemoveTask(ScanTask task)
        {
            File.Delete(Path.Combine(AppFolders.TaskFolder, string.Format("{0}.json", task.Guid)));
        }

        /// <summary>
        /// Create a copy of a scan task.
        /// </summary>
        /// <param name="task">The ScanTask instance to be copied.</param>
        /// <param name="path">Optional directory path in which to save the clone.</param>
        /// <returns></returns>
        public static ScanTask CloneTask(ScanTask task, string path = "")
        {
            ScanTask clone = task.Clone();
            clone.Name = string.Format("{0} (Copy)", clone.Name);
            clone.Guid = Guid.NewGuid();
            clone.LastStartTime = new DateTime();
            clone.LastCompletionTime = new DateTime();
            clone.CreationTime = DateTime.Now;
            clone.LastWriteTime = DateTime.Now;
            clone.LastRunOwner = string.Empty;

            if (!string.IsNullOrEmpty(path))
            {
                try
                {
                    clone.Save(path);
                }
                catch (Exception ex)
                {
                    logger.Error(ex, "Failed to save cloned task");
                    throw;
                }
            }
            
            return clone;
        }

        /// <summary>
        /// Create a ScanTask instance by deserializing a JSON representation on disk.
        /// </summary>
        /// <param name="file">FileInfo instance representing the serialized ScanReport on disk.</param>
        /// <returns>A deserialized ScanTask instance.</returns>
        private static ScanTask LoadScanTask(FileInfo file)
        {
            string json;

            using (var fileReader = new StreamReader(file.FullName, true))
            {
                json = fileReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<ScanTask>(json, SerializerSettings.Settings);
        }
    }
}
