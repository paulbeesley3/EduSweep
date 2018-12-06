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
using System.IO;
using System.Security.Cryptography;
using System.Text;
using EdUtils.Filesystem;
using Force.Crc32;
using NLog;

namespace EdUtils.Helpers
{
    /// <summary>
    /// Utility functions for working with checksums
    /// </summary>
    public class Checksums
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public enum ChecksumType
        {
            CRC32, MD5, SHA1
        }

        private static string GetCRC32SumFromFile(string fileName)
        {
            var crc = new Crc32Algorithm();
            var sb = new StringBuilder();

            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    foreach (byte b in crc.ComputeHash(fs))
                    {
                        sb.Append(b.ToString("x2").ToLower());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    "Error reading file {0} for CRC32 checksum generation",
                    fileName);
                throw;
            }

            return sb.ToString();
        }

        public static string GetChecksumFromFile(FileItem fileItem, ChecksumType type)
        {
            return GetChecksumFromFile(fileItem.AbsolutePath, type);
        }

        public static string GetChecksumFromFile(FileInfo fileInfo, ChecksumType type)
        {
            return GetChecksumFromFile(fileInfo.FullName, type);
        }

        public static string GetChecksumFromFile(string fileName, ChecksumType type)
        {
            var sb = new StringBuilder();
            HashAlgorithm algo;

            switch (type)
            {
                case ChecksumType.CRC32:
                    return GetCRC32SumFromFile(fileName);
                case ChecksumType.MD5:
                    algo = MD5.Create();
                    break;
                case ChecksumType.SHA1:
                    algo = SHA1.Create();
                    break;
                default:
                    return string.Empty;
            }

            try
            {
                using (FileStream fs = File.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    foreach (byte b in algo.ComputeHash(fs))
                    {
                        sb.Append(b.ToString("x2").ToLower());
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(
                    ex,
                    "Error reading file {0} for checksum generation", 
                    fileName);
                throw;
            }

            logger.Trace("Generated checksum {0} for file {1}", sb.ToString(), fileName);
            return sb.ToString();
        }
    }
}
