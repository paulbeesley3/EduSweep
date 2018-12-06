MSI Repackaging
###############

Some network management systems, such as RM Community Connect, require
MSI and EXE installers to be repackaged before an application can be deployed
through their management interfaces.

EduSweep has been designed to accommodate this by adding zero custom registry entries
to the system and by installing all of its files in one folder to which write access
is not required.

Instructions for performing the repackaging process are beyond the scope of
this guide. Refer to your management system’s documentation for this process.
If you have difficulties repackaging EduSweep and you feel that the installer
itself is the cause then please raise an issue. See the :ref:`support` page for links.

Once the repackaging process is complete you can test the correct operation
of EduSweep after deployment by:

- Ensuring that the application can be started by double-clicking on the
  EduSweep 2.exe file in the installation folder
- Starting the application from the EduSweep entry in the Start Menu (and
  verifying that the entry is present)
- Creating and then deleting a new scan task
