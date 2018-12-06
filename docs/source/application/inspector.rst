File Inspector Utility
######################

The file inspector is used to retrieve detailed information about a selected file.
It provides file system information such as creation and modification dates for
the selected file, along with an analysis of the file contents. This tool can be
used to check if the purported file type matches its actual content; an innocent
.jpg file may in fact be a renamed .vbs script and the file inspector will detect
this.

.. note::
    Certain pieces of file metadata, such as the detected filetype are determined using a
    heuristic process. Be aware that the result can be incorrect and that some file types are
    easier to detect accurately than others.

The toolbar along the top of the window provides an “Open...” button which is
used to select a new file for analysis, a “Run/View” menu that allows the file to
be opened in its default program or in notepad, a refresh button for if the file
is updated and finally two buttons that move the file to quarantine or delete it
permanently.

In the lower parts of the window the file inspector will list the possible file types
that it has detected for the current file along with a percentage likelihood of
each being the true type. At the very bottom is a set of notes that describe any
noteworthy properties of the file. The tool may suggest, for example, that since
a file’s modification date is prior to its creation date it could have been created
on a different computer.

.. note::
    It is much more difficult to determine the file type for text-based formats (e.g. JSON,
    RTF, XML) than it is for binary formats (e.g. PDF, DOC, PNG). The file type may be
    detected as unknown for certain text-based file formats.
