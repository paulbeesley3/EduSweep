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

using EduEngine.Scanner;
using EduEngine.Tasks;

namespace EduSweep_2.Tasks
{
    public class CompositeScanTask
    {
        public ScanTask Task { get; }

        public ScanStatus Status { get; }

        public CompositeScanTask(ScanTask task)
        {
            this.Task = task;
            this.Status = ScanStatus.UNINITIALZED;
        }

        public CompositeScanTask(ScanTask task, ScanStatus status) : this(task)
        {
            this.Status = status;
        }
    }
}
