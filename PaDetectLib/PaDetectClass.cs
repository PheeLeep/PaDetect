using PaDetectLib.ObjectScanners;

namespace PaDetectLib {

    /// <summary>
    /// A core class specialized on checking objects' sizes for possible binary padding.
    /// </summary>
    public static class PaDetectClass {

        /// <summary>
        /// A value based on VirusTotal's latest file size limit to upload.
        /// </summary>
        public const long vtMBAcceptable = 681574399;

        // ----- Delegates
        /// <summary>
        /// A method that sends <see cref="Exception"/> to an event.
        /// </summary>
        /// <param name="ex">An <see cref="Exception"/> contained when an error occurs.</param>
        public delegate void ErrorOccurredDelegate(Exception ex);

        /// <summary>
        /// A method occurs when <see cref="IsOngoing"/> changed its value.
        /// </summary>
        public delegate void OngoingProcessChangedDelegate();

        /// <summary>
        /// A method that sends a status text during the execution.
        /// </summary>
        /// <param name="text">A status text string.</param>
        /// <param name="perce">A percentage of a program in progress.</param>
        /// <param name="newLine">An optional parameter for Console version of PaDetect.</param>
        public delegate void StatusTextOccurredDelegate(string? text, int perce = -1, bool newLine = false);

        /// <summary>
        /// A method occurs when a class found an object being binary padded.
        /// </summary>
        /// <param name="fInfo">A <see cref="FileInfo"/> object involved to binary padding.</param>
        /// <param name="actualLen">An actual length of an object based on the file type's structure.</param>
        /// <param name="fileLen">A length of an object based on the overall structure (including padding).</param>
        /// <param name="isRemoved">A boolean determined whether a padded object was removed.</param>
        public delegate void FilePaddingDetectedDelegate(FileInfo fInfo, long actualLen, long fileLen, bool isRemoved = false);

        /// <summary>
        /// A method occurs when a class' scan process was finished.
        /// </summary>
        public delegate void ScanFinishedDelegate();

        // ----- Enums

        /// <summary>
        /// An enumeration based on the target object type. 
        /// </summary>
        public enum ScanTypeE {

            /// <summary>
            /// A program will target a file object.
            /// </summary>
            File,

            /// <summary>
            /// A program will target objects from a folder and its subfolders.
            /// </summary>
            Folder,

            /// <summary>
            /// A program will target objects from a drive and its subfolders.
            /// </summary>
            Drive,

            /// <summary>
            /// A program will target objects from all drives connected to the computer.
            /// </summary>
            All,

            /// <summary>
            /// Unspecified target type. Considered as invalid.
            /// </summary>
            Unspecified
        }

        // ----- Properties

        /// <summary>
        /// Gets the value whether a class is ongoing in scan.
        /// </summary>
        public static bool IsOngoing {
            get => isOngoing;
            internal set {
                if (isOngoing == value) return;
                isOngoing = value;
                OngoingProcessChanged?.Invoke();
            }
        }

