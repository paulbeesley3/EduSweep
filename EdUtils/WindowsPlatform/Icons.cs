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
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using EdUtils.Filesystem;
using NLog;

namespace EdUtils.WindowsPlatform
{
    /// <summary>
    /// Utility functions for interacting with file icons
    /// </summary>
    public static class Icons
    {
        [DllImport("shell32.dll")]
        private static extern IntPtr ExtractAssociatedIcon(IntPtr handle, StringBuilder iconPath, out ushort iconPointer);

        /// <summary>
        /// Get the icon associated with a file
        /// </summary>
        /// <param name="path">The absolute path to the file</param>
        /// <returns>The file's associated icon</returns>
        public static Icon GetFileIcon(string path)
        {
            var pathBuilder = new StringBuilder(path);
            IntPtr handle = ExtractAssociatedIcon(IntPtr.Zero, pathBuilder, out ushort iconPointer);
            return Icon.FromHandle(handle);
        }

        /// <summary>
        /// Get the icon associated with a FileItem
        /// </summary>
        /// <param name="file">The FileItem instance to get the icon for</param>
        /// <returns>The FileItem's associated icon</returns>
        public static Icon GetFileIcon(FileItem file)
        {
            return GetFileIcon(file.AbsolutePath);
        }

        /// <summary>
        /// Get the Bitmap representation of the icon associated with a file
        /// </summary>
        /// <param name="path">The absolute path to the file</param>
        /// <returns>The file's associated icon as a Bitmap image</returns>
        public static Bitmap GetFileIconImage(string path)
        {
            return GetFileIcon(path).ToBitmap();
        }

        /// <summary>
        /// Get the Bitmap representation of the icon associated with a FileItem
        /// </summary>
        /// <param name="file">The FileItem instance to get the icon for</param>
        /// <returns>The FileItem's associated icon as a Bitmap image</returns>
        public static Bitmap GetFileIconImage(FileItem file)
        {
            return GetFileIcon(file).ToBitmap();
        }
    }
}
