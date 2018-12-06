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
using System.Text;
using System.Text.RegularExpressions;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Signatures;
using NLog;

namespace EduEngine.Detectors
{
    public class KeywordDetector : IDetector
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private Regex regexp;
        private List<KeywordSignatureElement> elements = new List<KeywordSignatureElement>();

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
                    logger.Trace("Loading element {0}", element.Name);
                    this.elements.Add((KeywordSignatureElement)element);
                }

                regexp = InitializeRegex();
                logger.Debug("Keyword regex initialized as {0}", regexp.ToString());

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

            if (regexp.IsMatch(file.Name.ToLower()))
            {
                logger.Trace("Keyword match on {0}", file.AbsolutePath);
                return (true, new Detection(this.Type, this.Name));
            }

            return (false, null);
        }

        /*
         * Create a single regluar expression from the list of keywords
         */
        private Regex InitializeRegex()
        {
            string regexString;
            var builder = new StringBuilder(@".*");

            if (elements.Count == 0)
            {
                string message = "Attempted to construct regex without elements";
                logger.Error(message);
                throw new Exception(message);
            }

            foreach (var element in elements)
            {
                builder.AppendFormat("{0}|", element.Word);
            }

            /* Remove trailing pipe character */
            builder.Remove(builder.Length - 1, 1);

            builder.Append(".+");
            regexString = builder.ToString();
            
            if (regexString.Length < 1 && regexString.Equals(@".*.+"))
            {
                string message = "Empty regex constructed despite elements being present";
                logger.Error(message);
                throw new Exception(message);
            }

            return new Regex(regexString, RegexOptions.Compiled | RegexOptions.CultureInvariant);
        }
    }
}
