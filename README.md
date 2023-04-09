# PaDetect

## Description
PaDetect (Pad Detect) is a utility program that checks objects for possible binary
padding obfuscation. It is an essential tool that safely removes a
portion of an object where padding occurs, without any damaging the real
structure of the object.

Malwares like RedLine Stealer are known on using an obfuscation named "Binary 
Padding", and it was already known in [MITRE ATT&CK](https://attack.mitre.org/techniques/T1027/001/) where an object (especially malware)
will be filled with garbage data, making it look very large and
impossible for an antimalware to check.

## File Types Supported
The following file type/s that PaDetect checks are:

- Windows PE Executables (.exe, .dll, .scr)

The following file type/s is planned to support for checking:

- Compression Files (.zip)

## Projects Available
The following projects are will be documented in the upcoming commits.
- [PaDetectLib](https://github.com/PheeLeep/PaDetect/tree/master/PaDetectLib): A core
library of PaDetect projects.
- [PaDetectCLI](https://github.com/PheeLeep/PaDetect/tree/master/PaDetectCLI): A cross-platform console of PaDetect.
- [PaDetect-UI](https://github.com/PheeLeep/PaDetect/tree/master/PaDetect-UI): A Windows-based Graphical User Interface (GUI) of PaDetect,
with simple and ease-of-use interaction for beginner users.

## Releases
The Release section will be available in the upcoming commits. 

A .NET 7 (SDK or Runtime) is required in order to run binaries.

## Compile
To build a project, clone this repository first by typing:
```cmd
git clone https://github.com/PheeLeep/PaDetect
```
then, go to the folder where you cloned a repository, open your favorite terminal (sometimes by right-clicking the empty area
of a folder), and then build by typing:
```cmd
dotnet build
```

The build binaries are located in project's bin/(Debug or Release).

(A .NET 7 SDK is required to build PaDetect project.)
## License
This repository is under [MIT License](https://github.com/PheeLeep/PaDetect/blob/master/LICENSE.txt).
