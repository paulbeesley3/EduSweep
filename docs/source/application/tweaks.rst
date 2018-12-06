Tweaking Advanced Settings
##########################

.. warning::
    Playing with advanced settings has the potential to break your EduSweep installation.

    I get it...we're system administrators. We laugh at warnings like these. Ha Ha Ha!

    Just double-check what you're about to do before you do it :-)

Changing the Working Directory
------------------------------
EduSweep's *working directory* is the directory where its configuration files are stored.
It is also the directory that holds scan tasks, reports, quarantine files, custom
signatures and logs. If that sounds like pretty much everything dynamic in the application
that's because it more-or-less is.

With a *Standard Installation* the static components of EduSweep (executables, libraries
and built-in signatures) are placed in the *Program Files (x86)* directory, where the
application does not have write access. Therefore the user's roaming profile
directory (%appdata\Roaming) is used to store the dynamically-created files. An *EduSweep*
directory is created here to keep everything together.

However, this default location can be overridden.

Creating a Shared-Use Working Directory
---------------------------------------

.. warning::
    Jeez! Does this guy get paid per warning notice, or what?

    Seriously, this configuration is experimental. You may encounter issues with locked or
    inaccessible files if multiple users are using EduSweep at once.

.. note::
    Be sure to read the section above to understand the *working directory* and the
    general consequences of changing it.

A shared working directory can be used so that, for example, scan tasks can be shared
between a number of users.
