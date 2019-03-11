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
using System.Text;
using EduEngine.Detectors;
using EduEngine.Signatures;
using EdUtils.Detections;
using EdUtils.Filesystem;
using NLog;

namespace EdUtils.Helpers
{
    public class FlashDetector : IDetector
    {
        private const int contentLengthLimit = 1024 * 64;

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public string Name => "Embedded Flash";

        public DetectionType Type => DetectionType.FLASH;

        public DetectorStatus Status { get; private set; } = DetectorStatus.UNINITIALIZED;

        public void Initialize(List<SignatureElement> elements)
        {
            logger.Debug("Initializing {0} detector", this.Name);
            this.Status = DetectorStatus.INITIALIZED;
        }

        public (bool detected, Detection detection) Scan(FileItem file)
        {
            if (this.Status == DetectorStatus.UNUSED)
            {
                logger.Error("{0} detector in use when it should have been pruned", this.Name);
                return (false, null);
            }

            if (this.Status == DetectorStatus.UNINITIALIZED)
            {
                string message = string.Format(
                    "Trying to use the {0} detector while it is uninitialized",
                    this.Name);

                logger.Error(message);
                throw new Exception(message);
            }

            if (ContainsEmbeddedFlash(file))
            {
                logger.Trace("Embedded Flash content in {0}", file.AbsolutePath);
                return (true, new Detection(this.Type, this.Name, "Embedded Flash Content"));
            }

            return (false, null);
        }

        private bool ContainsEmbeddedFlash(FileItem file)
        {
            
            bool buf1Filled = false;
            byte[] buf1 = new byte[contentLengthLimit];
            byte[] buf2 = new byte[contentLengthLimit];
            byte[] compareBuf = new byte[contentLengthLimit * 2];

            logger.Trace("Opening {0} to check for Flash content", file.AbsolutePath);
            using (FileStream fs = File.OpenRead(file.AbsolutePath))
            {
                var temp = new UTF8Encoding(true);
                while (fs.Read(buf2, 0, contentLengthLimit) > 0)
                {
                    if (!buf1Filled)
                    {
                        buf2.CopyTo(buf1, 0);
                        buf1Filled = true;
                    }

                    buf1.CopyTo(compareBuf, 0);
                    buf2.CopyTo(compareBuf, contentLengthLimit - 1);
                    if (temp.GetString(compareBuf).Contains("ShockwaveFlash"))
                    {
                        return true;
                    }

                    buf2.CopyTo(buf1, 0);
                }

                return false;
            }
        }
    }
}
