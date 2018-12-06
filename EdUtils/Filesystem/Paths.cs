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
using System.Security.Principal;
using Config.Net;
using EdUtils.Settings;
using NLog;

namespace EdUtils.Filesystem
{
    public static class Paths
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static readonly IAppSettings appSettings = new ConfigurationBuilder<IAppSettings>()
        .UseJsonFile(AppFolders.AppSettingsPath)
        .Build();

        public static bool IsDirectory(string path)
        {
            FileAttributes attributes = File.GetAttributes(path);
            return (attributes & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public static bool IsFile(string path)
        {
            return !IsDirectory(path);
        }

        public static bool IsAccessible(string path)
        {
            path = path.Trim();

            if (path.Length == 0)
            {
                logger.Debug("Path is zero-length");
                return false;
            }

            /* Test for any invalid path characters */
            if (path.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                logger.Debug(string.Format("Path contains invalid characters: {0}", path));
                return false;
            }

            /* Check the path type to determine if further tests can be run */
            switch (GetType(path))
            {
                case PathType.UNKNOWN:
                case PathType.LOCAL:
                case PathType.REMOTE_MAPPED:
                case PathType.REMOTE_UNC:
                    break;

                case PathType.UNAVAILABLE:
                    return false;

                default:
                    return false;
            }

            try
            {
                var dirInfo = new DirectoryInfo(path);
                if (!dirInfo.Exists)
                {
                    logger.Debug(string.Format("Path does not exist: {0}", path));
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.Debug(
                        ex,
                        string.Format("Path accessibilty check failed: {0}", path));
                return false;
            }

            return true;
        }

        public static PathType GetType(string path)
        {
            string root;

            if (path.StartsWith(@"\\") || path.StartsWith(@"//"))
            {
                try
                {
                    var pathUri = new Uri(path);
                    if (pathUri.HostNameType == UriHostNameType.Basic ||
                        pathUri.HostNameType == UriHostNameType.Unknown)
                    {
                        return PathType.LOCAL;
                    }

                    return PathType.REMOTE_UNC;
                }
                catch (UriFormatException ex)
                {
                    logger.Warn(
                        ex,
                        string.Format("URI path type detection failed for: {0}", path));

                    return PathType.UNKNOWN;
                }
            }

            try
            {
                root = Path.GetPathRoot(path);

                var driveInfo = new DriveInfo(root);
                if (driveInfo.DriveType == DriveType.Network)
                {
                    return PathType.REMOTE_MAPPED;
                }

                if (driveInfo.DriveType == DriveType.NoRootDirectory)
                {
                    return PathType.UNAVAILABLE;
                }

                return PathType.LOCAL;
            }
            catch (ArgumentException ex)
            {
                logger.Warn(
                        ex,
                        string.Format("Local path type detection failed for: {0}", path));
                return PathType.UNKNOWN;
            }
        }

        public static string GetOwner(FileInfo info)
        {
            try
            {
                return info.GetAccessControl().GetOwner(typeof(NTAccount)).Value;
            }
            catch (Exception ex)
            {
                logger.Warn(ex, "Unable to determine ownership information for: {0}", info.FullName);
                return "Unknown";
            }
        }
    }
}
