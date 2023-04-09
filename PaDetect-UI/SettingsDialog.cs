using System.Diagnostics;

namespace PaDetect_UI {
    public partial class SettingsDialog : Form {
        private readonly object locker = new object();
        private bool isInit = false;
        public SettingsDialog() {
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

        private void SettingsDialog_Load(object sender, EventArgs e) {
            sizeToleranceNumUD.Maximum = (int)(PaDetectLib.PaDetectClass.vtMBAcceptable / 1024 / 1024);
            sizeToleranceNumUD.Minimum = (int)(26214200L / 1024 / 1024);
            string sizeTol = SettingsClass.GetValue("SizeTolerance");
            sizeToleranceNumUD.Value = string.IsNullOrEmpty(sizeTol) || !long.TryParse(sizeTol, out long size) ||
                size < 26214400 || size > PaDetectLib.PaDetectClass.vtMBAcceptable ? 100 : (int)(size / 1024 / 1024);
            string padTolerance = SettingsClass.GetValue("PadLenTolerance");
            PadToleranceTrackBar.Value = string.IsNullOrEmpty(padTolerance) || !int.TryParse(padTolerance, out int padTol) ||
                padTol < PadToleranceTrackBar.Minimum || padTol > PadToleranceTrackBar.Maximum ? 15 : padTol;
            panel1.Enabled = !PaDetectLib.PaDetectClass.IsOngoing;
            SettingsWarnPanel.Visible = PaDetectLib.PaDetectClass.IsOngoing;
            label3.Text = "Tolerance of padding bytes size (" + PadToleranceTrackBar.Value.ToString() + "%)";
            isInit = true;
        }

        private void sizeToleranceNumUD_ValueChanged(object sender, EventArgs e) {
            lock (locker) {
                if (!isInit) return;
                SettingsClass.SetValue("SizeTolerance", (sizeToleranceNumUD.Value * 1024 * 1024).ToString());
            }
        }

        private void PadToleranceTrackBar_ValueChanged(object sender, EventArgs e) {
            lock (locker) {
                if (!isInit) return;
                label3.Text = "Tolerance of padding bytes size (" + PadToleranceTrackBar.Value.ToString() + "%)";
                SettingsClass.SetValue("PadLenTolerance", PadToleranceTrackBar.Value.ToString());
            }
        }

        private void RunLink(string link) {
            try {
                ProcessStartInfo psi = new ProcessStartInfo() {
                    FileName = new UriBuilder(link).ToString(),
                    UseShellExecute = true
                };
                Process.Start(psi);
            } catch (Exception ex) {
                MessageBox.Show(this, "Couldn't open a link." + Environment.NewLine + "Cause: " + ex.Message,
                    "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void GitHubRepoLabel_Click(object sender, EventArgs e) {
            RunLink(@"https://github.com/PheeLeep/PaDetect");
        }

        private void LicenseLabel_Click(object sender, EventArgs e) {
            RunLink(@"https://github.com/PheeLeep/PaDetect/blob/master/LICENSE.txt");
        }

        private void Icons8Label_Click(object sender, EventArgs e) {
            RunLink(@"https://icons8.com");
        }
    }
}
