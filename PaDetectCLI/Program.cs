using PaDetectLib;

namespace PaDetectCLI;
static class Program {

    /// <summary>
    /// A main entry of a program.
    /// </summary>
    /// <param name="args">An arguments provided when executing a program.</param>
    /// <returns>Returns an number specifying exit codes.</returns>
    static int Main(string[] args) {
        Console.TreatControlCAsInput = true;
        bool removePadsRequest = false;
        bool cancelOccurred = false;
        bool alreadySetTolerance = false;
        bool alreadySetMinSize = false;
        bool removeOrigObject = false;

        Console.Title = "PaDetect Console";
        Console.WriteLine(Properties.Resources.Logo);
        if (args.Length == 0 || args[0].Equals("-h")) {
            Console.WriteLine(Properties.Resources.HelpFile);
            return 0;
        }

        PaDetectClass.ScanTypeE scanType = PaDetectClass.ScanTypeE.Unspecified;

        string objectPath = string.Empty;
        for (int i = 0; i < args.Length; i++) {
            switch (args[i]) {
                case "--del-orig":
                    if (removeOrigObject) {
                        CommandLineEx.PrintLine("Delete original object already set.", CommandLineEx.PrintType.Warning);
                        break;
                    }
                    removeOrigObject = true;
                    break;
                case "--min-size":
                    if (alreadySetMinSize) {
                        CommandLineEx.PrintLine("Minimum size tolerance already set.", CommandLineEx.PrintType.Warning);
                        break;
                    }
                    if ((i + 1) >= args.Length || !long.TryParse(args[i + 1], out long minSize)) {
                        CommandLineEx.PrintLine("Minimum size value is invalid.", CommandLineEx.PrintType.Warning);
                        return 1;
                    }

                    minSize = 1024 * 1024 * minSize;

                    if (minSize < 26214200 || minSize > PaDetectClass.vtMBAcceptable) {
                        CommandLineEx.PrintLine("Minimum size value is invalid. (Range: 25 MB to "
                            + (PaDetectClass.vtMBAcceptable / 1024 / 1024) + " MB)", CommandLineEx.PrintType.Warning);
                        return 1;
                    }
                    PaDetectClass.MinimumObjectSize = minSize;
                    i++;
                    break;
                case "-t":
                    if (alreadySetTolerance) {
                        CommandLineEx.PrintLine("Tolerance already set.", CommandLineEx.PrintType.Warning);
                        break;
                    }
                    if ((i + 1) >= args.Length || !long.TryParse(args[i + 1], out long tolerance) || tolerance < 10 || tolerance > 75) {
                        CommandLineEx.PrintLine("Tolerance value not specified or invalid.", CommandLineEx.PrintType.Warning);
                        return 1;
                    }
                    PaDetectClass.Tolerance = tolerance;
                    i++;
                    break;
                case "-x":
                    removePadsRequest = true;
                    break;
                case "-a":
                case "-d":
                case "-D":
                case "-f":
                    if (scanType != PaDetectClass.ScanTypeE.Unspecified) {
                        CommandLineEx.PrintLine("Target object already specified.", CommandLineEx.PrintType.Info);
                        break;
                    }
                    if (args[i].Equals("-a")) {
                        scanType = PaDetectClass.ScanTypeE.All;
                        break;
                    }
                    if ((i + 1) >= args.Length) {
                        CommandLineEx.PrintLine("Cannot find the specified object.", CommandLineEx.PrintType.Warning);
                        return 1;
                    }
                    try {
                        objectPath = Path.GetFullPath(args[i + 1]);
                    } catch {
                        CommandLineEx.PrintLine("Invalid path given.", CommandLineEx.PrintType.Warning);
                        return 1;
                    }
                    switch (args[i]) {
                        case "-d":
                            scanType = PaDetectClass.ScanTypeE.Folder;
                            break;
                        case "-D":
                            scanType = PaDetectClass.ScanTypeE.Drive;
                            break;
                        case "-f":
                            scanType = PaDetectClass.ScanTypeE.File;
                            break;
                    }
                    i++;
                    break;
                default:
                    CommandLineEx.PrintLine("Invalid parameter specified. Use -h to know the arguments available.", CommandLineEx.PrintType.Warning);
                    return 1;
            }
        }

        // Attach the events.
        PaDetectClass.ErrorOccurred += PaDetectClass_ErrorOccurred;
        PaDetectClass.StatusTextOccurred += PaDetectClass_StatusTextOccurred;
        PaDetectClass.FilePaddingDetected += PaDetectClass_FilePaddingDetected;
        PaDetectClass.OngoingProcessChanged += PaDetectClass_OngoingProcessChanged;
        PaDetectClass.ScanFinished += PaDetectClass_ScanFinished;

        // Start the scanning process.
        PaDetectClass.StartScan(objectPath, scanType, removePadsRequest, removeOrigObject);
        while (PaDetectClass.IsOngoing && !PaDetectClass.CancelRequestPending) {
            if (!Console.KeyAvailable) continue;
            if (Console.ReadKey(true).Key != ConsoleKey.C) continue;
            PaDetectClass.CancelScan();
            cancelOccurred = true;
        }

        if (cancelOccurred) {
            CommandLineEx.ClearLine();
            CommandLineEx.PrintLine("Scan operation was cancelled.", CommandLineEx.PrintType.Warning);
        }
        return 0;
    }

