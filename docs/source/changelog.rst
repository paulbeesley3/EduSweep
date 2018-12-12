Changelog
#########

Release notes for each version of EduSweep will be kept in this section.

.. note::
    Prior to 2.6.0 the last public EduSweep release was 2.2.0 and all other releases
    were either beta-only or private. This changelog considers 2.2.0 to be its base and
    consequently picks up from 2.2.0 -> 2.6.0.

[2.6.0] - 2018-11-30
====================

Added
-----
    - Third-generation scan engine
    - Support for running multiple scan tasks at once
    - Support for virus scanning of detected files using ClamAV
    - Optional portable application mode
    - Signature Studio utility (create and manage custom signatures)
    - Full Windows 10 compatibility
    - Complete user documentation

Changed
-------
    - File Inspector utility can now be run as a standalone application
    - TrID filetype database updated to 2018-12-11 version
    - Scan tasks can now be cloned (creating a copy with a new name)
    - Folders can now be dragged and dropped onto the target directories list
    - Lists in the UI can now be grouped and sorted
    - Most windows are now resizeable and snappable
    - Old quarantine files and reports can be cleaned up automatically,
      or on-demand from the settings window
    - Application settings are now in JSON format (instead of XML)
    - Improved logging of application events and scan results
    - Numerous performance improvements
    - Signatures are now included with the installer (no need for software update)
    - Installer changed to Inno Setup (more options during install, better cleanup)

Removed
-------
    - Aero Glass theme support
    - Windows XP support
    - Software Update feature (due to server removal)
    - Detection support for embedded Flash (due to Flash slowly dying)

Fixed
-----
    - Tasks take a very long time to start running (directory pre-scan)
    - Icons displayed in the File Inspector are not always high quality
    - File Inspector scan time is excessive on very large files
    - The application may hang when cancelling a task
    - Crash when scanning very deep directory trees
    - Crash when closing the File Inspector during a scan
    - Crash with ‘BadImageFormatException’ when starting a task
    - Crash when encountering invalid characters in a file extension or keyword
    - Resizing of list column headers renders some text unreadable
    - Network paths might be incorrectly marked as unavailable
    - Files may be missed while scanning folders containing empty subfolders
    - Incorrect dialog text when quarantining files
    - Incorrect link to FILExt extension lookup site
    - External links are not always pointing to HTTPS versions
    - Inconsistent sorting of items in lists

Developer Notes
---------------
    - Substantial code rework and refactoring (about 50-60% rewritten)
    - Visual Studio solution files updated for use with VS2017 Community
    - Added StyleCop rules
    - Added nClam library to interface with clamd
    - Added Config.NET library to handle more portable setting storage
    - Added NLog library to replace the old Bitfactory.Logging library
    - Updated TrIDLib library (1.01 -> 1.02)
    - Removed Mvolo.Shellicons library
    - Removed Ionic.Zip library
    - Removed SharpZipLib library
    - Moved to the GNU GPLv3 license
    - Improved license compliance for bundled libraries
    - Now using nuget packages where possible
    - Added license and copyright headers to all code files