        /// <summary>
        /// Gets or sets the value for a program's tolerance in objects' padded size.
        /// </summary>
        public static long Tolerance {
            get => tolerance;
            set {
                if (value < 10 || value > 75 || IsOngoing) return;
                tolerance = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="ScanTypeE"/> value based on last <see cref="StartScan"/> invoke.
        /// </summary>
        public static ScanTypeE ScanType { get; internal set; }

        /// <summary>
        /// Gets the object path based on last <see cref="StartScan"/> invoke.
        /// </summary>
        public static string ObjectPath { get; internal set; } = string.Empty;

        /// <summary>
        /// Gets whether the user allows a program to remove padded bytes.
        /// </summary>
        public static bool UnpadRequested { get; internal set; }

        /// <summary>
        /// Gets whether a user requested a cancel during execution.
        /// </summary>
        public static bool CancelRequestPending { get; internal set; }

        /// <summary>
        /// Gets the number of objects scanned.
        /// </summary>
        public static long ObjectsScanned { get; internal set; }

        /// <summary>
        /// Gets the number of objects found padded.
        /// </summary>
        public static long ObjectsFoundPadded { get; internal set; }

        /// <summary>
        /// Gets the number of padded objects were fixed.
        /// </summary>
        public static long PaddedObjectsFixed { get; internal set; }

        /// <summary>
        /// Gets or sets the minimum size of file to be bypass despite
        /// of its binary padding.
        /// </summary>
        /// <remarks>
        /// This property should be modify with caution to prevent false positives
        /// and false negatives, especially uninstallers and other files that has
        /// purpose overlay padding like attributes.
        /// </remarks>
        public static long MinimumObjectSize {
            get => mbTolerance;
            set {
                if (value < 26214200 || value > vtMBAcceptable || IsOngoing) return;
                mbTolerance = value;
            }
        }

        /// <summary>
        /// Gets whether the original object will be deleted after unpadding.
        /// </summary>
        public static bool DeleteObjectAfterUnpad { get; internal set; }

        // ----- Events

        /// <summary>
        /// Occurs when an error was passed from the execution process.
        /// </summary>
        public static event ErrorOccurredDelegate? ErrorOccurred;

        /// <summary>
        /// Occurs when an <see cref="IsOngoing"/> property changed.
        /// </summary>
        public static event OngoingProcessChangedDelegate? OngoingProcessChanged;

        /// <summary>
        /// Occurs when passing a string text status.
        /// </summary>
        public static event StatusTextOccurredDelegate? StatusTextOccurred;

        /// <summary>
        /// Occurs when an object was detected as binary padded.
        /// </summary>
        public static event FilePaddingDetectedDelegate? FilePaddingDetected;

        /// <summary>
        /// Occurs when a scan from <see cref="StartScan(string, ScanTypeE, bool, bool)"/> was finished.
        /// </summary>
        public static event ScanFinishedDelegate? ScanFinished;

        // ----- Variables

        private static readonly object locker = new();
        private static bool isOngoing = false;
        private static long tolerance = 15;
        private static long mbTolerance = 104857600; // 100 MB
        private static long totalObjects = 0;
        // ----- Methods

        /// <summary>
        /// Performs an object scan based on the given parameter values, in a thread-level process.
        /// </summary>
        /// <param name="objectPath">An object path target for scanning.</param>
        /// <param name="scanType">A scan type for a target object.</param>
        /// <param name="unPad">Determines whether a program allows to unpad once an object detects.</param>
        /// <param name="delOrig">Determines whether a program will delete the original object after unpad process.</param>
        public static void StartScan(string objectPath, ScanTypeE scanType, bool unPad = false, bool delOrig = false) {
            lock (locker) {
                if (IsOngoing) {
                    ErrorOccurred?.Invoke(new InvalidOperationException("Unable to run another scan while the previous was ongoing."));
                    return;
                }
                if (string.IsNullOrEmpty(objectPath)) {
                    ErrorOccurred?.Invoke(new ArgumentNullException(nameof(objectPath)));
                    return;
                }

                ObjectPath = objectPath;
                ScanType = scanType;
                UnpadRequested = unPad;
                DeleteObjectAfterUnpad = delOrig;
                Thread t = new(() => {
                    string pathToScanDetail = ScanType == ScanTypeE.All ? "all drives in this computer" : "('" + ObjectPath + "')";
                    StatusTextOccurred?.Invoke("Initialized scanning on " + pathToScanDetail + "... (Time: " + DateTime.Now.ToString("dd/MM/yy hh:mm") + ")", -1, true);
                    StatusTextOccurred?.Invoke("Minimum size acceptable: " + (MinimumObjectSize / 1024 / 1024).ToString() + " MB", -1, true);
                    ThreadStartScan();
                    StatusTextOccurred?.Invoke("A scan was finished. (Time: " + DateTime.Now.ToString("dd/MM/yy hh:mm") + ")", -1, true);
                }) {
                    Priority = ThreadPriority.Highest
                };
                IsOngoing = true;
                t.Start();
            }

        }

        /// <summary>
        /// Invokes a cancellation pending of scanning objects.
        /// </summary>
        public static void CancelScan() {
            lock (locker) {
                if (!IsOngoing || CancelRequestPending) return;
                CancelRequestPending = true;
            }
        }

        /// <summary>
        /// A method used for actual scan process. Invoke it inside <see cref="Thread"/> to prevent
        /// freezing in the GUI form, and performs efficiently.
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="DriveNotFoundException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        private static void ThreadStartScan() {
            try {
                totalObjects = 0;
                ObjectsScanned = 0;
                ObjectsFoundPadded = 0;
                PaddedObjectsFixed = 0;

                if (ScanType == ScanTypeE.Unspecified)
                    throw new InvalidOperationException("Invalid scan type specified.");

                if (ScanType == ScanTypeE.All) {
                    DriveInfo[] drives = DriveInfo.GetDrives();

                    foreach (DriveInfo drive in drives) {
                        if (CancelRequestPending) break;
                        if (!drive.IsReady) continue;
                        StatusTextOccurred?.Invoke("Enumerating objects inside '" + drive.RootDirectory.Name + "'...");
                        EnumerateAllObjects(drive.RootDirectory);
                    }

                    foreach (DriveInfo d in drives) {
                        if (CancelRequestPending) break;
                        if (!d.IsReady) {
                            StatusTextOccurred?.Invoke("The drive '" + d.Name + "' is not ready.");
                            continue;
                        }
                        if (d.DriveType != DriveType.Fixed)
                            StatusTextOccurred?.Invoke("The drive '" + d.Name + "' is not fixed. Please don't remove this drive while scanning.");
                        RecursiveScanObjects(d.RootDirectory);
                    }
                    return;
                }

                if (string.IsNullOrEmpty(ObjectPath)) throw new InvalidOperationException(nameof(ObjectPath) + " is null.");

                DriveInfo dr = new DriveInfo(ObjectPath);
                if (!dr.IsReady) throw new DriveNotFoundException("Couldn't find a drive '" + dr.Name + "' or it's not ready yet.");
                if (dr.DriveType != DriveType.Fixed)
                    StatusTextOccurred?.Invoke("The drive '" + dr.Name + "' is not fixed. Please don't remove this drive while scanning.");

                switch (ScanType) {
                    case ScanTypeE.File:
                        if (!File.Exists(ObjectPath)) throw new FileNotFoundException("A file '" + ObjectPath + "' is not exists or it's a directory.");
                        totalObjects++;
                        FileInfo f = new FileInfo(ObjectPath);
                        StatusTextOccurred?.Invoke("Scanning '" + f.Name + "'... (" + ObjectsScanned.ToString() + " objects scanned.)", GetPercentage());
                        StartAnalyzeObject(f);
                        ObjectsScanned++;
                        break;
                    case ScanTypeE.Folder:
                        if (!Directory.Exists(ObjectPath)) throw new FileNotFoundException("A directory '" + ObjectPath + "' is not exist.");
                        DirectoryInfo dInfo = new DirectoryInfo(ObjectPath);
                        StatusTextOccurred?.Invoke("Enumerating objects inside '" + dInfo.Name + "'...");
                        EnumerateAllObjects(dInfo);
                        RecursiveScanObjects(dInfo);
                        break;
                    case ScanTypeE.Drive:
                        StatusTextOccurred?.Invoke("Enumerating objects inside '" + dr.RootDirectory.Name + "'...");
                        EnumerateAllObjects(dr.RootDirectory);
                        RecursiveScanObjects(dr.RootDirectory);
                        break;
                }

            } catch (Exception ex) {
                ErrorOccurred?.Invoke(ex);
            } finally {
                if (!CancelRequestPending) ScanFinished?.Invoke();
                CancelRequestPending = false;
                IsOngoing = false;
            }
        }

        /// <summary>
        /// Recursively enumerate all objects inside the targeted <see cref="DirectoryInfo"/>.
        /// </summary>
        /// <param name="dInfo">A current <see cref="DirectoryInfo"/> object.</param>
        private static void EnumerateAllObjects(DirectoryInfo dInfo) {
            if (dInfo == null) return;
            try {
                totalObjects += dInfo.EnumerateFiles().Count();
                List<DirectoryInfo> directories = new(dInfo.EnumerateDirectories());
                for (int i = 0; i < directories.Count; i++) {
                    if (CancelRequestPending) return;
                    EnumerateAllObjects(directories[i]);
                }
            } catch {
                // Ignore this when unauthorized access error occurred.
            }
        }

        /// <summary>
        /// Recursively scan objects from a <see cref="DirectoryInfo"/> and its subdirectories.
        /// </summary>
        /// <param name="dInfo">A current <see cref="DirectoryInfo"/> object.</param>
        private static void RecursiveScanObjects(DirectoryInfo dInfo) {
            if (dInfo == null) return;
            try {
                StatusTextOccurred?.Invoke("Scanning objects inside '" + dInfo.Name + "'... (" + ObjectsScanned.ToString() + " objects scanned.)");
                List<FileInfo> files = new List<FileInfo>(dInfo.EnumerateFiles());
                for (int i = 0; i < files.Count; i++) {
                    if (CancelRequestPending) return;
                    StatusTextOccurred?.Invoke("Scanning '" + files[i].Name + "'... (" + ObjectsScanned.ToString() + " objects scanned.)", GetPercentage());
                    StartAnalyzeObject(files[i]);
                    ObjectsScanned++;
                }
            } catch {
                // Ignore this when unauthorized access error occurred.
            }

            // Recursive in finding directories.
            try {
                List<DirectoryInfo> directories = new(dInfo.EnumerateDirectories());
                for (int i = 0; i < directories.Count; i++) {
                    if (CancelRequestPending) return;
                    RecursiveScanObjects(directories[i]);
                }
            } catch {
                // Ignore this when unauthorized access error occurred.
            }
        }

        /// <summary>
        /// Performs a construction of object analyzer classes and scans for possible binary padding.
        /// </summary>
        /// <param name="f">A current <see cref="FileInfo"/> object.</param>
        private static void StartAnalyzeObject(FileInfo f) {
            if (f.Length == 0) return;
            BlankFileObjectScanner? obj = BlankFileObjectScanner.ConstructFileObject(f);
            if (obj == null) return;
            InternalAnalyzeObject(obj);
        }

        /// <summary>
        /// Performs an actual object analyzer for possible binary padding.
        /// </summary>
        /// <param name="obj">A current <see cref="BlankFileObjectScanner"/>-derived object.</param>
        /// <returns>Returns true if analyzing object succeed, otherwise false.</returns>
        private static void InternalAnalyzeObject(BlankFileObjectScanner obj) {
            if (obj == null) return;
            try {
                FileInfo f = new FileInfo(obj.FileName);
                obj.CheckForPad();
                if (obj.IsPadded) {
                    FilePaddingDetected?.Invoke(f, obj.ActualLength, obj.Length, false);
                    ObjectsFoundPadded++;
                    try {
                        if (UnpadRequested) {
                            // Copy the length as some BFOS-derived classes will dispose after
                            // invoking AxisPrayPad()
                            long actLen = obj.ActualLength;
                            long fLen = obj.Length;
                            obj.AxisPrayPad();

                            FilePaddingDetected?.Invoke(f, actLen, fLen, true);
                            PaddedObjectsFixed++;
                        }
                    } catch (Exception ex) {
                        ErrorOccurred?.Invoke(ex);
                    }
                }
            } catch (Exception ex) {
                ErrorOccurred?.Invoke(ex);
            } finally {
                if (!obj.IsDisposed) obj.Dispose();
            }
        }

        private static int GetPercentage() {
            if (totalObjects == 0) return 0;
            if (ObjectsScanned > totalObjects) return 100;
            return (int)(ObjectsScanned * 100 / totalObjects);
        }
    }
}