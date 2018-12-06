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
using System.Runtime.InteropServices;
using EdUtils.Filesystem;
using NLog;

namespace EdUtils.TrID
{
    /*
     * Interop support for TrIDLib
     * EduSweep uses TrIDLib courtesy of Marco Pontello - http://mark0.net/index-e.html
     */
    public class TrIDLib
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private enum TridInfoType
        {
            RESULTCOUNT = 1, FILETYPE = 2, FILEEXT = 3, MATCHPOINTS = 4, VERSION = 1001, DEFCOUNT = 1004
        }

        /* TrIDLib Functions */
        [DllImport("tridlib.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int TrID_Analyze();
        [DllImport("tridlib.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int TrID_LoadDefsPack(string path);
        [DllImport("tridlib.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int TrID_SubmitFileA(string fileName);
        [DllImport("tridlib.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int TrID_GetInfo(int infoType, int infoIndex, [MarshalAs(UnmanagedType.VBByRefStr)] ref string result);

        /*
         * Wrapper function for TridGetFileInfo. Used to abstract string buffer management.
         */
        private static int TridGetInfo(TridInfoType infoType, int infoIndex, ref string result)
        {
            result = new string(Convert.ToChar(0), 4096);

            int ret = TrID_GetInfo((int)infoType, infoIndex, ref result);
            int p = result.IndexOf(Convert.ToChar(0));
            result = result.Substring(0, p);
            return ret;
        }

        /*
         * Returns a sorted list of the most probable file extensions
         */
        public static List<TridExtension> AnalyseFile(FileItem fileItem)
        {
            fileItem.TridExtensions = AnalyseFile(fileItem.AbsolutePath);
            return fileItem.TridExtensions;
        }

        public static List<TridExtension> AnalyseFile(FileInfo fileInfo)
        {
            return AnalyseFile(fileInfo.FullName);
        }

        public static List<TridExtension> AnalyseFile(string filePath)
        {
            var extensions = new List<TridExtension>();
            int extensionCount;
            int tridReturnValue;
            string tridResultString = string.Empty;

            logger.Trace("Loading TrID definitions");
            if (TrID_LoadDefsPack(Path.Combine(AppFolders.ProgramFolder)) == 0)
            {
                return extensions;
            }

            logger.Trace("Submitting file to TrID");
            if (TrID_SubmitFileA(filePath) == 0)
            {
                return extensions;
            }

            logger.Trace("Analyzing file with TrID");
            if (TrID_Analyze() == 0)
            {
                return extensions;
            }

            logger.Trace("Retrieving TrID scan results");
            extensionCount = TridGetInfo(TridInfoType.RESULTCOUNT, 0, ref tridResultString);
            if (extensionCount > 0)
            {
                for (int i = 1; i <= extensionCount; i++)
                {
                    var ext = new TridExtension();

                    /* Get the file extension */
                    tridReturnValue = TridGetInfo(TridInfoType.FILEEXT, i, ref tridResultString);
                    ext.Name = tridResultString.ToLower();

                    /* Get the file type description */
                    tridReturnValue = TridGetInfo(TridInfoType.FILETYPE, i, ref tridResultString);
                    ext.Description = tridResultString;

                    /* Get the points value representing the confidence level */
                    tridReturnValue = TridGetInfo(TridInfoType.MATCHPOINTS, i, ref tridResultString);
                    ext.Points = (uint)tridReturnValue;
                    extensions.Add(ext);
                }
            }

            /* Sort the list by descending order of points before returning it */
            extensions.Sort((x, y) => y.Points.CompareTo(x.Points));
            return extensions;
        }
    }
}
