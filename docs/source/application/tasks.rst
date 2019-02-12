Scan Task Editor
################

Before scanning a directory with EduSweep a *Scan Task* must be created. The *Task Editor*
is used for creating tasks that can be reused multiple times. Refer to the `Scan Tasks`_
document for more information about scan tasks and how they are used in EduSweep.

Creating a scan task can be broken down into three steps:

1. Selecting a name for the task and checking the general settings
2. Adding one or more directories to scan
3. Adding one or more *elements* that will be used for detecting files

Once the task has been created it will be availble from the task list on
the Main Window.

General Settings
----------------

.. image:: ../../screenshots/tasks/new-general.png

This first tab is used for setting the name of the task, adjusting the
parallel scanning modes and choosing whether to enable antivirus
integration or not.

The task’s name is used to help identify it. Choose a descriptive name such
as “Year 10 Home Folders” so that its purpose is clear and explains loosely
which files will be scanned. This name is also used in the title of the report
that is created after running the task.

The *Parallel Scanning* setting governs the number of threads that EduSweep can use
while scanning directories. Depending on the structure of the directory tree being
scanned and the type of storage, this feature can provide a significant speed increase.
Refer to the `Performance Tuning`_ document for more details on the perrformance considerations
of this feature.

Antivirus Integration controls the state of virus scanning at the scan task level. There is also
a global setting for this which works in combination with the task-level setting. This feature
will only function properly if EduSweep has been configured to communicate with a ClamAV server
(clamd) instance. Refer to the `ClamAV (Antivirus) Integration`_ document for details.

Target Directories
------------------

.. image:: ../../screenshots/tasks/new-targets.png

This tab shows the list of directories that will be scanned when the scan task is
run.

To add a directory to the list, choose “Add Location” from the toolbar immediately
above the locations list and a folder browser dialog will be presented so
that you can select the folder to be scanned. Once you have navigated to the
desired folder, press “OK” on the dialog (“Select Folder” on Windows Vista and
above) and it will be added to the list.

By default, any directory added to the list will be scanned recursively; all sub-directories of
the directory will be scanned, and their sub-directories, and so on. Use the *Toggle Subdirectory
Scan* button to enable or disable this behaviour.

Signatures and Elements
-----------------------

.. image:: ../../screenshots/tasks/new-elements.png

This tab controls what will be detected during the scan, using `Signatures`_ and
`Signature Elements`_.

The three types of elements (file extensions, filename keywords and specific
files) can be added to the scan task directly using the toolbar buttons. You can
also add groups of elements from signatures using the *Browse Signatures...*
button.

As an example, to detect .exe files and files containing the word "vpn" in their
name we can add one extension-type element with the value "exe" and one
keyword-type element with the value "vpn". Alternatively, we could add the
*Windows Executables* signatures instead of the extension-type element to scan
for a wider range of executable files all at once.

.. _Scan Tasks : ../concepts/tasks.rst
.. _Signatures: ../concepts/signatures.rst
.. _Signature Elements: ../concepts/signatures.rst
.. _ClamAV (Antivirus) Integration: ../concepts/clam.rst
.. _Performance Tuning: ../perf.rst
