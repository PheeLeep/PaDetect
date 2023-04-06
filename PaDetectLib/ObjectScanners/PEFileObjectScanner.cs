namespace PaDetectLib.ObjectScanners {

    /// <summary>
    /// An <see cref="BlankFileObjectScanner"/>-derived class for scanning objects
    /// that are PE (Portable Executable)-based (.exe, .scr, .dll).
    /// </summary>
    internal class PEFileObjectScanner : BlankFileObjectScanner {

        /// <summary>
        /// Instantiate a new <see cref="PEFileObjectScanner"/> class.
        /// </summary>
        /// <param name="f">A current <see cref="FileInfo"/> object.</param>
        internal PEFileObjectScanner(FileInfo f) : base(f) { }

        internal override void AxisPrayPad() {
            base.AxisPrayPad();
            FileInfo? og = new FileInfo(FileName);
            if (og.Directory == null) throw new InvalidOperationException("Couldn't initialize the operation properly.");
            FileInfo unpadded = new FileInfo(Path.Combine(og.Directory.FullName, og.Name.Replace(og.Extension, "") + "_trimmed.bin"));
            if (unpadded.Exists) unpadded.Delete();
            using (FileStream fs = unpadded.Open(FileMode.CreateNew, FileAccess.Write, FileShare.None)) {
                byte[] buffer;
                while (Position < ActualLength) {
                    buffer = Read(1024, 0);
                    fs.Write(buffer, 0, buffer.Length);
                }
            }
            Dispose();
            string newExtFile = Path.ChangeExtension(og.FullName, ".bin");
            og.MoveTo(newExtFile);
        }

        internal override void CheckForPad() {
            base.CheckForPad();
            FileInfo fInfo = new FileInfo(FileName);
            byte[] dosHeader = Read(64, 0);
            if (BitConverter.ToUInt16(dosHeader, 0) != 0x5A4D) // Assume if it has a DOS Magic Number (or 'MZ')
                throw new InvalidOperationException(fInfo.FullName + " >> Not a PE executable. (Invalid DOS Header)");

            long NTHeaderOffset = BitConverter.ToUInt32(dosHeader, 0x3C);
            Seek(NTHeaderOffset, SeekOrigin.Begin);
            byte[] NTHeader = Read(24, 0);

            if (BitConverter.ToUInt32(NTHeader, 0) != 0x4550) // Assume if it's NT Magic Number (or PE\0\0)
                throw new InvalidOperationException(fInfo.FullName + " >> Not a PE executable. (Invalid PE Header)");
            ushort sections = BitConverter.ToUInt16(NTHeader, 6);
            ushort optHeaderSize = BitConverter.ToUInt16(NTHeader, 20);
            byte[] secHeader;

            Seek(optHeaderSize + NTHeaderOffset + NTHeader.Length, SeekOrigin.Begin);
            for (int i = 0; i < sections; i++) {
                // Get the section header and get the data size and pointer.
                secHeader = Read(40, 0);
                int RawDataSize = BitConverter.ToInt32(secHeader, 16);
                int RawDataPointer = BitConverter.ToInt32(secHeader, 20);

                // If the 'i' is equals to section index, add both data pointer and size
                // to the ActualLength as this considered as the end of a section.
                if (i == sections - 1) ActualLength = RawDataPointer + RawDataSize;
            }

            if (Length < ActualLength) throw new InvalidOperationException("Miscalculation error");
            long perce = (Length - ActualLength) * 100 / Length;
            IsPadded = Length >= PaDetectClass.MinimumObjectSize && perce >= PaDetectClass.Tolerance;
            InvokeAsAlreadyScanned();
        }
    }
}
