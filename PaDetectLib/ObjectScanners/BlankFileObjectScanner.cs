namespace PaDetectLib.ObjectScanners {

    /// <summary>
    /// An abstract object scanner class, which can be use to inherit class specially crafted
    /// to scan and remove binary padding from different file types.
    /// </summary>
    internal abstract class BlankFileObjectScanner : IDisposable {
        private readonly FileStream fs;
        private bool disposedValue;

        /// <summary>
        /// Gets if the class was disposed.
        /// </summary>
        internal bool IsDisposed { get => disposedValue; }

        /// <summary>
        /// Gets the <seealso cref="string"/> value containing the path of a target object.
        /// </summary>
        internal string FileName { get; set; }

        /// <summary>
        /// Gets whether the target object was padded or not.
        /// </summary>
        /// <remarks>
        /// Use <see cref="AlreadyScanned"/> to check if the class is already scanned,
        /// as an additional credibility if the <see cref="IsPadded"/> was false.
        /// </remarks>
        internal bool IsPadded { get; set; }

        /// <summary>
        /// Gets the current position of an object's stream.
        /// </summary>
        internal long Position => fs.Position;

        /// <summary>
        /// Gets the total length of an object, based on the stream's total length.
        /// </summary>
        internal long Length => fs.Length;

        /// <summary>
        /// Gets the total length of an object, based on the structure length of a specific file type.
        /// </summary>
        internal long ActualLength { get; set; }

        /// <summary>
        /// Gets the value whether the current class was already scanned the target object.
        /// </summary>
        internal bool AlreadyScanned { get; private set; } = false;

        /// <summary>
        /// Initializes a new base class of <see cref="BlankFileObjectScanner"/>.
        /// </summary>
        /// <param name="f">A current <see cref="FileInfo"/> object.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FileNotFoundException"></exception>
        protected BlankFileObjectScanner(FileInfo f) {
            if (f == null) throw new ArgumentNullException(nameof(f));
            if (!f.Exists) throw new FileNotFoundException("A file '" + f.FullName + "' does not exists.");
            FileName = f.FullName;
            IsPadded = false;
            fs = f.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        }

        /// <summary>
        /// Performs a check of an object for possible presence of binary padding.
        /// </summary>
        /// <remarks>
        /// Must call the base version of this method, before proceeding the following
        /// codes from the derived class. Example:
        /// <code>
        ///  internal override void CheckForPad() {
        ///    base.CheckForPad();
        ///    // The rest of the code.
        ///  }
        /// </code>
        /// </remarks>
        internal virtual void CheckForPad() {
            if (IsDisposed) throw new ObjectDisposedException(GetType().Name);
            ResetStreamPosition();
        }

        /// <summary>
        /// Performs a padding removal from an object.
        /// </summary>
        /// <remarks>
        /// Must call the base version of this method, before proceeding the following
        /// codes from the derived class. Example:
        /// <code>
        ///  internal override void AxisPrayPad() {
        ///    base.AxisPrayPad();
        ///    // The rest of the code.
        ///  }
        /// </code>
        /// </remarks>
        internal virtual void AxisPrayPad() {
            // Reference: Konosuba Season 2, Episode 9 (06:18)

            if (IsDisposed) throw new ObjectDisposedException(GetType().Name);
            if (!AlreadyScanned) throw new InvalidOperationException("The object wasn't scanned yet.");
            ResetStreamPosition();
        }

        /// <summary>
        /// Invokes to set <see cref="AlreadyScanned"/> as true.
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        protected void InvokeAsAlreadyScanned() {
            if (disposedValue) throw new ObjectDisposedException(GetType().Name);
            AlreadyScanned = true;
        }

        /// <summary>
        /// Reads an array of bytes, based on the size and offset specified.
        /// </summary>
        /// <param name="lengthToRead">A length of bytes required to read.</param>
        /// <param name="offset">An offset in which where should it start reading.</param>
        /// <returns>Returns a byte array containing data from an object.</returns>
        /// <exception cref="ObjectDisposedException"></exception>
        internal byte[] Read(int lengthToRead, int offset) {
            if (disposedValue) throw new ObjectDisposedException(GetType().Name);
            byte[] result = new byte[lengthToRead];
            fs.Read(result, offset, result.Length);
            return result;
        }

        /// <summary>
        /// Performs a <see cref="FileStream.Seek(long, SeekOrigin)"/> inside the class.
        /// <br />
        /// (<inheritdoc cref="FileStream.Seek(long, SeekOrigin)"/>)
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal void Seek(long position, SeekOrigin origin) {
            if (disposedValue) throw new ObjectDisposedException(GetType().Name);
            if (position < 0 || position >= fs.Length) throw new ArgumentOutOfRangeException(nameof(position));
            fs.Seek(position, origin);
        }

        /// <summary>
        /// Moves the object's stream position freely.
        /// </summary>
        /// <param name="pos">A value to set stream's position.</param>
        /// <exception cref="ObjectDisposedException"></exception>
        internal void MovePosition(long pos) {
            if (disposedValue) throw new ObjectDisposedException(GetType().Name);
            fs.Position = pos;
        }

        /// <summary>
        /// Resets the object's stream position.
        /// </summary>
        /// <exception cref="ObjectDisposedException"></exception>
        internal void ResetStreamPosition() {
            if (disposedValue) throw new ObjectDisposedException(GetType().Name);
            fs.Seek(0, SeekOrigin.Begin);
        }

        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                if (disposing) {
                    FileName = string.Empty;
                    IsPadded = false;
                }
                disposedValue = true;
                fs.Close();
            }
        }

        public void Dispose() {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Generates the specified <see cref="BlankFileObjectScanner"/> class, based on
        /// the file's extension.
        /// </summary>
        /// <param name="f">A current <see cref="FileInfo"/> object.</param>
        /// <returns>
        /// Returns a derived version of <see cref="BlankFileObjectScanner"/> 
        /// based on file type.
        /// </returns>
        internal static BlankFileObjectScanner? ConstructFileObject(FileInfo f) {
            return f.Extension.ToLower() switch {
                ".exe" or ".scr" or ".dll" or ".com" => new PEFileObjectScanner(f),
                _ => null,
            };
        }
    }
}
