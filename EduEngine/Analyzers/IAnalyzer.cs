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

using System.Collections.Generic;
using EdUtils.Filesystem;

namespace EduEngine.Analyzers
{
    public interface IAnalyzer
    {
        /// <summary>
        /// The name of the analyzer.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Perform any required initialization to prepare the analyzer
        /// for use.
        /// </summary>
        /// <remarks>Must be called before using Scan().</remarks>
        void Initialize();

        /// <summary>
        /// Analyze a file and return an AnalyserResult instance.
        /// </summary>
        /// <param name="file">The file to analyze.</param>
        /// <returns>
        /// An AnalyserResult instance containing properties that the analyzer
        /// detected for the given file.
        /// </returns>
        AnalyzerResult Analyze(FileItem file);
    }
}
