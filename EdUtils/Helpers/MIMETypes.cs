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
using System.Runtime.InteropServices;
using NLog;

namespace EdUtils.Helpers
{
    public static class MIMETypes
    {
        [DllImport("urlmon.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = false)]
        private static extern int FindMimeFromData(
            IntPtr bindingCtxPtr,
            [MarshalAs(UnmanagedType.LPWStr)] string fileName,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1, SizeParamIndex = 3)] byte[] buffer,
            int bufferSizeInBytes,
            [MarshalAs(UnmanagedType.LPWStr)] string proposedType,
            int mimeFlags,
            out IntPtr returnedType,
            int reserved);

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        private const int ReadLimit = 4096;

        public static string GetMIMEType(string filePath)
        {
            return GetMIMEType(new FileInfo(filePath));
        }

        /*
         * Read up to 4K from the beginning of a file and use this data to search for
         * its MIME type.
         * 
         * See https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types)
         */
        public static string GetMIMEType(FileInfo file)
        {
            string mime;

            if (!file.Exists || file.Length == 0)
            {
                logger.Error("File does not exist or is empty: {0}", file.FullName);
                return "application/unknown";
            }

            /* Safe cast from long, as the read limit used in Min() is also an int */
            int bytesToRead = (int)Math.Min(file.Length, ReadLimit);

            try
            {
                FileStream fs = File.OpenRead(file.FullName);
                    
                byte[] buf = new byte[bytesToRead];
                fs.Read(buf, 0, bytesToRead);
                fs.Close();
                int result = FindMimeFromData(IntPtr.Zero, file.FullName, buf, bytesToRead, null, 0, out IntPtr mimeout, 0);

                if (result != 0)
                {
                    throw Marshal.GetExceptionForHR(result);
                }

                mime = Marshal.PtrToStringUni(mimeout);
                Marshal.FreeCoTaskMem(mimeout);
                return mime;
            }
            catch
            {
                logger.Error("File could not be read to determine its MIME type: {0}", file.FullName);
                return "application/unknown";
            }
        }
    }
}
