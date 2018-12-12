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
using EdUtils.Filesystem;
using Newtonsoft.Json;

namespace EdUtils.Signatures
{
    public class HashSignatureElementComparer : IEqualityComparer<HashSignatureElement>
    {
        public bool Equals(HashSignatureElement x, HashSignatureElement y)
        {
            return x.SHA1.Equals(y.SHA1);
        }

        public int GetHashCode(HashSignatureElement obj)
        {
            return obj.SHA1.GetHashCode();
        }
    }

    [Serializable]
    public class HashSignatureElement : SignatureElement
    {
        [JsonProperty]
        public new string Name { get; private set; }

        [JsonProperty]
        public long Length { get; private set; }

        [JsonProperty]
        public string AbsolutePath { get; private set; }

        [JsonProperty]
        public string SHA1 { get; private set; }

        public HashSignatureElement()
        {
            /* Required for deserialization support */
        }

        public HashSignatureElement(FileItem item, string hashSHA1) : base(DetectionType.HASH)
        {
            this.Name = item.Name;
            this.AbsolutePath = item.AbsolutePath;
            this.Length = item.Length;
            this.SHA1 = hashSHA1;
        }
    }
}
