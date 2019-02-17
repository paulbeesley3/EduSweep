Performance Tuning
##################

This section covers some tips and tricks to maximise the performance of the EduSweep scan
engine, reducing the time taken to run scan tasks. Some insights into the internals of the
engine are also provided to give context to the advice.

.. note::
    Performance may vary depending on a number of factors, including software
    configurations, machine hardware, network topology, background tasks and I/O activity.

    While the advice given here should improve performance in the majority of situations,
    there is no guarantee that an improvement will be seen in your specific configuration.

Filesystem Proximity
--------------------
The most significant factor affecting scan task runtime is the location of the
directories and files being scanned, in relation to the machine on which EduSweep is
running.

Scanning files on a physical disk within the same machine will almost always be
**dramatically** faster than scanning a network share or mapped drive. This is because
information on the directory structure and, in some cases, file contents must be
transferred across the network during the scan process. The amount of data can be
considerable if many directories are included in the scan.

If you have a single file server containing all of the directories that you wish to scan
then it is preferable, from a performance standpoint, to install and run EduSweep directly
on that server. This will provide better performance than scanning from a separate machine
that has access to those directories over the network.

Parallel Scanning Mode
-----------------------
EduSweep 2.6 and above are able to utilise multiple processors to accelerate file
scanning. This feature is controlled on a per-task basis and is fully enabled by default.

EduSweep's scan engine can operate in three parallel scanning modes:

- Full: Use (up to) all logical processor cores in the system
- Reduced: Use (up to) all physical processor cores in the system
- Disabled: Use only a single scanner thread (legacy mode)

Within the scan engine the number of parallel threads is set automatically on a
per-directory basis, up to the limit set in the scan task. This is based on the number of
files. A folder with only a small number of files is unlikely to benefit from parallel
scanning due to the overhead of managing threads.

Number of Signature Element Types
---------------------------------
Each type of signature element (extension, keyword, etc) is handled by a dedicated
detector component within the scan engine. Initializing these detectors takes time at the
start of the scan and adds to the time required to scan each file, since the file is
checked by each detector in turn. The overall impact is small in comparison to other
factors affecting scan performance.

Overall Number of Signature Elements
------------------------------------
More elements means that each detector has a longer list of comparisons to make. Generally
this is not a concern but extreme numbers of signature elements (hundreds) will have a
cumulative performance impact that becomes noticeable.

Hash-Based (Specific File) Signature Elements
---------------------------------------------
When this type of signature element is used in a scan task there is a small performance
penalty as more file metadata must be examined.

EduSweep will not perform any file hashing - which is very slow - unless the size of the
file being scanned matches the size of one or more specific file elements loaded by the
scan task. There is still a small performance penalty from examining the size metadata
of each file being scanned.
