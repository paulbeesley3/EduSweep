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
using EdUtils.Types;

namespace EdUtils.TrID
{
    /*
     * Represents a potential file extension detected by TrID.
     * Subclasses EdUtils.Types.Extension and adds the Points value which
     * gives the degree of confidence that TrID has in the result.
     */
    [Serializable]
    public class TridExtension : Extension
    {
        public string Description { get; set; }
        public uint Points { get; set; }

        public TridExtension()
        {
            this.Points = 0;
            this.Name = string.Empty;
            this.Description = string.Empty;
        }

        public TridExtension(string name, uint points, string typeName) : this()
        {
            this.Name = name.ToLower();
            this.Points = points;
            this.Description = typeName;
        }
    }
}
