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

using System.IO;
using System.Text;
using NLog;

namespace EdUtils.Helpers
{
    public static class FlashDetector
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static bool ContainsEmbeddedFlash(string filePath)
        {
            return ContainsEmbeddedFlash(new FileInfo(filePath));
        }

        public static bool ContainsEmbeddedFlash(FileInfo file)
        {
            const int ChunkSize = 1024 * 64;
            bool buf1Filled = false;
            byte[] buf1 = new byte[ChunkSize];
            byte[] buf2 = new byte[ChunkSize];
            byte[] compareBuf = new byte[ChunkSize * 2];

            logger.Debug("Opening {0} to check for Flash content", file.FullName);
            using (FileStream fs = File.OpenRead(file.FullName))
            {
                var temp = new UTF8Encoding(true);
                while (fs.Read(buf2, 0, ChunkSize) > 0)
                {
                    if (!buf1Filled)
                    {
                        buf2.CopyTo(buf1, 0);
                        buf1Filled = true;
                    }

                    buf1.CopyTo(compareBuf, 0);
                    buf2.CopyTo(compareBuf, ChunkSize - 1);
                    if (temp.GetString(compareBuf).Contains("ShockwaveFlash"))
                    {
                        logger.Trace("Embedded Flash detected in {0}", file.FullName);
                        return true;
                    }

                    buf2.CopyTo(buf1, 0);
                }

                logger.Trace("No Flash detection in {0}", file.FullName);
                return false;
            }
        }
    }
}
