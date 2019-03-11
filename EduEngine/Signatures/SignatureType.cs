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

namespace EduEngine.Signatures
{
    /// <summary>
    /// Represents the type of a Signature
    /// </summary>
    [Serializable]
    public enum SignatureType
    {
        /// <summary>
        /// The signature is shipped as part of the default
        /// set provided with the application. Because these
        /// signatures are stored in a read-only location
        /// (by default) they cannot be modified or deleted.
        /// </summary>
        BUILTIN,

        /// <summary>
        /// The signature was created either manually or by
        /// the Signature Studio utility. Custom signatures are
        /// stored in the working directory.
        /// </summary>
        CUSTOM,

        /// <summary>
        /// Used to represent both BUILTIN and CUSTOM types when
        /// enumerating available signatures.
        /// </summary>
        ALL
    }
}
