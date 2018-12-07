<h1 align="center">
    <br>
    <img src="https://raw.githubusercontent.com/paulbeesley3/edusweep/master/static_resource/img/banner.png"
         alt="EduSweep Logo"
         width=401>
</h1>

<h4 align="center">Unwanted File Detection and Management for Education</h4>

<p align="center">
    <a href="https://GitHub.com/paulbeesley3/edusweep/releases">
        <img src="https://img.shields.io/github/release-pre/paulbeesley3/edusweep.svg"
             alt="GitHub Release">
    </a>
    <a href="https://www.gnu.org/licenses/gpl-3.0.en.html">
        <img src="https://img.shields.io/github/license/paulbeesley3/edusweep.svg"
             alt="License">
    </a>
    <a href="https://www.codefactor.io/repository/github/paulbeesley3/edusweep">
        <img src="https://www.codefactor.io/repository/github/paulbeesley3/edusweep/badge"
            alt="CodeFactor Score">
    </a>
    <a href="https://edusweep.readthedocs.io/en/latest/">
        <img src="https://img.shields.io/readthedocs/edusweep.svg"
            alt="Documentation">
    </a>
    <a href="https://ci.appveyor.com/project/paulbeesley3/edusweep">
        <img src="https://img.shields.io/appveyor/ci/paulbeesley3/edusweep/master.svg"
            alt="AppVeyor Build Status">
    </a>
</p>

EduSweep is a tool for finding and removing unwanted files - based on their extension, their
name, or their content. It helps to keep your network free of files that contravene your usage
policies, that take up too much space or that may be vectors for malicious content.

<p align="center">
    <img src="https://raw.githubusercontent.com/paulbeesley3/edusweep/master/docs/screenshots/main/mainwindow.png"
         alt="Main EduSweep Window">
</p>

EduSweep offers features that go beyond what is offered by the built-in Windows search tools;
it can help you to target specific types of unwanted files more easily while also offering
evidence gathering and file inspection tools.

## Features

**Scan tasks** make repeated, regular scans quick and easy to run. Select relevant directories
to scan then quickly target groups of files using signatures (premade sets of things to
detect during the scan). The **Signature Studio** utility lets you create, manage and share custom
signatures that extend the signatures included with the application.

Built-in **reporting tools** support evidence collection, with a report being produced each
time a scan task completes. HTML export of reports is available to facilitate archiving
and printing.

**Quarantine** functionality allows you to store files for further inspection, while the included
**File Inspector** utility can offer insights into a file's true content using TrID technology to
identify file types based on their binary signatures. This helps in finding files that have
been disguised by having their extension changed.

The latest version of EduSweep adds **ClamAV integration**. This allows you to connect EduSweep
to a ClamAV server (clamd) so that any files detected during an EduSweep scan will be automatically
scanned for viruses, adding another layer of protection and threat detection.

## Feedback & Support
### Assistance
Ask a question on the [EduGeek Forum](http://www.edugeek.net/forums/edusweep).

### Request a Feature
View and create [Feature Requests](https://github.com/paulbeesley3/EduSweep/labels/enhancement).

### Report an Issue
File a bug in [GitHub Issues](https://github.com/paulbeesley3/EduSweep/issues).

### Something Else?
[Email](https://www.paulbeesley.com/contact) me directly with other feedback.

## License

Copyright (c) Paul Beesley. All rights reserved.

Licensed under the [GNU GPLv3](LICENSE.md) License.
