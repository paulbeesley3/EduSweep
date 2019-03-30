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
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Principal;
using NLog;

namespace EdUtils.Helpers
{
    /* Provides a set of utility methods that do not belong to any particular class */
    public class Utils
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public enum FileSizeClass
        {
            BYTE, KBYTE, MBYTE, GBYTE
        }

        public static double BytesFromArbitrarySize(long size, FileSizeClass type)
        {
            switch (type)
            {
                case FileSizeClass.BYTE:
                    return size;
                case FileSizeClass.KBYTE:
                    return size * 1024d;
                case FileSizeClass.MBYTE:
                    return size * 1024d * 1024d;
                case FileSizeClass.GBYTE:
                    return size * 1024d * 1024d * 1024d;
                default:
                    return 0;
            }
        }

        public static int CalculateProgressPercentage(double amountDone, double amountToDo)
        {
            double progress = (amountDone * 100) / amountToDo;
            int intProgress = Convert.ToInt32(progress);

            if (intProgress > 100)
            {
                intProgress = 100;
            }

            return intProgress;
        }

        public static FileSizeClass GetFileSizeClass(long sizeInBytes)
        {
            if (sizeInBytes >= Math.Pow(1024, 3))
            {
                return FileSizeClass.GBYTE;
            }

            if (sizeInBytes >= Math.Pow(1024, 2))
            {
                return FileSizeClass.MBYTE;
            }

            if (sizeInBytes >= 1024)
            {
                return FileSizeClass.KBYTE;
            }
            
            return FileSizeClass.BYTE;
        }

        public static string GetDynamicFileSize(long sizeInBytes)
        {
            var sizeClass = GetFileSizeClass(sizeInBytes);

            if (sizeClass == FileSizeClass.GBYTE)
            {
                double sizeInGB = sizeInBytes / Math.Pow(1024, 3);
                return sizeInGB.ToString("n2") + " GB";
            }

            if (sizeClass == FileSizeClass.MBYTE)
            {
                double sizeInMB = sizeInBytes / Math.Pow(1024, 2);
                return sizeInMB.ToString("n1") + " MB";
            }

            if (sizeClass == FileSizeClass.KBYTE)
            {
                double sizeInKB = sizeInBytes / 1024;
                return sizeInKB.ToString("n0") + " KB";
            }

            /* No conversion needed */
            if (sizeInBytes == 1)
            {
                return sizeInBytes + " byte";
            }
            else
            {
                return sizeInBytes + " bytes";
            }
        }

        public static string GetDynamicFileSize(string filePath)
        {
            var info = new FileInfo(filePath);
            return GetDynamicFileSize(info.Length);
        }

        public static string GetCurrentUserName()
        {
            WindowsIdentity identity = null;
            try
            {
                identity = WindowsIdentity.GetCurrent();
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Couldn't get WindowsIdentity; using fallback.");
            }
            
            if (identity == null)
            {
                return string.Format(
                    "{0}\\{1}",
                    Environment.UserDomainName,
                    Environment.UserName);
            }

            return identity.Name;
        }

        public static byte[] HexStringToByteArray(string str)
        {
            return SoapHexBinary.Parse(str).Value;
        }

        public static string ByteArrayToHexString(byte[] value)
        {
            return new SoapHexBinary(value).ToString();
        }
    }
}
