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

namespace EdUtils.Types
{
    /// <summary>
    /// Represents a file extension
    /// </summary>
    [Serializable]
    public class Extension
    {
        /// <summary>
        /// The name of the extension without a dot
        /// e.g. "txt"
        /// </summary>
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The name of the extension including the leading dot
        /// e.g. ".txt"
        /// </summary>
        [JsonIgnore]
        public string DottedName
        {
            get { return string.Format(".{0}", Name); }
        }

        public Extension()
        {
            /* Required for deserialization support */
        }

        /// <summary>
        /// Create a new Extension instance
        /// </summary>
        /// <param name="name">The extension name (e.g. "txt").
        /// Note that the name can be provided both with and without the
        /// leading dot character.
        /// </param>
        public Extension(string name) : this()
        {
            var components = name.Trim('.').Split('.');

            if (components.Length == 0)
            {
                this.Name = string.Empty;
            }

            string last = components[components.Length - 1];
            this.Name = last.ToLower();
        }
    }
}
