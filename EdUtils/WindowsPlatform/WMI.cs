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
using System.Management;
using EdUtils.Helpers;
using NLog;

namespace EdUtils.WindowsPlatform
{
    /// <summary>
    /// Support for querying OS and machine properties via the Windows Management
    /// Instrumentation (WMI) interface
    /// </summary>
    [Serializable]
    public class WMI
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static string QueryWindowsVersion()
        {
            string version = "Unknown";
            try
            {
                var searcher = new ManagementObjectSearcher(
                    "root\\CIMV2",
                    "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    version = queryObj["Caption"].ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WMI Windows version query failed");
            }

            return version;
        }

        public static string QueryInstalledMemory()
        {
            long memoryInBytes = 0;
            try
            {
                var searcher = new ManagementObjectSearcher(
                    "root\\CIMV2",
                    "SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    memoryInBytes = long.Parse(queryObj["TotalPhysicalMemory"].ToString());
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WMI system memory query failed");
            }

            return Utils.GetDynamicFileSize(memoryInBytes);
        }

        public static string QueryWindowsServicePack()
        {
            string servicePack = string.Empty;
            try
            {
                var searcher = new ManagementObjectSearcher(
                    "root\\CIMV2",
                    "SELECT * FROM Win32_OperatingSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    string installedServicePack = queryObj["ServicePackMajorVersion"].ToString();
                    servicePack = "SP" + installedServicePack;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WMI Windows service pack level query failed");
            }

            return servicePack;
        }

        public static string QueryInstalledBIOS()
        {
            string description = string.Empty;
            string name = string.Empty;

            try
            {
                var searcher = new ManagementObjectSearcher(
                    "root\\CIMV2",
                    "SELECT * FROM Win32_BIOS");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    name = queryObj["Name"].ToString();
                    description = queryObj["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WMI BIOS name query failed");
            }

            if (name.Equals(string.Empty))
            {
                return description;
            }

            return name;
        }

        public static string QueryDomainRole()
        {
            int role = 0;
            string strRole;

            try
            {
                var searcher = new ManagementObjectSearcher(
                    "root\\CIMV2",
                    "SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    role = Convert.ToInt16(queryObj["DomainRole"]);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WMI domain role query failed");
                return "Unknown";
            }

            switch (role)
            {
                case 0:
                    strRole = "Standalone Workstation";
                    break;
                case 1:
                    strRole = "Member Workstation";
                    break;
                case 2:
                    strRole = "Standalone Server";
                    break;
                case 3:
                    strRole = "Member Server";
                    break;
                case 4:
                    strRole = "Backup Domain Controller";
                    break;
                case 5:
                    strRole = "Primary Domain Controller";
                    break;
                default:
                    strRole = "Unknown";
                    break;
            }

            return strRole;
        }

        public static string QuerySystemName()
        {
            string name = "Unknown";

            try
            {
                var searcher = new ManagementObjectSearcher(
                    "root\\CIMV2",
                    "SELECT * FROM Win32_ComputerSystem");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    name = queryObj["Name"].ToString();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "WMI system name query failed");
            }

            return name;
        }

        public static int QueryPhysicalProcessorCount()
        {
            int cores = 0;

            try
            {
                var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                foreach (var item in searcher.Get())
                {
                    cores += int.Parse(item["NumberOfCores"].ToString());
                }
            }
            catch (Exception ex)
            {
                logger.Warn(
                    ex,
                    "Physical processor count query failed. Reporting single core.");
                return 1;
            }
           
            return cores;
        }
    }
}
