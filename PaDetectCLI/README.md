# PaDetectCLI

## Description
PaDetectCLI (Pad Detect Console) is a cross-platform console of PaDetect.
The purpose is to check and detect objects for possible binary-padding obfuscation,
and removing it once found.

## Usage

```cmd
PaDetectCLI [scan options] [options]
```
### Scan Options:
	-f <path> : Scan the specified file object.
	-d <path> : Scan the directory and its subdirectories for file objects.
	-D <path> : Scan all file objects inside the specified drive.
	-a        : Scan all file objects inside the computer and connected drives.

### Options:
	--min-size <mb> : Sets the value of minimum of object's size to be allowed
                      despite of binary padding. (not recommended to modify
                      unless it's necessary.) 
					  
                      Range: 25 MB to 650 MB (follows VirusTotal's max. size)
                      Default: 100MB

	-x              : Remove padded bytes from a file object once detected.
	-t <value>      : Set the tolerance when comparing file size (from 10% to 75%)

	                  Default: 15%
## Compile
[Refer to this link.](https://github.com/PheeLeep/PaDetect/blob/master/README.md#compile)