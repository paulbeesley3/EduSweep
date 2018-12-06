Upgrading from Older Versions
#############################

General Advice
--------------
- Do not

Side-By-Side Installs
---------------------
Changes made in EduSweep 2.6 mean that it cannot be installed over an existing
installation of versions 2.2 or below. The installer for 2.5 will remove any
older installations before installing the newer version.

Scan Task Migration
-------------------
Scan tasks created in older versions of EduSweep will not be imported into
the new version because the task format has changed.

The upgrade process
will not delete any tasks that were created in the older format, however, as
these roam with your user profile and are not considered a part of the local
EduSweep installation. A conversion tool for updating tasks to the new format
may be released at a later date.

Troubleshooting
---------------
If you encounter issues when using a new version of EduSweep on a machine or profile that
has previously been used with an older version then the first step is to remove the
EduSweep folder from your profile.

The default location for the EduSweep data folder is:

    %appdata%/EduSweep

Remove the folder entirely, or all of its contents. Note that if you are using a portable
installation of EduSweep then the root directory is the data folder as well.
