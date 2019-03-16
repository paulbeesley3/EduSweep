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

namespace EdUtils.Filesystem
{
    public class DirectoryItem : IEquatable<DirectoryItem>
    {
        [JsonProperty]
        public string Path { get; private set; } = string.Empty;

        [JsonProperty]
        public bool Recursive { get; set; } = true;

        [JsonIgnore]
        public PathType PathType
        {
            get { return Paths.GetType(this.Path); }
        }

        public DirectoryItem()
        {
            /* Required for deserialization support */
        }

        public DirectoryItem(string path)
        {
            this.Path = path;
        }

        public bool Equals(DirectoryItem other)
        {
            return other.Path == this.Path;
        }
    }
}
