namespace PaDetect_UI {
    public partial class SelectDriveDialog : Form {
        private readonly object locker = new object();

        public string DriveName { get; private set; }
        public SelectDriveDialog() {
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

        private void CancelButton_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SelectDriveDialog_Load(object sender, EventArgs e) {
            while (!IsHandleCreated) {
                Thread.Sleep(10);
                //Wait while the handle is good to use.
            }
            RefreshDrives();
        }

        private void RefreshButton_Click(object sender, EventArgs e) {
            RefreshDrives();
        }

        private void RefreshDrives() {
            lock (locker) {
                driveLV.Items.Clear();
                DriveInfo[] drives = DriveInfo.GetDrives();
                List<ListViewItem> items = new List<ListViewItem>();
                for (int i = 0; i < drives.Length; i++) {
                    if (!drives[i].IsReady) continue;
                    ListViewItem lvi = new ListViewItem(drives[i].Name);
                    lvi.SubItems.Add(drives[i].VolumeLabel);
                    lvi.SubItems.Add(drives[i].DriveType.ToString());
                    lvi.SubItems.Add(drives[i].DriveFormat);
                    items.Add(lvi);
                }
                driveLV.Items.AddRange(items.ToArray());
            }
        }

        private void SelectButton_Click(object sender, EventArgs e) {
            if (driveLV.SelectedItems.Count == 0) {
                MessageBox.Show(this, "Please select a drive.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DriveName = driveLV.SelectedItems[0].Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
