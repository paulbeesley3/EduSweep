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

namespace EduEngine.Scanner
{
    /// <summary>
    /// Indicates the mode in which the scanner will examine a file.
    /// </summary>
    internal enum FileScanMode
    {
        /// <summary>
        /// The scanner will examine the file as part of the main
        /// scan process.
        /// </summary>
        DEFAULT,

        /// <summary>
        /// The scanner will examine the file as a post-scan operation,
        /// after the main scan is complete.
        /// </summary>
        POSTSCAN
    }
}
