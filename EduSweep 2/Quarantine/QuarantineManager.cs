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
using System.Linq;
using EdUtils.Filesystem;
using EdUtils.Types;
using Newtonsoft.Json;
using NLog;

namespace EduSweep_2.Quarantine
{
    /// <summary>
    /// Provides functions used to manage files in quarantine.
    /// </summary>
    public static class QuarantineManager
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Get the number of files in quarantine.
        /// </summary>
        /// <returns></returns>
        public static int GetCount()
        {
            return GetFileItemList().Count;
        }

        /// <summary>
        /// Get the total size of the quarantine files, in bytes.
        /// </summary>
        /// <returns></returns>
        public static long GetTotalSize()
        {
            long totalSize = 0;

            foreach (QuarantineFileItem file in GetFileItemList())
            {
                totalSize += file.Length;
            }

            return totalSize;
        }

        /// <summary>
        /// Get a list of QuarantineFileItem instances, each representing a file in quarantine.
        /// </summary>
        /// <returns></returns>
        public static List<QuarantineFileItem> GetFileItemList()
        {
            var quarantineFiles = new List<QuarantineFileItem>();

            var di = new DirectoryInfo(AppFolders.QuarantineFolder);
            foreach (FileInfo file in di.GetFiles("*.json", SearchOption.TopDirectoryOnly))
            {
                quarantineFiles.Add(LoadFileItem(file));
            }

            return quarantineFiles;
        }

        public static QuarantineFileItem GetFileItem(string name)
        {
            List<QuarantineFileItem> quarantineFiles = GetFileItemList();

            var matchingFiles = from file in quarantineFiles
                                where file.Name == name
                                select file;

            /* More than one matching file is a bad sign as every file should have a unique name. */
            if (matchingFiles.Count() > 1)
            {
                logger.Warn(string.Format("Multiple matches ({0}) for '{1}' in quarantine.", matchingFiles.Count(), name));
            }

            var di = new DirectoryInfo(AppFolders.QuarantineFolder);
            foreach (FileInfo file in di.GetFiles("*.json", SearchOption.TopDirectoryOnly))
            {
                if (file.Name.ToLower().Equals(name.ToLower() + ".json"))
                {
                    return LoadFileItem(file);
                }
            }

            logger.Error("Quarantine file with name '{0}' was not found.", name);
            return null;
        }

        /// <summary>
        /// Move a file from a location on disk into the quarantine folder.
        /// </summary>
        /// <param name="file">FileInfo instance representing the file to be moved.</param>
        public static void ImportFile(FileInfo file)
        {
            var quarantineFile = new QuarantineFileItem(file);

            try
            {
                File.Move(file.FullName, quarantineFile.AbsolutePath);
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    string.Format("Quarantine file move failed for '{0}'", file.FullName));
                throw;
            }

            try
            {
                /* Serialize and save the metadata file. */
                quarantineFile.Save(AppFolders.QuarantineFolder);
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    string.Format("Quarantine metadata file creation failed in '{0}'", AppFolders.QuarantineFolder));

                logger.Debug("Moving file back to {0}", file.FullName);
                File.Move(quarantineFile.AbsolutePath, file.FullName);
                logger.Debug("File restore succeeded");

                throw;
            }
        }

        public static void ImportFile(FileItem file)
        {
            FileInfo info;

            try
            {
                info = new FileInfo(file.AbsolutePath);
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    string.Format("Failed to get FileInfo for '{0}'", file.AbsolutePath));
                throw;
            }

            ImportFile(info);
        }

        /// <summary>
        /// Remove a file from quarantine and delete its associated metadata.
        /// </summary>
        /// <param name="file"></param>
        public static void RemoveFile(QuarantineFileItem file, bool metadataOnly)
        {
            try
            {
                if (!metadataOnly)
                {
                    File.Delete(file.AbsolutePath);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error deleting file from quarantine: {0}", file.AbsolutePath);
                throw;
            }

            try
            {
                File.Delete(file.MetadataFilePath);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error deleting quarantine metadata: {0}", file.MetadataFilePath);
                throw;
            }
        }

        public static void RestoreFile(QuarantineFileItem file)
        {
            try
            {
                File.Move(file.AbsolutePath, file.OriginalAbsolutePath);
                File.Delete(file.MetadataFilePath);
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    string.Format("Quarantine removal failed for '{0}'", file.Name));
                throw;
            }
        }

        /// <summary>
        /// Remove all files from quarantine that are older than the threshold.
        /// </summary>
        public static void PurgeExpiredFiles(int ageThresholdDays)
        {
            var expiredFiles = from file in GetFileItemList()
                               where file.Age.Ticks > (ageThresholdDays * TimeSpan.TicksPerDay)
                               select file;

            foreach (var file in expiredFiles)
            {
                RemoveFile(file, false);
            }
        }

        /// <summary>
        /// Remove metadata files where the associated file is missing.
        /// </summary>
        public static void PurgeUntrackedFiles()
        {
            foreach (var file in GetFileItemList())
            {
                if (!File.Exists(file.AbsolutePath))
                {
                    RemoveFile(file, true);
                }
            }
        }

        /// <summary>
        /// Create a QuarantineFileItem instance by deserializing a JSON representation on disk.
        /// </summary>
        /// <param name="file">FileInfo instance representing the serialized QuarantineFileItem on disk.</param>
        /// <returns></returns>
        private static QuarantineFileItem LoadFileItem(FileInfo file)
        {
            string json;

            using (var fileReader = new StreamReader(file.FullName, true))
            {
                json = fileReader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<QuarantineFileItem>(json, SerializerSettings.Settings);
        }
    }
}
