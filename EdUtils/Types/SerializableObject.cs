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
using System.IO;
using Newtonsoft.Json;

namespace EdUtils.Types
{
    /// <summary>
    /// Abstract base class for any class that can be serialized 
    /// </summary>
    [Serializable]
    public abstract class SerializableObject
    {
        /// <summary>
        /// Unique identifier for the object. Used for naming when
        /// serializing the object to a file.
        /// </summary>
        [JsonProperty]
        public Guid Guid { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The name of the object
        /// </summary>
        [JsonProperty]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// The name of the user that originally created the object
        /// </summary>
        [JsonProperty]
        public string Creator { get; set; } = string.Empty;

        /// <summary>
        /// The date and time the object was created
        /// </summary>
        [JsonProperty]
        public DateTime CreationTime { get; set; } = DateTime.Now;

        /// <summary>
        /// The date and time that the object was last modified
        /// </summary>
        [JsonProperty]
        public DateTime LastWriteTime { get; set; } = DateTime.Now;

        /// <summary>
        /// String representation of the CreationTime property
        /// </summary>
        [JsonIgnore]
        public string CreationTimeAsText
        {
            get
            {
                if (CreationTime == DateTime.MinValue)
                {
                    return "Unknown";
                }

                return string.Format(
                "{0} at {1}",
                CreationTime.ToShortDateString(),
                CreationTime.ToShortTimeString());
            }
        }

        /// <summary>
        /// String representation of the LastWriteTime property
        /// </summary>
        [JsonIgnore]
        public string LastWriteTimeAsText
        {
            get
            {
                if (LastWriteTime == DateTime.MinValue)
                {
                    return "Never";
                }

                return string.Format(
                "{0} at {1}",
                LastWriteTime.ToShortDateString(),
                LastWriteTime.ToShortTimeString());
            }
        }

        /// <summary>
        /// Convert the object to a JSON, text-based representation
        /// </summary>
        /// <returns>String containing the JSON-serialized object data</returns>
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, SerializerSettings.Settings);
        }

        /// <summary>
        /// Serialize the object and save it to the provided directory path with a unique name.
        /// </summary>
        /// <remarks>The file name is generated automatically.</remarks>
        /// <param name="path">Path to the directory in which the file will be saved.</param>
        public void Save(string path)
        {
            string savePath = Path.Combine(path, string.Format("{0}.json", this.Guid));

            using (var fileWriter = new StreamWriter(savePath, false))
            {
                fileWriter.Write(this.Serialize());
            }
        }

        /// <summary>
        /// Return the Name property as the string value of the object
        /// </summary>
        /// <returns>The Name property of the object</returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
