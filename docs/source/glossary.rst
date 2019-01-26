Glossary
#########

An overview of application-specific terminology used in EduSweep.

Detection
---------
A detection is created whenever a file being scanned is matched by an element. The
detection is associated with the detected file and will be presented in the scan
report.

Element
-------
An element may be a file extension, filename keyword or SHA1 hash of a specific file.
When EduSweep scans a file it compares it against every element that has been loaded as
part of the running scan task. If the element matches a particular property of the file
then a detection is triggered and the file is added to the detected files list.

Elements can be added to signatures or added to a scan task directly.

File Inspector
--------------
Utility used to discover additional information about a specific file, including its
filesystem properties and its most likely true file type, based on its content. Also
generates common checksums such as CRC32, MD5 and SHA1.

Quarantine
----------
Quarantine storage is where files are placed after detection during a scan, or manually
quarantined from the File Inspector or the Quarantine Manager window. From quarantine the
files can be restored, removed or inspected in more detail.

Report
------
An HTML-formatted summary of the outcome of a scan task, including details on any detected
files.

Scan Task
---------
A reusable profile that contains one or more directories to scan, one or more elements to
detect and settings that govern how the scan is carried out.

Signature
---------
A signature is a collection of one or more elements that are packaged for use together.
Signautures can save time by removing the need to add multiple elements to a task one-by-one.

An example would be a signature designed to detect compressed files that includes the
following extension elements: zip, gz, 7z, rar.

Signatures are grouped by category where listed, and then alphabetically within each
category.

Signature Studio
----------------
Utility used to manage and create custom signatures for use with the main EduSweep
application.
