Changelog
#########

Release notes for each stable, released version of EduSweep.

[2.6.2] - 2019-04
=================

Added
-----
    - "Select Group" buttons in the scan results list
    - Right click menu to select or clear all scan results

Changed
-------
    - File Inspector is using new libraries to determine MIME type and real file extension
    - Grouping behaviour is improved in list views across the application
    - Slightly improved performance when loading large lists of files
    - Use monochrome logo on main window

Fixed
-----
    - The main window shows incorrect scan status information when running parallel scans
    - Buttons on the task results tab have an incorrect state after deleting file(s)
    - Default documentation link points to trunk version instead of stable
    - Broken File Inspector images in documentation

Developer Notes
---------------
    - Added EdUtilsTests project and some basic tests
    - Added MIME library
    - Added Analyzer interface
    - Added MIMEAnalyzer analyzer
    - Added ChecksumAnalyzer analyzer
    - Added SizeDetector detector (not yet used)
    - Removed TrID library
    - Removed some unused code
    - Signatures are now part of the EduEngine project instead of EdUtils
    - Applications are now built with 64-bit targets

[2.6.1] - 2019-02
=================

Added
-----
    - Overview documentation for Signature Studio and File Inspector utilities

Changed
-------
    - Automatic cleanup of reports now defaults to OFF (new installs only)
    - Automatic cleanup of quarantine now defaults to OFF (new installs only)
    - [Issue #7] List views now remember column sizes, sort order, etc across sessions
      * This affects the main window, Quarantine Manager and Report Manager
    - [Issue #10] Resizeable windows now remember their sizes across sessions
    - Inaccessible directory log entry is now INFO type instead of WARN
    - Clarified portable mode checkbox actions in installer
    - Minor interface improvements for Signature Studio tool
    - Updated and corrected Performance Tuning document

Removed
-------
    - File Inspector quarantine button (pending review of how it integrates with main app)
    - File Inspector "Root Location" info (will be restored in a File Inspector overhaul)

Fixed
-----
    - Crash when attempting to save a task, report or signature to a read-only directory
    - Disabling parallel scanning does not limit engine to a single thread
    - Task Editor "Remove" button for elements does nothing if multiple elements are selected
    - File Inspector "Quarantine" menu button is broken
    - Potential configuration file corruption due to race condition
    - Doubled-up warning messages if a directory is inaccessible
    - [Issue #2] TaskDialogs are not wrapped with the 'using' directive
    - Outdated information in installer documentation
    - Missing screenshots in some documentation pages

Developer Notes
---------------
    - Added VS Code Analysis rules to run on build
    - Pruned some dead code
    - Config.Net library updated to version 4.13.2
    - Castle.Core library updated to version 4.3.1

[2.6.0] - 2019-02
=================

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
