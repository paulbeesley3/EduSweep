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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using EdUtils.Filesystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EdUtils.Filesystem.Tests
{
    [TestClass()]
    public class PathsTests
    {
        [TestMethod()]
        public void IsDirectory_Dir()
        {
            Assert.IsTrue(Paths.IsDirectory(@"C:\windows"));
            Assert.IsTrue(Paths.IsDirectory(@"C:\windows\"));
        }

        [TestMethod()]
        public void IsDirectory_File()
        {
            Assert.IsFalse(Paths.IsDirectory(@"C:\windows\regedit.exe"));
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void IsDirectory_NonExistent()
        {
            Paths.IsDirectory(@"C:\nonexistentdirectory\");
        }

        [TestMethod()]
        [ExpectedException(typeof(FileNotFoundException))]
        public void IsDirectory_NonExistentFile()
        {
            Paths.IsDirectory(@"C:\nonexistentfile.txt");
        }

        [TestMethod()]
        public void IsAccessible_Empty()
        {
            Assert.IsFalse(Paths.IsAccessible(string.Empty));
            Assert.IsFalse(Paths.IsAccessible(" "));
        }

        [TestMethod()]
        public void IsAccessible_BadCharacters()
        {
            Assert.IsFalse(Paths.IsAccessible(@"C:\<"));
        }

        [TestMethod()]
        public void IsAccessible_DriveRoot()
        {
            Assert.IsTrue(Paths.IsAccessible(@"C:\"));
        }

        [TestMethod()]
        public void IsAccessible_NonExistent()
        {
            Assert.IsFalse(Paths.IsAccessible(@"C:\doesnotexist"));
        }

        [TestMethod()]
        public void IsAccessible_RFC8089Format()
        {
            Assert.IsTrue(Paths.IsAccessible(@"file:/C:/"));
            Assert.IsTrue(Paths.IsAccessible(@"file://C:/"));
            Assert.IsTrue(Paths.IsAccessible(@"file:///C:/"));
            Assert.IsTrue(Paths.IsAccessible(@"file://localhost/C:/"));

            Assert.IsFalse(Paths.IsAccessible(@"file://127.0.0.1/C:/"));
            Assert.IsFalse(Paths.IsAccessible(@"file://C:"));
        }

        [TestMethod()]
        public void GetType_Local()
        {
            Assert.AreEqual(PathType.LOCAL, Paths.GetType(@"C:\"));
            Assert.AreEqual(PathType.LOCAL, Paths.GetType(@"C:\windows"));
        }

        [TestMethod()]
        public void GetType_RemoteUNC()
        {
            Assert.AreEqual(PathType.REMOTE_UNC, Paths.GetType(@"\\192.168.1.1\share"));
            Assert.AreEqual(PathType.REMOTE_UNC, Paths.GetType(@"//192.168.1.1\share"));
        }

        [TestMethod()]
        public void GetType_Unavailable()
        {
            Assert.AreEqual(PathType.UNAVAILABLE, Paths.GetType(@"X:\share"));
        }

        [TestMethod()]
        public void GetOwner_LocalFile()
        {
            var info = new FileInfo(@"C:\Windows\regedit.exe");
            Assert.AreNotEqual("Unknown", Paths.GetOwner(info));
        }
    }
}