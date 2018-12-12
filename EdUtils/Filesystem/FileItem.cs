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
using EdUtils.Detections;
using EdUtils.Helpers;
using EdUtils.TrID;
using EdUtils.Types;
using Newtonsoft.Json;
using NLog;

namespace EdUtils.Filesystem
{
    /*
     * Representation of a file that will be, or has been, examined by
     * one or more detectors.
     */
    [Serializable]
    public class FileItem : SerializableObject
    {
        [JsonProperty]
        public Extension Extension { get; set; }

        /* Information from analysis via TrID */
        [JsonProperty]
        public List<TridExtension> TridExtensions { get; set; } = new List<TridExtension>();

        /* List of detections from detectors that found a match for the file */
        [JsonProperty]
        public List<Detection> Detections { get; set; } = new List<Detection>();

        [JsonProperty]
        public string AbsolutePath { get; set; }

        [JsonProperty]
        public string ParentDirectoryPath { get; set; }

        [JsonProperty]
        public FileAttributes Attributes { get; private set; }

        [JsonIgnore]
        public string AttributesAsText
        {
            get
            {
                string attributes = Attributes.ToString();
                return string.Equals(attributes, "False") ? "None" : attributes;
            }
        }

        [JsonIgnore]
        public string RootLocation
        {
            get
            {
                try
                {
                    var root = new Uri(string.Format("file://{0}", AbsolutePath));
                    if (root.Host != string.Empty)
                    {
                        return root.Host;
                    }

                    return Environment.MachineName;
                }
                catch
                {
                    return "Indeterminate";
                }
            }
        }

        [JsonProperty]
        public DateTime LastAccessTime { get; private set; }

        [JsonIgnore]
        public string LastAccessTimeAsText
        {
            get
            {
                return string.Format(
                "{0} at {1}", 
                LastAccessTime.ToLongDateString(),
                LastAccessTime.ToShortTimeString());
            }
        }

        [JsonProperty]
        public string Owner { get; set; }

        [JsonIgnore]
        public string MIMEType
        {
            get { return MIMETypes.GetMIMEType(AbsolutePath); }
        }

        [JsonProperty]
        public long Length { get; private set; }

        [JsonIgnore]
        public string LengthAsText => Utils.GetDynamicFileSize(this.Length);

        [JsonConstructor]
        public FileItem()
        {
            /* Used only for deserialization */
        }

        public FileItem(FileInfo info)
        {
            this.Name = info.Name;
            this.Extension = new Extension(info.Extension);
            this.Length = info.Length;
            this.Creator = this.Owner;
            this.CreationTime = info.CreationTime;
            this.LastAccessTime = info.LastAccessTime;
            this.LastWriteTime = info.LastWriteTime;
            this.AbsolutePath = info.FullName;
            this.ParentDirectoryPath = info.DirectoryName;
            this.Attributes = info.Attributes;
        }
    }
}