    /// <summary>
    /// Generates a conclusion based on the result from <see cref="PaDetectClass"/>.
    /// </summary>
    /// <returns>Returns a string containing conclusion from <see cref="PaDetectClass"/>'s result.</returns>
    private static string GenerateConclusion() {
        if (PaDetectClass.CancelRequestPending) return "A user invoke a cancellation.";
        if (PaDetectClass.ObjectsScanned == 0) return "No objects scanned. No further actions needed.";
        if (PaDetectClass.ObjectsFoundPadded == 0)
            return PaDetectClass.ObjectsScanned.ToString() + " object/s scanned. No further actions needed.";
        if (PaDetectClass.ObjectsFoundPadded == PaDetectClass.PaddedObjectsFixed)
            return PaDetectClass.PaddedObjectsFixed.ToString() + " object/s found binary padded, and it's now fixed.";
        return (PaDetectClass.ObjectsFoundPadded - PaDetectClass.PaddedObjectsFixed).ToString() +
            " object/s found binary padded, and it was not fixed due to an error or analyze only.";
    }

    private static void PaDetectClass_ScanFinished() {
        // Summarization.
        Console.WriteLine(Environment.NewLine + Environment.NewLine + "Summary:");
        Console.WriteLine(new string('-', 15));
        Console.WriteLine(GenerateConclusion() + Environment.NewLine);
        Console.WriteLine("No. of Objects Scanned: " + PaDetectClass.ObjectsScanned.ToString());
        Console.WriteLine("No. of Objects Found Padded: " + PaDetectClass.ObjectsFoundPadded.ToString());
        if (PaDetectClass.UnpadRequested)
            Console.WriteLine("No. of Padded Objects were Fixed: " + PaDetectClass.PaddedObjectsFixed.ToString());
        Console.WriteLine();
    }

    private static void PaDetectClass_OngoingProcessChanged() {
        if (PaDetectClass.IsOngoing) {
            CommandLineEx.PrintLine("A scanning process is ongoing, this may take a while. Press C to cancel.", CommandLineEx.PrintType.Info);
        }
    }

    private static void PaDetectClass_FilePaddingDetected(FileInfo fInfo, long actualLen, long fileLen, bool isRemoved) {
        long perce = (fileLen - actualLen) * 100 / fileLen;
        CommandLineEx.ClearLine();
        if (!isRemoved) {
            CommandLineEx.PrintLine("'" + fInfo.Name + "' >> Abnormally Large Size. (" + perce.ToString() + "% padded)", CommandLineEx.PrintType.Warning);
            return;
        }
        CommandLineEx.PrintLine("'" + fInfo.Name + "' >> Binary padding removed.", CommandLineEx.PrintType.Info);
    }

    private static void PaDetectClass_StatusTextOccurred(string? text, int perce = -1, bool newLine = false) {
        CommandLineEx.ClearLine();
        if (perce >= 0) {
            CommandLineEx.PrintProgressBar(perce, 100, text + (newLine ? Environment.NewLine : ""));
            return;
        }
        CommandLineEx.Print(text + (newLine ? Environment.NewLine : ""));
    }

    private static void PaDetectClass_ErrorOccurred(Exception ex) {
        CommandLineEx.ClearLine();
        CommandLineEx.PrintLine("An error occurred (" + ex.Message + ")", CommandLineEx.PrintType.Error);
    }
}
