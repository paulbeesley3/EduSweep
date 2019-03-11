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
using System.Linq;
using EduEngine.Signatures;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using NLog;

namespace EduEngine.Detectors
{
    public class HashDetector : IDetector
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private readonly List<HashSignatureElement> elements = new List<HashSignatureElement>();

        public string Name => "Hash";

        public DetectionType Type { get; } = DetectionType.HASH;

        public DetectorStatus Status { get; private set; } = DetectorStatus.UNINITIALIZED;

        public void Initialize(List<SignatureElement> elements)
        {
            logger.Debug("Initializing {0} detector", this.Name);

            var matchingElements = from element in elements
                                   where element.Type == this.Type
                                   select element;

            if (matchingElements.Count() < 1)
            {
                logger.Debug("No matching elements. This detector will not be used.");
                this.Status = DetectorStatus.UNUSED;
            }
            else
            {
                foreach (var signatureElement in matchingElements)
                {
                    logger.Trace("Loading element {0}", signatureElement.Name);
                    this.elements.Add((HashSignatureElement)signatureElement);
                }

                this.Status = DetectorStatus.INITIALIZED;
            }
        }

        public (bool detected, Detection detection) Scan(FileItem file)
        {
            var elementsMatchingSize = new List<HashSignatureElement>();
            string sha1 = string.Empty;

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

            /* First check if any elements match the size of the file being scanned */
            foreach (var element in elements)
            {
                if (element.Length == file.Length)
                {
                    logger.Trace("Size match: {0} matches size of {1}", file.AbsolutePath, element.Name);
                    elementsMatchingSize.Add(element);
                }
            }

            if (elementsMatchingSize.Count > 0)
            {
                sha1 = Checksums.GetChecksumFromFile(file, Checksums.ChecksumType.SHA1);

                foreach (var element in elements)
                {
                    if (sha1.Equals(element.SHA1))
                    {
                        logger.Trace("Exact match: {0} matches hash of {1}", file.AbsolutePath, element.Name);
                        logger.Trace("Matching SHA1 sum was {0}", sha1);
                        return (true, new Detection(this.Type, this.Name, string.Format("Hash matches {0}", element.Name)));
                    }
                }
            }

            return (false, null);
        }
    }
}
