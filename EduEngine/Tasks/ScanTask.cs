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
using EduEngine.Events;
using EduEngine.Helpers;
using EduEngine.Scanner;
using EduEngine.Signatures;
using EdUtils.Filesystem;
using EdUtils.Helpers;
using EdUtils.Types;
using Newtonsoft.Json;

namespace EduEngine.Tasks
{
    [Serializable]
    public class ScanTask : SerializableObject
    {
        public event EventHandler<StatusChangedArgs> StatusChanged;

        [JsonIgnore]
        private ScanStatus privateStatus;

        [JsonProperty]
        public DateTime LastStartTime { get; set; }

        [JsonIgnore]
        public string LastStartTimeAsText
        {
            get
            {
                if (LastStartTime == DateTime.MinValue)
                {
                    return "Never Started";
                }

                return string.Format(
                "{0} at {1}",
                LastStartTime.ToShortDateString(),
                LastStartTime.ToShortTimeString());
            }
        }

        [JsonProperty]
        public DateTime LastCompletionTime { get; set; }

        [JsonIgnore]
        public string LastCompletionTimeAsText
        {
            get
            {
                if (LastCompletionTime == DateTime.MinValue)
                {
                    return "Never Completed";
                }

                return string.Format(
                "{0} at {1}",
                LastCompletionTime.ToShortDateString(),
                LastCompletionTime.ToShortTimeString());
            }
        }

        [JsonProperty]
        public string LastRunOwner { get; set; } = string.Empty;

        [JsonIgnore]
        public TimeSpan Duration => LastCompletionTime - LastStartTime;

        [JsonIgnore]
        public string DurationAsText => string.Format("{0:%d} day(s)", Duration);

        /* Scanner-specific configuration options */
        [JsonProperty]
        public ParallelLevel ParallelLevel { get; set; } = ParallelLevel.FULL;

        [JsonProperty]
        public bool UseClamAV { get; set; } = true;

        /* Top-level folders that will be scanned */
        [JsonProperty]
        public List<DirectoryItem> TargetDirectories { get; set; } = new List<DirectoryItem>();

        /* Signature elements used for the scan */
        [JsonProperty]
        public List<SignatureElement> Elements { get; set; } = new List<SignatureElement>();

        [JsonProperty]
        public List<string> Tags { get; set; } = new List<string>();

        public override string Serialize()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };

            return JsonConvert.SerializeObject(this, serializerSettings);
        }

        [JsonIgnore]
        public ScanStatus Status
        {
            get
            {
                return this.privateStatus;
            }

            set
            {
                this.privateStatus = value;
                StatusChanged?.Invoke(this, new StatusChangedArgs(value));
            }
        }

        [JsonConstructor]
        private ScanTask()
        {
            /* Required for deserialization support */
        }

        public ScanTask(string name)
        {
            this.Name = name;
            this.Creator = Utils.GetCurrentUserName();
            this.CreationTime = DateTime.Now;
            this.LastWriteTime = DateTime.Now;
            this.privateStatus = ScanStatus.UNINITIALZED;
        }

        public ScanTask(string name, List<DirectoryItem> folders) : this(name)
        {
            this.TargetDirectories = folders;
        }

        public ScanTask Clone()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto,
                SerializationBinder = new EngineSerializationBinder()
            };

            string jsonCopy = JsonConvert.SerializeObject(this, serializerSettings);
            return JsonConvert.DeserializeObject<ScanTask>(jsonCopy, serializerSettings);
        }
    }
}
