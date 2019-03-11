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
using NLog;

namespace EduEngine.Detectors
{
    public class KeywordDetector : IDetector
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private List<string> keywords = new List<string>();

        public string Name => "Keyword";

        public DetectionType Type { get; } = DetectionType.KEYWORD;

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
                foreach (var element in matchingElements)
                {
                    if (element is KeywordSignatureElement keywordElement)
                    {
                        logger.Trace("Loading element {0}", element.Name);
                        keywords.Add(keywordElement.Word);
                    }
                }

                this.Status = DetectorStatus.INITIALIZED;
            }
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

            var matches = keywords.Where(x => file.Name.ToLower().Contains(x)).ToList();

            if (matches.Count > 0)
            {
                var matchSummary = string.Join(",", matches);
                logger.Trace("Keyword match on {0}", file.AbsolutePath);
                return (true, new Detection(this.Type, this.Name, string.Format("Keywords: {0}", matchSummary)));
            }

            return (false, null);
        }
    }
}
