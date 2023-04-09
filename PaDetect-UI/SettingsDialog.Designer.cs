namespace PaDetect_UI {
    partial class SettingsDialog {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PadToleranceTrackBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.sizeToleranceNumUD = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SettingsWarnPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Icons8Label = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.LicenseLabel = new System.Windows.Forms.Label();
            this.GitHubRepoLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PadToleranceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeToleranceNumUD)).BeginInit();
            this.SettingsWarnPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.SettingsWarnPanel);
            this.tabPage1.Location = new System.Drawing.Point(4, 32);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 415);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PadToleranceTrackBar);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.sizeToleranceNumUD);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 320);
            this.panel1.TabIndex = 0;
            // 
            // PadToleranceTrackBar
            // 
            this.PadToleranceTrackBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PadToleranceTrackBar.Location = new System.Drawing.Point(46, 172);
            this.PadToleranceTrackBar.Maximum = 75;
            this.PadToleranceTrackBar.Minimum = 10;
            this.PadToleranceTrackBar.Name = "PadToleranceTrackBar";
            this.PadToleranceTrackBar.Size = new System.Drawing.Size(578, 56);
            this.PadToleranceTrackBar.TabIndex = 9;
            this.PadToleranceTrackBar.Value = 75;
            this.PadToleranceTrackBar.ValueChanged += new System.EventHandler(this.PadToleranceTrackBar_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 23);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tolerance of padding bytes size: (75%)";
            // 
            // sizeToleranceNumUD
            // 
            this.sizeToleranceNumUD.Location = new System.Drawing.Point(103, 81);
            this.sizeToleranceNumUD.Name = "sizeToleranceNumUD";
            this.sizeToleranceNumUD.Size = new System.Drawing.Size(104, 30);
            this.sizeToleranceNumUD.TabIndex = 7;
            this.sizeToleranceNumUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sizeToleranceNumUD.ValueChanged += new System.EventHandler(this.sizeToleranceNumUD_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "MB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(527, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Minimum size tolerance (max size is based on VirusTotal\'s max size):";
            // 
            // SettingsWarnPanel
            // 
            this.SettingsWarnPanel.BackColor = System.Drawing.Color.Maroon;
            this.SettingsWarnPanel.Controls.Add(this.label4);
            this.SettingsWarnPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SettingsWarnPanel.Location = new System.Drawing.Point(3, 323);
            this.SettingsWarnPanel.Name = "SettingsWarnPanel";
            this.SettingsWarnPanel.Size = new System.Drawing.Size(670, 89);
            this.SettingsWarnPanel.TabIndex = 1;
            this.SettingsWarnPanel.Visible = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(410, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "This settings is disabled while the scan is in progress.";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.tabPage2.Controls.Add(this.Icons8Label);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.LicenseLabel);
            this.tabPage2.Controls.Add(this.GitHubRepoLabel);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.pictureBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 32);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 415);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "About";
            // 
            // Icons8Label
            // 
            this.Icons8Label.AutoSize = true;
            this.Icons8Label.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.Icons8Label.Location = new System.Drawing.Point(86, 313);
            this.Icons8Label.Name = "Icons8Label";
            this.Icons8Label.Size = new System.Drawing.Size(127, 23);
            this.Icons8Label.TabIndex = 7;
            this.Icons8Label.Text = "Icons by Icons8";
            this.Icons8Label.Click += new System.EventHandler(this.Icons8Label_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 290);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 23);
            this.label8.TabIndex = 6;
            this.label8.Text = "Credit/s:";
            // 
            // LicenseLabel
            // 
            this.LicenseLabel.AutoSize = true;
            this.LicenseLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.LicenseLabel.Location = new System.Drawing.Point(45, 241);
            this.LicenseLabel.Name = "LicenseLabel";
            this.LicenseLabel.Size = new System.Drawing.Size(130, 23);
            this.LicenseLabel.TabIndex = 5;
            this.LicenseLabel.Text = "Licensed as MIT";
            this.LicenseLabel.Click += new System.EventHandler(this.LicenseLabel_Click);
            // 
            // GitHubRepoLabel
            // 
            this.GitHubRepoLabel.AutoSize = true;
            this.GitHubRepoLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            this.GitHubRepoLabel.Location = new System.Drawing.Point(45, 214);
            this.GitHubRepoLabel.Name = "GitHubRepoLabel";
            this.GitHubRepoLabel.Size = new System.Drawing.Size(108, 23);
            this.GitHubRepoLabel.TabIndex = 4;
            this.GitHubRepoLabel.Text = "GitHub Repo";
            this.GitHubRepoLabel.Click += new System.EventHandler(this.GitHubRepoLabel_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(152, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Author: PheeLeep";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(156, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(501, 59);
            this.label6.TabIndex = 2;
            this.label6.Text = "PaDetect (Pad Detect) is a utility program that checks objects for possible binar" +
    "y padding.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(152, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 38);
            this.label5.TabIndex = 1;
            this.label5.Text = "PaDetect-UI";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PaDetect_UI.Properties.Resources.padetect_icon;
            this.pictureBox1.Location = new System.Drawing.Point(45, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // SettingsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(684, 451);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.SettingsDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PadToleranceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeToleranceNumUD)).EndInit();
            this.SettingsWarnPanel.ResumeLayout(false);
            this.SettingsWarnPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel1;
        private TrackBar PadToleranceTrackBar;
        private Label label3;
        private NumericUpDown sizeToleranceNumUD;
        private Label label2;
        private Label label1;
        private Panel SettingsWarnPanel;
        private Label label4;
        private PictureBox pictureBox1;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label GitHubRepoLabel;
        private Label LicenseLabel;
        private Label label8;
        private Label Icons8Label;
    }
}