Creating a Scan Task
####################

Tasks are a key concept when using EduSweep; they define the directories
that will be scanned as well as the signatures that will be used to detect unwanted
files.Each tasks is self-contained so, for example, several tasks could
be created with each scanning the same folder yet searching for different file
types.

Since every network has a different layout, EduSweep comes with no tasks
and one of the first steps taken when setting up the software is to create one.
This is achieved through the New Task window, accessible from the toolbar on
the main window.

Creating a scan task requires 3 pieces of information from you: a name for the
task, a list of directories to scan and a list of signatures that will be used to
detect files while the scan is running.

Naming
------
The task’s name is used to uniquely identify it. It does not affect the software in
any way so give it a name that works for you such as “Year 10 Home Folders”
so that its purpose is immediately obvious. Once the task has been created,
it can be selected from the task list on the main window using the name it has
been given here.
EduSweep does not currently support tasks with duplicate names. If you give
the new task the same name as an existing task then the existing task will be
overwritten.

Scan Locations
--------------
The locations list contains the directories that will be scanned when running
the task. Directories are scanned recursively - that is, all sub-directories of the
parent directory will be scanned. If this is not what you want then you can either
select individual folders within the parent directory or use an exclusion if there
are only a handful of folders you wish to ignore.
To add a directory to the list, choose “Add Location” from the toolbar immediately
above the locations list and a folder browser dialog will be presented so
that you can select the folder to be scanned. Once you have navigated to the
desired folder, press “OK” on the dialog (“Select Folder” on Windows Vista and
above) and it will be added to the list.
Optionally, you can add some exclusions to the task. An exclusion is a location
that EduSweep will ignore while scanning. A good example of an exclusion
would be a very large folder that only administrators have access to because
the contents are secure and ignoring it will speed up the scan. Tip: You can
double click a location to edit its path.
