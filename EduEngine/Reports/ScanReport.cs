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
using System.Collections.Generic;
using System.Text;
using EduEngine.Tasks;
using EdUtils.Filesystem;
using EdUtils.Types;
using Newtonsoft.Json;

namespace EduEngine.Reports
{
    [Serializable]
    public class ScanReport : SerializableObject
    {
        [JsonProperty]
        public ScanTask Task { get; private set; }

        [JsonProperty]
        public List<FileItem> DetectedItems { get; private set; } = new List<FileItem>();

        [JsonProperty]
        public long ScannedDirectoryCount { get; private set; }

        [JsonIgnore]
        public long DetectedItemCount => this.DetectedItems.Count;

        [JsonIgnore]
        public TimeSpan Age => DateTime.Now - this.CreationTime;

        [JsonIgnore]
        public string AgeAsText => string.Format("{0:%d} day(s)", Age);

        [JsonProperty]
        public List<string> Tags { get; set; } = new List<string>();

        public override string Serialize()
        {
            var serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Auto
            };

            return JsonConvert.SerializeObject(this, serializerSettings);
        }

        [JsonConstructor]
        private ScanReport()
        {
            /* Required for deserialization support */
        }

        public ScanReport(ScanTask task)
        {
            this.Name = string.Format("{0} on {1}", task.Name, task.LastStartTimeAsText);
            this.Task = task;
            this.Creator = task.LastRunOwner;
        }

        public ScanReport(ScanTask task, List<FileItem> detectedItems) : this(task)
        {
            this.DetectedItems = detectedItems;
        }

        public ScanReport(ScanTask task, List<FileItem> detectedItems, long scannedDirectoryCount) : this(task, detectedItems)
        {
            this.ScannedDirectoryCount = scannedDirectoryCount;
        }

        public string GenerateHTML()
        {
            var sb = new StringBuilder();

            /* HTML Head */
            sb.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"> ");
            sb.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\" lang=\"en\"><head><title>\"Task Results - " + Name +
                      "\"</title><meta http-equiv=\"Content-Type\" " + "content=\"text/html;charset=utf-8\"/><style type=\"text/css\">");
            sb.Append("h2{color:#fff;font-weight:Normal;font-size:100%;background-color:#000000;text-indent:.1cm}div.one{color:#000;font-family:\"Segoe UI\";font-size:80%;}table,th,td{border:1px solid black;font-family:\"Segoe UI\";}table{width:100%;border-collapse:collapse}th{color:#fff;font-weight:Normal;font-size:100%;background-color:#000000;height:30px}");
            sb.Append("</style></head><body>");

            /* Content */
            sb.Append("<div class=\"one\"><h2>Task Summary</h2>");
            sb.Append(@"Started: " + this.Task.LastStartTime.ToShortDateString() + " at " + this.Task.LastStartTime.ToShortTimeString() + "<br/>");
            sb.Append(@"Completed: " + this.Task.LastCompletionTime.ToShortDateString() + " at " + this.Task.LastCompletionTime.ToShortTimeString() + "<br/>");
            sb.Append(@"Duration: " + this.Task.Duration.Hours + " hours, " + this.Task.Duration.Minutes + " minutes, " + this.Task.Duration.Seconds + " seconds<br/>");
            sb.Append(@"Started By: " + this.Task.LastRunOwner + "<br/>");

            /* For each item that was flagged in the scan, write its path */
            sb.Append(@"<h2>Detected Items (" + this.DetectedItems.Count + @")</h2>");
            if (this.DetectedItems.Count > 0)
            {
                sb.Append(@"<table>");
                sb.Append(@"<tr><th>File Name</th><th>Triggered Elements</th><th>Owner</th><th>Size</th><th>Path</th></tr>");
                foreach (FileItem detectedItem in this.DetectedItems)
                {
                    sb.Append(@"<tr>");
                    sb.Append(@"<td>" + detectedItem.Name + @"</td>");

                    var triggerBuilder = new StringBuilder();
                    foreach (var detection in detectedItem.Detections)
                    {
                        triggerBuilder.Append(string.Format("{0}, ", detection.Detail));
                    }

                    /* Remove trailing comma and space */
                    triggerBuilder.Length -= 2;
                    sb.Append(@"<td>" + triggerBuilder.ToString() + @"</td>");

                    sb.Append(@"<td>" + detectedItem.Owner + @"</td>");
                    sb.Append(@"<td>" + detectedItem.LengthAsText + @"</td>");
                    sb.Append(@"<td>" + detectedItem.ParentDirectoryPath + @"</td>");
                    sb.Append(@"</tr>");
                }

                sb.Append(@"</table>");
            }
            else
            {
                sb.Append("No items were detected.<br/>");
            }

            sb.Append("</div></body></html>");
            return sb.ToString();
        }
    }
}
