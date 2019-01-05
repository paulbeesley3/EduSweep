Running & Monitoring Scans
##########################

Running a scan task is as easy as selecting it from the list on the main window
and either clicking the “Start Task” button on the toolbar or double-clicking the
list entry. The scan window will appear and the scan will begin to run immediately.
You can pause or stop the scan at any point using the buttons on the
bottom-right side of the window.

If you are using Windows 7 then EduSweep will report the progress of the scan
task in the Windows taskbar. While the task is starting, the taskbar will display
an indeterminate (marquee) progress bar and when the scan has started a
regular progress bar is used to inform you of the scan progress even when
EduSweep is minimised.

The scan window is made up of four tabs - Overview, Locations, Results and
Log. The most often used tabs are Overview and Results since these allow the
scan progress to be observed and the results to be dealt with.

Overview Tab
------------
This tab contains a list of folders that have been examined during the scan; it
is useful for tracking the progress of the scan while it is running. By default,
the list will not scroll automatically but this can be enabled by checking the
“Automatically scroll this list” checkbox at the bottom of the tab.

Locations Tab
-------------
The locations tab displays a list of the targeted directories that were chosen
when creating the scan task. The status of each directory is shown (either Not
Started, Scanning or Completed) along with the location of the directory which
will be either on the local machine or a network location.

Results Tab
-----------
While the scan is running, EduSweep will add results to the list on this tab in
real-time. Files shown in this list have matched one or more criteria specified
by the task’s signatures.
The strip of buttons along the bottom of the tab give you the option of moving
the currently selected files into quarantine or deleting them. When a single file
is selected, the “Show File” and “Details” buttons are enabled. These open the
file’s location in Explorer and show the file inspector for the given file, respectively.
It is worth noting that while all detected files have matched some portion of a
signature they should still be reviewed manually before moving them to quarantine
or deleting them. The software will inevitably detect ’false positives’ when
keywords are being used. For example, the pornography signature detects
file names containing the word ’sex’ but this will also match a Word document
named ’An Investigation into UK Sexual Health Policies’, which could well be a
piece of coursework. Signatures that detect files based on extension only will
not return false positives, however.

Log Tab
-------
This tab provides detailed information about the scan process. In normal use
there should be no need to view the information logged here (unless you’re
curious, of course). The scan log is appended to the end of each report that is
produced and can be helpful for debugging issues should the need arise.
