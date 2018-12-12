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
using EdUtils.Detections;
using EdUtils.Helpers;
using EdUtils.Types;
using Newtonsoft.Json;

namespace EdUtils.Signatures
{
    public class SignatureElementComparer : IEqualityComparer<SignatureElement>
    {
        public bool Equals(SignatureElement x, SignatureElement y)
        {
            return x.Guid.Equals(y.Guid);
        }

        public int GetHashCode(SignatureElement obj)
        {
            return obj.Guid.GetHashCode();
        }
    }

    [Serializable]
    public class SignatureElement : SerializableObject
    {
        [JsonProperty]
        public DetectionType Type { get; private set; }

        [JsonIgnore]
        public virtual string ContentAsText { get; }

        [JsonConstructor]
        public SignatureElement()
        {
            /* Used only for deserialization */
        }

        public SignatureElement(DetectionType type) : this()
        {
            this.Type = type;
            this.Creator = Utils.GetCurrentUserName();
        }
    }
}
