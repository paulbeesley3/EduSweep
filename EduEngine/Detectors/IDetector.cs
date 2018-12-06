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
using EduEngine.Scanner;
using EdUtils.Detections;
using EdUtils.Filesystem;
using EdUtils.Signatures;

namespace EduEngine.Detectors
{
    /// <summary>
    /// Interface for detectors - classes that examine files during the scan process.
    /// </summary>
    public interface IDetector
    {
        /// <summary>
        /// The name of the detector.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The DetectionType that the detector uses when reporting
        /// a Detection.
        /// </summary>
        DetectionType Type { get; }

        /// <summary>
        /// Indicates whether or not the detector is properly initialized and 
        /// whether it will be used during the scan.
        /// </summary>
        DetectorStatus Status { get; }

        /// <summary>
        /// Perform any required initialization to prepare the detector
        /// for scanning.
        /// </summary>
        /// <remarks>Must be called before using Scan().</remarks>
        /// <param name="elements">
        /// A list of elements provided by the scan task.
        /// If the detector does not require any elements to operate then
        /// an empty list will be considered valid, otherwise the detector
        /// will remain in the UNINITIALIZED state.
        /// </param>
        void Initialize(List<SignatureElement> elements);

        /// <summary>
        /// Scan a file and return its detection status.
        /// </summary>
        /// <param name="file">The file to scan.</param>
        /// <returns>
        /// A tuple containing a boolean indicating whether a detection was made
        /// or not, as well as a Detection instance if a detection was made.
        /// </returns>
        (bool detected, Detection detection) Scan(FileItem file);
    }
}
