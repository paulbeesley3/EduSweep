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
using System.Collections.Generic;
using EdUtils.Helpers;
using EdUtils.Types;
using Newtonsoft.Json;

namespace EduEngine.Signatures
{
    [Serializable]
    public class Signature : SerializableObject
    {
        [JsonProperty]
        public string Description { get; set; } = string.Empty;

        [JsonProperty]
        public string Category { get; set; } = "Uncategorised";

        /// <summary>
        /// Used for combining the Category and Name properties in a bound drop-down list
        /// </summary>
        [JsonIgnore]
        public string DisplayName => string.Format("[{0}] {1}", Category, Name);

        [JsonIgnore]
        public string FileName => string.Format("{0}{1}", this.Guid, ".json");

        [JsonProperty]
        public List<string> Tags { get; set; } = new List<string>();

        [JsonProperty]
        public List<SignatureElement> Elements { get; private set; } = new List<SignatureElement>();

        public override string Serialize()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };

            return JsonConvert.SerializeObject(this, serializerSettings);
        }

        [JsonConstructor]
        public Signature()
        {
            this.Creator = Utils.GetCurrentUserName();
            this.CreationTime = DateTime.Now;
            this.LastWriteTime = DateTime.Now;
        }

        public Signature(string name) : this()
        {
            this.Name = name;
        }

        public Signature(string name, List<SignatureElement> elements) : this(name)
        {
            this.Elements = elements;
        }
    }
}
