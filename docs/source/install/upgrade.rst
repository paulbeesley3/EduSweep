Upgrading from Older Versions
#############################

Remove Older EduSweep Installations
-----------------------------------
Older versions of EduSweep will try to place data in your roaming profile and this may
conflict with newer data formats used by EduSweep 2.6 and later. It is recommended to
remove any older versions of EduSweep to avoid such conflicts.

Remove Existing EduSweep Data
-----------------------------
If you encounter issues when using EduSweep 2.6 or later on a machine that
has been used with an older version, or if your roaming profile contains old EduSweep data,
then the first step is to remove the EduSweep folder from your profile.

The default location for the EduSweep data folder is:

    %appdata%/EduSweep

Remove the folder entirely, or all of its contents. Note that if you are using a different
location for storing EduSweep data (such as in a portable installation) then the above
path must be modified accordingly.

Scan Task Migration
-------------------
Scan tasks created in older versions of EduSweep will not be imported into
the new version because the task format has changed. A conversion tool for updating tasks
to the new format may be released at a later date depending on demand.

Custom Signature Migration
--------------------------
Custom signatures created in older versions of EduSweep will not be imported into
the new version because the file format has changed. A conversion tool for updating signatures
to the new format may be released at a later date depending on demand.
