ClamAV (Antivirus) Integration
##############################

*ClamAV* is an open-source antivirus engine. It is integrated into several widely-used
products and is also available as a standalone Windows application. EduSweep has the
ability to connect to a ClamAV server instance (known as clamd) so that it can leverage
its antivirus scanning functionality.

.. warning::
    As described in more detail in the following sections, EduSweep is not a replacement
    for a comprehensive anti-malware application and should not be treated as such. ClamAV
    integration is provided for utility purposes only.

.. warning::
    No application can provide 100% threat detection under all conditions. Check suspect
    files with additional anti-malware software if there is any doubt about their
    security status.

This approach is used for EduSweep
because it presents three main advantages:

- EduSweep does not need to incorporate an antivirus scan engine into its codebase, or
  link against a ClamAV library. This would be quite a heavyweight solution.

- The ClamAV server does not need to run on the same machine that is running EduSweep. A
  centralised server may be used to host clamd, which multiple EduSweep instances can
  connect to in parallel.

- The ClamAV server handles antivirus signature updates centrally.

.. note::
    Even with ClamAV integration enabled, EduSweep does not act as a real-time virus
    scanner. It does not integrate into the operating system and so should not conflict
    with any existing antivirus applications.

Antivirus Behaviour
-------------------
With ClamAV integration enabled EduSweep gains the ability to pass files to the ClamAV
server for scanning, and to receive information about their state (clean / infected).

When running a scan, only files that have been detected by one or more signatures are
passed to ClamAV for inspection. The EduSweep scan engine does not use ClamAV to check
every encountered file for viruses.

.. note::
    As with any application that makes file accesses, if a file on the filesytem contains
    a virus and EduSweep attempts to access it then an installed antivirus application on
    the system may detect and block the attempt.
