Repackaging
###########

Some network management systems, such as RM Community Connect, require
installers to be repackaged before an application can be deployed through their management
interfaces. This creates a new installer (usually in MSI format) that gets deployed to
workstations instead of the application's original installer.

EduSweep has been designed to accommodate repackaging as far as possible:

    - The installer does not create any registry entries beyond those necessary to register
      the application and its uninstaller entry in Windows' list of applications.

    - The application does not require write access to its install directory

    - No files are placed into the Windows directory (or other system directories)

    - The application does not require elevated / administrator permissions to run

    - Application data is stored in the user's roaming profile by default

Instructions for performing the repackaging process are beyond the scope of
this guide. Refer to your management system’s documentation for help with this process.

Testing the Deployed Package
----------------------------
Once the repackaging process is complete you can test the correct operation
of EduSweep after deployment by:

    - Starting the application from the EduSweep entry in the Start Menu (and
      verifying that the entry is present)

    - Creating and then deleting a new scan task

    - Adding a file to quarantine (and, optionally, restoring it to its original location)

    - Modifying the application settings

    - Reviewing the application log file for warnings and errors

If you encounter difficulties repackaging EduSweep and you feel that the EduSweep installer
is the cause then please raise an issue. See the :ref:`support` page for links to do this.
