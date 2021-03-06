﻿#region copyright-header
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
using EdUtils.Filesystem;
using EdUtils.Helpers;
using Newtonsoft.Json;

namespace EduSweep_2.Quarantine
{
    [Serializable]
    public class QuarantineFileItem : FileItem
    {
        [JsonIgnore]
        public string MetadataFilePath
        {
            get
            {
                string filename = Path.GetFileName(
                    string.Format("{0}.{1}", this.Guid.ToString(), "json"));

                return Path.Combine(AppFolders.QuarantineFolder, filename);
            }
        }

        [JsonProperty]
        public string OriginalAbsolutePath { get; private set; }

        [JsonIgnore]
        public string OriginalName
        {
            get
            {
                return Path.GetFileName(this.OriginalAbsolutePath);
            }
        }

        [JsonProperty]
        public string OriginalDirectoryPath { get; private set; }

        [JsonProperty]
        public string OriginalOwner { get; private set; }

        [JsonProperty]
        public DateTime QuarantineDate { get; private set; } = DateTime.Now;

        [JsonIgnore]
        public string QuarantineDateAsText
        {
            get
            {
                return string.Format(
                "{0} at {1}",
                QuarantineDate.ToLongDateString(),
                QuarantineDate.ToShortTimeString());
            }
        }

        [JsonIgnore]
        public TimeSpan Age
        {
            get { return DateTime.Now - this.QuarantineDate; }
        }

        [JsonIgnore]
        public string AgeAsText => string.Format("{0:%d} day(s)", Age);

        public new string ParentDirectoryPath
        {
            get
            {
                return AppFolders.QuarantineFolder;
            }
        }

        public QuarantineFileItem()
        {
            /* Used only for deserialization */
        }

        public QuarantineFileItem(FileInfo info) : base(info)
        {
            this.OriginalAbsolutePath = info.FullName;
            this.OriginalDirectoryPath = info.DirectoryName;
            this.OriginalOwner = Paths.GetOwner(info);

            this.Creator = Utils.GetCurrentUserName();
            this.Owner = this.Creator;

            this.Name = string.Format("{0}{1}", this.Guid.ToString(), this.Extension.DottedName);
            this.AbsolutePath = Path.Combine(AppFolders.QuarantineFolder, this.Name);
        }
    }
}
