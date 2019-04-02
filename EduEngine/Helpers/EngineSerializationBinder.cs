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
using Newtonsoft.Json.Serialization;

namespace EduEngine.Helpers
{
    public class EngineSerializationBinder : ISerializationBinder
    {
        public Type BindToType(string assemblyName, string typeName)
        {
            switch (typeName)
            {
                /* These types retain the EdUtils version for backwards compatibility */

                case "EduEngine.Signatures.SignatureType":
                case "EdUtils.Signatures.SignatureType":
                    return typeof(EduEngine.Signatures.SignatureType);

                case "EduEngine.Signatures.SignatureElement":
                case "EdUtils.Signatures.SignatureElement":
                    return typeof(EduEngine.Signatures.SignatureElement);

                case "EduEngine.Signatures.ExtensionSignatureElement":
                case "EdUtils.Signatures.ExtensionSignatureElement":
                    return typeof(EduEngine.Signatures.ExtensionSignatureElement);

                case "EduEngine.Signatures.HashSignatureElement":
                case "EdUtils.Signatures.HashSignatureElement":
                    return typeof(EduEngine.Signatures.HashSignatureElement);

                case "EduEngine.Signatures.KeywordSignatureElement":
                case "EdUtils.Signatures.KeywordSignatureElement":
                    return typeof(EduEngine.Signatures.KeywordSignatureElement);
            }

            return null;
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.FullName;
        }
    }
}
