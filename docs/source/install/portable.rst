Converting to a Portable Install
################################

A standard installation can be quickly converted to a portable installation.

Make sure that the installation directory is writable, then create an empty file named
*PORTABLE* in the root of the directory (next to the EduSweep executable). The next time
that EduSweep starts up it will treat the installation directory as its working
directory and will create some new folders there to store its state.

Note that a converted installation will effectively be reset to default settings. You
will need to copy over any configuration files from the previous working directory
(most likely *%appdata%\\EduSweep*) if you want to recreate the state.
