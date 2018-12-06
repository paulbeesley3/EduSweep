Running & Monitoring Scans
##########################

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
