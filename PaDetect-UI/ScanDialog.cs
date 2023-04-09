using static PaDetectLib.PaDetectClass;

namespace PaDetect_UI {
    public partial class ScanDialog : Form {

        private bool isChecking = false;
        private readonly object locker = new object();

        public ScanTypeE ScanType { get; private set; } = ScanTypeE.File;
        public string TargetObject { get; private set; } = string.Empty;
        public bool RemovePadsPermitted { get => RemoveConfirmationCBox.Checked; }

        public ScanDialog() {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
        protected override CreateParams CreateParams {
            get {
                // Minimize form and control flickering.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        private void CheckChanged_Invoked(object sender, EventArgs e) {
            if (sender == FullScanRDButton) {
                ScanObjectPanel.Hide();
                DescriptionLabel.Text = "Scan the whole drives attached to the computer.";
                ScanType = ScanTypeE.All;
                return;
            }
            ScanObjectPanel.Show();
            PathTextBox.Clear();
            if (sender == FileScanRDButton) {
                DescriptionLabel.Text = "Scan a specific file for checking a possible binary padding.";
                ScanType = ScanTypeE.File;
                return;
            }
            if (sender == FolderScanRDButton) {
                DescriptionLabel.Text = "Scan objects inside the target folder and its subfolders. ";
                ScanType = ScanTypeE.Folder;
                return;
            }
            if (sender == DriveScanRDButton) {
                DescriptionLabel.Text = "Scan all objects inside the drive.";
                ScanType = ScanTypeE.Drive;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e) {
            if (PathTextBox.Text.Length == 0 && ScanType != ScanTypeE.All) {
                MessageBox.Show(this, "Please specify the object to scan.", "No object/s specified.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (ScanType != ScanTypeE.All) {
                DriveInfo dr = new DriveInfo(PathTextBox.Text);
                if (!dr.IsReady) {
                    MessageBox.Show(this, "Specified drive is not fully initialized.", "No object/s specified.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                switch (ScanType) {
                    case ScanTypeE.File:
                        if (!File.Exists(PathTextBox.Text)) {
                            MessageBox.Show(this, "Object doesn't exist.", "No object/s specified.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        break;
                    case ScanTypeE.Folder:
                        if (!Directory.Exists(PathTextBox.Text)) {
                            MessageBox.Show(this, "Object doesn't exist.", "No object/s specified.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        break;
                    case ScanTypeE.Drive:
                        break;
                }
                if (dr.DriveType != DriveType.Fixed && MessageBox.Show(this, "The specified object is in a drive that is not fixed type (ie: removable drive) " +
                    "and it may cause interruption of the scan/unpad progress. Continue anyway?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                    return;
            }
            TargetObject = PathTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void PathTextBox_TextChanged(object sender, EventArgs e) {
            if (isChecking) return;
            lock (locker) {
                isChecking = true;
                try {
                    if (PathTextBox.Text.Length == 0) {
                        ShowDriveNotFixedLabel.Hide();
                        isChecking = false;
                        return;
                    }
                    DriveInfo dr = new DriveInfo(PathTextBox.Text);
                    if (!dr.IsReady) throw new InvalidOperationException("The drive is not ready.");
                    if (dr.DriveType != DriveType.Fixed) {
                        ShowDriveNotFixedLabel.Text = "Warning: The specified object was inside the drive that is not a fixed type.";
                        ShowDriveNotFixedLabel.ForeColor = Color.Yellow;
                        ShowDriveNotFixedLabel.Show();
                        isChecking = false;
                        return;
                    }
                    ShowDriveNotFixedLabel.Hide();
                } catch (Exception ex) {
                    ShowDriveNotFixedLabel.Text = "Warning: " + ex.Message;
                    ShowDriveNotFixedLabel.ForeColor = Color.Red;
                    ShowDriveNotFixedLabel.Show();
                }
                isChecking = false;
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e) {
            switch (ScanType) {
                case ScanTypeE.File:
                    if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
                    PathTextBox.Text = openFileDialog1.FileName; break;
                case ScanTypeE.Folder:
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.Cancel) return;
                    PathTextBox.Text = folderBrowserDialog1.SelectedPath; break;
                case ScanTypeE.Drive:
                    using (SelectDriveDialog sdd  = new SelectDriveDialog()) {
                        if (sdd.ShowDialog(this) == DialogResult.Cancel) return;
                        PathTextBox.Text = sdd.DriveName;
                    }
                    break;
            }
        }
    }
}
