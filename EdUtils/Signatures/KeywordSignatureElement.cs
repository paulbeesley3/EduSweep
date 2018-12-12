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
using Newtonsoft.Json;

namespace EdUtils.Signatures
{
    public class KeywordSignatureElementComparer : IEqualityComparer<KeywordSignatureElement>
    {
        public bool Equals(KeywordSignatureElement x, KeywordSignatureElement y)
        {
            return x.Word.Equals(y.Word);
        }

        public int GetHashCode(KeywordSignatureElement obj)
        {
            return obj.Word.GetHashCode();
        }
    }

    [Serializable]
    public class KeywordSignatureElement : SignatureElement
    {
        [JsonIgnore]
        public new string Name => Word;

        [JsonProperty]
        public string Word { get; private set; }

        public KeywordSignatureElement()
        {
            /* Required for deserialization support */
        }

        public KeywordSignatureElement(string keyword) : base(DetectionType.KEYWORD)
        {
            this.Word = keyword.ToLower();
        }
    }
}
