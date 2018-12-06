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
using Newtonsoft.Json;

namespace EdUtils.Detections
{
    [Serializable]
    public class Detection
    {
        [JsonProperty]
        public DateTime Time { get; private set; }

        [JsonProperty]
        public DetectionType Type { get; private set; }

        [JsonProperty]
        public string DetectorName { get; private set; }

        [JsonProperty]
        public string Detail { get; private set; } = string.Empty;

        public Detection()
        {
            /* Required for deserialization support */
        }

        public Detection(DetectionType type, string detectorName)
        {
            this.Time = DateTime.Now;
            this.Type = type;
            this.DetectorName = detectorName;
        }

        public Detection(DetectionType type, string detectorName, string detail) : this(type, detectorName)
        {
            this.Detail = detail;
        }
    }
}
