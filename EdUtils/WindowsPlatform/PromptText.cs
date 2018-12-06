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
using System.Runtime.InteropServices;
using System.Windows.Forms;
using NLog;

namespace EdUtils.WindowsPlatform
{
    /// <summary>
    /// Support for setting the background (i.e. greyed-out) text of a text box. This text is replaced as soon
    /// as the user starts typing.
    /// </summary>
    public static class PromptText
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private const int SetCueBannerMessageID = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(
            IntPtr windowHandle,
            int message,
            IntPtr messageParam,
            [MarshalAs(UnmanagedType.LPWStr)] string paramText);

        /// <summary>
        /// Set the cue text for a text box
        /// </summary>
        /// <param name="textBox">The text box instance to modify</param>
        /// <param name="cue">The cue text to display in the text box</param>
        public static void SetCue(TextBox textBox, string cue)
        {
            SendMessage(textBox.Handle, SetCueBannerMessageID, (IntPtr)0, cue);
            logger.Trace("Cue text set to {0} for control {1}", cue, textBox.Name);
        }

        /// <summary>
        /// Clear the cue text of a text box
        /// </summary>
        /// <param name="textBox">The text box instance to modify</param>
        public static void ClearCue(TextBox textBox)
        {
            SendMessage(textBox.Handle, SetCueBannerMessageID, (IntPtr)0, string.Empty);
            logger.Trace("Cue text cleared for control {0}", textBox.Name);
        }
    }
}
