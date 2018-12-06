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
One of the most significant factors affecting scan task runtime is the location of the
directories and files being scanned, in relation to the machine on which EduSweep is
running.

**Scanning files on a physical disk within the same machine will almost always be faster
than scanning a network share or mapped drive.** This is because information on the
directory structure and, in some cases, file contents must be transferred across the
network during the scan process. The amount of data can be considerable if many
directories are included in the scan.

If you have a single file server containing all of the directories that you wish to scan
then it is preferable, from a performance standpoint, to install and run EduSweep directly
on that server. This will provide better performance than scanning from a separate machine
that has access to those directories over the network.

Logical Processor Count
-----------------------
EduSweep 2.6 and above are able to utilise multiple processors to accelerate file
scanning. EduSweep uses a formula to determine the maximum number of processors that it
will use::

    Max Processors Used = Largest((Total Processors - 1), 1)

This ensures that at least one logical processor is kept unloaded for background system
operations, and at least one logical processor is used. The above formula means that
multithreaded scanning is enabled only on machines with three or more logical processors.

.. note::
    Dual-core processors with SMT technology (Hyper-Threading) are viewed as four
    logical processors and so these can potentially benefit.

Deeper within the scan engine, the number of files within each directory being examined is
used to enable or disable parallelism on a per-directory basis. This is fully automatic,
based on the number of files and the number of logical processors, and is not directly
user-configurable. A folder with only a small number of files, especially if that number
is smaller than the number of logical processors, is unlikely to be scanned in parallel.

Hash-Based (Specific File) Signature Elements
---------------------------------------------

When this type of signature element is used in a scan task there is a performance penalty
as more file metadata must be examined.
