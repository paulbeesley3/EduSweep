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
using System.Diagnostics;
using EdUtils.Types;
using NLog;

namespace EdUtils.Helpers
{
    public static class Web
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void LookupSearchTerm(string searchTerm, OnlineSearchProvider provider)
        {
            string url = string.Empty;

            switch (provider)
            {
                case OnlineSearchProvider.GOOGLE:
                    url = string.Format(
                         "https://www.google.com/search?hl=en&q={0}",
                          searchTerm);
                    break;
                case OnlineSearchProvider.BING:
                    url = string.Format(
                         "https://www.bing.com/search?q={0}",
                          searchTerm);
                    break;
                case OnlineSearchProvider.DUCKDUCKGO:
                    url = string.Format(
                         "https://duckduckgo.com/?q={0}",
                          searchTerm);
                    break;
                case OnlineSearchProvider.FILEEXTENSION:
                    url = string.Format(
                         "http://file-extension.net/seeker/file_extension_{0}",
                          searchTerm);
                    break;
                case OnlineSearchProvider.FILEINFO:
                    url = string.Format(
                         "https://www.fileinfo.net/extension/{0}",
                          searchTerm);
                    break;
                case OnlineSearchProvider.FILEXT:
                    url = string.Format(
                         "https://filext.com/file-extension/{0}",
                          searchTerm);
                    break;
                default:
                    logger.Warn("Unknown search provider specified");
                    return;
            }

            LaunchWebBrowser(url);
        }

        public static void LaunchWebBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch (Exception ex)
            {
                logger.Error(ex, "The default web browser could not be launched");
            }
        }
    }
}
