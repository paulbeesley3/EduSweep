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
using Newtonsoft.Json;

namespace EduEngine.Signatures
{
    public class SizeSignatureElementComparer : IEqualityComparer<SizeSignatureElement>
    {
        public bool Equals(SizeSignatureElement x, SizeSignatureElement y)
        {
            return x.Limit.Equals(y.Limit);
        }

        public int GetHashCode(SizeSignatureElement obj)
        {
            return (int)obj.Limit;
        }
    }

    [Serializable]
    public class SizeSignatureElement : SignatureElement
    {
        [JsonIgnore]
        public new string Name
        {
            get
            {
                return string.Format("Files >{0}", Utils.GetDynamicFileSize(Limit));
            }
        }

        [JsonProperty]
        public long Limit { get; private set; }

        public SizeSignatureElement()
        {
            /* Required for deserialization support */
        }

        public SizeSignatureElement(long limit) : base(DetectionType.SIZE)
        {
            this.Limit = limit;
        }
    }
}