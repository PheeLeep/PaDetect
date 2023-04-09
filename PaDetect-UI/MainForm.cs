using PaDetectLib;

namespace PaDetect_UI {
    public partial class MainForm : Form {
        private PaDetectClass.ScanTypeE prevScanType = PaDetectClass.ScanTypeE.Unspecified;
        private string prevObject = string.Empty;
        private bool prevPadRemoveReq = false;
        private readonly object locker = new object();
        private bool invokedCancel = false;

        public MainForm() {
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

        private void MainForm_Load(object sender, EventArgs e) {
            SettingsClass.Load();
            PaDetectClass.StatusTextOccurred += PaDetectClass_StatusTextOccurred;
            PaDetectClass.ScanFinished += PaDetectClass_ScanFinished;
            PaDetectClass.OngoingProcessChanged += PaDetectClass_OngoingProcessChanged;
            PaDetectClass.FilePaddingDetected += PaDetectClass_FilePaddingDetected;
        }

        private void PaDetectClass_FilePaddingDetected(FileInfo fInfo, long actualLen, long fileLen, bool isRemoved = false) {
            Invoke(new Action(() => {
                lock (locker) {
                    ListViewItem? lvi = FindResultFromItem(fInfo.FullName);
                    if (lvi == null) {
                        if (listView1.Items.Count == 1000) return;
                        lvi = new ListViewItem(fInfo.FullName);
                        lvi.SubItems.Add(isRemoved.ToString());
                        lvi.SubItems.Add(fileLen.ToString());
                        lvi.SubItems.Add(actualLen.ToString());
                        listView1.Items.Add(lvi);
                        return;
                    }
                    lvi.SubItems[1].Text = isRemoved.ToString();
                }
            }));
        }

        private ListViewItem? FindResultFromItem(string path) {
            if (string.IsNullOrEmpty(path)) return null;
            for (int i = 0; i < listView1.Items?.Count; i++) {
                if (listView1.Items[i].Text.Equals(path))
                    return listView1.Items[i];
            }
            return null;
        }
        private void PaDetectClass_ScanFinished() {
            Invoke(new Action(() => {
                if (PaDetectClass.ObjectsScanned > 0) {
                    if (PaDetectClass.ObjectsFoundPadded > 0) {
                        long paddedRemainings = PaDetectClass.ObjectsFoundPadded - PaDetectClass.PaddedObjectsFixed;
                        if (paddedRemainings == 0) {
                            MainLabel.ForeColor = Color.Lime;
                            MainLabel.Text = PaDetectClass.ObjectsFoundPadded.ToString() + " Object/s found padded, and is now fixed.";
                            SummaryLabel.Text = "All affected objects are now fixed.";
                            FixButton.Hide();
                            return;
                        }
                        MainLabel.ForeColor = Color.Red;
                        MainLabel.Text = paddedRemainings.ToString() + " Object/s found padded.";
                        SummaryLabel.Text = "Some affected objects were not fixed due to error or analysis only.";
                        FixButton.Show();
                        return;
                    }
                    MainLabel.ForeColor = Color.Lime;
                    MainLabel.Text = PaDetectClass.ObjectsScanned.ToString() + " Object/s scanned.";
                    SummaryLabel.Text = "No binary padding objects found.";
                }
            }));
        }

        private void PaDetectClass_OngoingProcessChanged() {
            Invoke(new Action(() => {
                if (!ScanStopButton.Enabled) ScanStopButton.Enabled = true;
                if (PaDetectClass.IsOngoing) {
                    MainLabel.ForeColor = Color.White;
                    MainLabel.Text = "Scanning in progress...";
                    SummaryLabel.Text = "This may take a while depending on the object and your configuration.";
                    ScanStopButton.Text = "Stop";
                    ScanStopButton.BackColor = Color.Red;
                    ScanProgressPanel.BringToFront();
                    return;
                }
                if (invokedCancel) {
                    MainLabel.ForeColor = Color.Yellow;
                    MainLabel.Text = "Scan progress was cancelled.";
                    SummaryLabel.Text = "";
                    invokedCancel = false;
                }
                StatusText.Text = "";
                ObjectsScannedLabel.Text = "Object/s scanned: 0";
                PaddedFoundLabel.Text = "Padded Object/s found: 0";
                PaddedFixedLabel.Text = "Padded Object/s fixed: 0";
                pBar.Value = 0;
                ScanStopButton.Text = "Scan";
                ScanStopButton.BackColor = Color.FromArgb(255, 64, 64, 64);
                SummaryPanel.BringToFront();
            }));
        }

        private void PaDetectClass_StatusTextOccurred(string? text, int perce = -1, bool newLine = false) {
            Invoke(new Action(() => {
                StatusText.Text = "Status: " + text;
                ObjectsScannedLabel.Text = "Object/s scanned: " + PaDetectClass.ObjectsScanned.ToString();
                PaddedFoundLabel.Text = "Padded Object/s found: " + PaDetectClass.ObjectsFoundPadded.ToString();
                PaddedFixedLabel.Text = "Padded Object/s fixed: " + PaDetectClass.PaddedObjectsFixed.ToString();

                if (perce > -1 && perce <= 100) {
                    pBar.Style = ProgressBarStyle.Continuous;
                    pBar.Value = perce;
                }
            }));
        }

        private void ScanStopButton_Click(object sender, EventArgs e) {
            lock (locker) {
                if (!PaDetectClass.IsOngoing) {
                    using (ScanDialog sd = new ScanDialog()) {
                        if (sd.ShowDialog(this) == DialogResult.Cancel) return;
                        prevObject = sd.TargetObject;
                        prevScanType = sd.ScanType;
                        prevPadRemoveReq = sd.RemovePadsPermitted;
                    }
                    FixButton.Hide();
                    ScanStopButton.Enabled = false;
                    listView1.Items.Clear();
                    PaDetectClass.StartScan(prevObject, prevScanType, prevPadRemoveReq);
                    return;
                }
                if (MessageBox.Show(this, "Do you want to cancel scan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                if (!PaDetectClass.CancelRequestPending && PaDetectClass.IsOngoing) {
                    invokedCancel = true;
                    PaDetectClass.CancelScan();
                }
            }
        }

        private void reScanToolStripMenuItem_Click(object sender, EventArgs e) {
            if (prevScanType == PaDetectClass.ScanTypeE.Unspecified || PaDetectClass.IsOngoing) return;
            lock (locker) {
                if (MessageBox.Show(this, "Do you want to rescan the previous object?" + Environment.NewLine + Environment.NewLine +
                    "Object Path: " + (prevScanType == PaDetectClass.ScanTypeE.All ? "All objects" : prevObject), "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                ScanStopButton.Enabled = false;
                listView1.Items.Clear();
                PaDetectClass.StartScan(prevObject, prevScanType, prevPadRemoveReq);
            }
        }

        private void FixButton_Click(object sender, EventArgs e) {
            if (prevScanType == PaDetectClass.ScanTypeE.Unspecified || PaDetectClass.IsOngoing) return;
            lock (locker) {
                if (MessageBox.Show(this, "Do you want to rescan and fix the previous object?" + Environment.NewLine + Environment.NewLine +
                    "Object Path: " + (prevScanType == PaDetectClass.ScanTypeE.All ? "All objects" : prevObject), "",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                ScanStopButton.Enabled = false;
                listView1.Items.Clear();
                prevPadRemoveReq = true;
                PaDetectClass.StartScan(prevObject, prevScanType, prevPadRemoveReq);
            }
        }

        private void SettingsButton_Click(object sender, EventArgs e) {
            new SettingsDialog().ShowDialog(this);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (PaDetectClass.IsOngoing) {
                if (MessageBox.Show(this, "Do you want to cancel scan?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
                PaDetectClass.StatusTextOccurred -= PaDetectClass_StatusTextOccurred;
                PaDetectClass.ScanFinished -= PaDetectClass_ScanFinished;
                PaDetectClass.OngoingProcessChanged -= PaDetectClass_OngoingProcessChanged;
                PaDetectClass.FilePaddingDetected -= PaDetectClass_FilePaddingDetected;
                invokedCancel = true;
                PaDetectClass.CancelScan();
            }
            SettingsClass.Unload();
        }
    }
}