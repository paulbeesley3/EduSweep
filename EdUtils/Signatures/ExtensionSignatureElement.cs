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
using EdUtils.Detections;
using EdUtils.Types;
using Newtonsoft.Json;

namespace EdUtils.Signatures
{
    public class ExtensionSignatureElementComparer : IEqualityComparer<ExtensionSignatureElement>
    {
        public bool Equals(ExtensionSignatureElement x, ExtensionSignatureElement y)
        {
            return x.Extension.Name.Equals(y.Extension.Name);
        }

        public int GetHashCode(ExtensionSignatureElement obj)
        {
            return obj.Extension.GetHashCode();
        }
    }

    [Serializable]
    public class ExtensionSignatureElement : SignatureElement
    {
        [JsonProperty]
        public Extension Extension { get; private set; }

        [JsonIgnore]
        public override string ContentAsText => this.Extension.Name;

        public ExtensionSignatureElement()
        {
            /* Required for deserialization support */
        }

        public ExtensionSignatureElement(Extension extension) : base(DetectionType.EXTENSION)
        {
            this.Name = extension.Name;
            this.Extension = extension;
        }
    }
}
