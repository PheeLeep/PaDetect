namespace PaDetect_UI {
    partial class MainForm {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.ScanStopButton = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.reScanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.FixButton = new System.Windows.Forms.Button();
            this.SummaryLabel = new System.Windows.Forms.Label();
            this.MainLabel = new System.Windows.Forms.Label();
            this.StagePanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SummaryPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.ScanProgressPanel = new System.Windows.Forms.Panel();
            this.StatusText = new System.Windows.Forms.Label();
            this.PaddedFixedLabel = new System.Windows.Forms.Label();
            this.PaddedFoundLabel = new System.Windows.Forms.Label();
            this.ObjectsScannedLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.HeaderPanel.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.StagePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SummaryPanel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.ScanProgressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.HeaderPanel.Controls.Add(this.ScanStopButton);
            this.HeaderPanel.Controls.Add(this.SettingsButton);
            this.HeaderPanel.Controls.Add(this.FixButton);
            this.HeaderPanel.Controls.Add(this.SummaryLabel);
            this.HeaderPanel.Controls.Add(this.MainLabel);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(715, 156);
            this.HeaderPanel.TabIndex = 0;
            // 
            // ScanStopButton
            // 
            this.ScanStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ScanStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ScanStopButton.ContextMenuStrip = this.contextMenuStrip1;
            this.ScanStopButton.FlatAppearance.BorderSize = 0;
            this.ScanStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScanStopButton.Location = new System.Drawing.Point(539, 103);
            this.ScanStopButton.Name = "ScanStopButton";
            this.ScanStopButton.Size = new System.Drawing.Size(110, 37);
            this.ScanStopButton.TabIndex = 5;
            this.ScanStopButton.Text = "Scan";
            this.toolTip1.SetToolTip(this.ScanStopButton, "Open Scanner prompt, and start scanning. In addition, right-click if you want to " +
        "rescan the previous object.");
            this.ScanStopButton.UseVisualStyleBackColor = false;
            this.ScanStopButton.Click += new System.EventHandler(this.ScanStopButton_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reScanToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(265, 28);
            // 
            // reScanToolStripMenuItem
            // 
            this.reScanToolStripMenuItem.Name = "reScanToolStripMenuItem";
            this.reScanToolStripMenuItem.Size = new System.Drawing.Size(264, 24);
            this.reScanToolStripMenuItem.Text = "Re-Scan the Previous Object";
            this.reScanToolStripMenuItem.Click += new System.EventHandler(this.reScanToolStripMenuItem_Click);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SettingsButton.FlatAppearance.BorderSize = 0;
            this.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SettingsButton.Image = global::PaDetect_UI.Properties.Resources.settings_gear;
            this.SettingsButton.Location = new System.Drawing.Point(655, 103);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(37, 37);
            this.SettingsButton.TabIndex = 5;
            this.toolTip1.SetToolTip(this.SettingsButton, "Open Settings");
            this.SettingsButton.UseVisualStyleBackColor = false;
            this.SettingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // FixButton
            // 
            this.FixButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FixButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FixButton.FlatAppearance.BorderSize = 0;
            this.FixButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FixButton.Location = new System.Drawing.Point(423, 103);
            this.FixButton.Name = "FixButton";
            this.FixButton.Size = new System.Drawing.Size(110, 37);
            this.FixButton.TabIndex = 6;
            this.FixButton.Text = "Fix";
            this.toolTip1.SetToolTip(this.FixButton, "Press to rescan and fix the affected object/s.");
            this.FixButton.UseVisualStyleBackColor = false;
            this.FixButton.Visible = false;
            this.FixButton.Click += new System.EventHandler(this.FixButton_Click);
            // 
            // SummaryLabel
            // 
            this.SummaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummaryLabel.AutoEllipsis = true;
            this.SummaryLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SummaryLabel.Location = new System.Drawing.Point(85, 66);
            this.SummaryLabel.Name = "SummaryLabel";
            this.SummaryLabel.Size = new System.Drawing.Size(565, 23);
            this.SummaryLabel.TabIndex = 4;
            this.SummaryLabel.Text = "Select an object to scan.";
            // 
            // MainLabel
            // 
            this.MainLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainLabel.AutoEllipsis = true;
            this.MainLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainLabel.Location = new System.Drawing.Point(84, 34);
            this.MainLabel.Name = "MainLabel";
            this.MainLabel.Size = new System.Drawing.Size(566, 28);
            this.MainLabel.TabIndex = 3;
            this.MainLabel.Text = "Analyze objects for possible binary padding.";
            // 
            // StagePanel
            // 
            this.StagePanel.Controls.Add(this.groupBox1);
            this.StagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StagePanel.Location = new System.Drawing.Point(0, 156);
            this.StagePanel.Name = "StagePanel";
            this.StagePanel.Size = new System.Drawing.Size(715, 295);
            this.StagePanel.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SummaryPanel);
            this.groupBox1.Controls.Add(this.ScanProgressPanel);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(715, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Result";
            // 
            // SummaryPanel
            // 
            this.SummaryPanel.Controls.Add(this.groupBox2);
            this.SummaryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SummaryPanel.Location = new System.Drawing.Point(3, 23);
            this.SummaryPanel.Name = "SummaryPanel";
            this.SummaryPanel.Size = new System.Drawing.Size(709, 269);
            this.SummaryPanel.TabIndex = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.listView1);
            this.groupBox2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox2.Location = new System.Drawing.Point(35, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(642, 217);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "List of Binary Padded Objects (max. 1000)";
            // 
            // listView1
            // 
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 23);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(636, 191);
            this.listView1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.listView1, resources.GetString("listView1.ToolTip"));
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Object";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Is Fixed?";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Length (in disk)";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Length (by file structure)";
            this.columnHeader4.Width = 175;
            // 
            // ScanProgressPanel
            // 
            this.ScanProgressPanel.Controls.Add(this.StatusText);
            this.ScanProgressPanel.Controls.Add(this.PaddedFixedLabel);
            this.ScanProgressPanel.Controls.Add(this.PaddedFoundLabel);
            this.ScanProgressPanel.Controls.Add(this.ObjectsScannedLabel);
            this.ScanProgressPanel.Controls.Add(this.label4);
            this.ScanProgressPanel.Controls.Add(this.pBar);
            this.ScanProgressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScanProgressPanel.Location = new System.Drawing.Point(3, 23);
            this.ScanProgressPanel.Name = "ScanProgressPanel";
            this.ScanProgressPanel.Size = new System.Drawing.Size(709, 269);
            this.ScanProgressPanel.TabIndex = 0;
            // 
            // StatusText
            // 
            this.StatusText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusText.AutoEllipsis = true;
            this.StatusText.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusText.Location = new System.Drawing.Point(35, 199);
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(642, 23);
            this.StatusText.TabIndex = 9;
            // 
            // PaddedFixedLabel
            // 
            this.PaddedFixedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaddedFixedLabel.AutoEllipsis = true;
            this.PaddedFixedLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PaddedFixedLabel.Location = new System.Drawing.Point(62, 132);
            this.PaddedFixedLabel.Name = "PaddedFixedLabel";
            this.PaddedFixedLabel.Size = new System.Drawing.Size(443, 23);
            this.PaddedFixedLabel.TabIndex = 8;
            this.PaddedFixedLabel.Text = "Padded Object/s Fixed: 0";
            // 
            // PaddedFoundLabel
            // 
            this.PaddedFoundLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PaddedFoundLabel.AutoEllipsis = true;
            this.PaddedFoundLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PaddedFoundLabel.Location = new System.Drawing.Point(62, 106);
            this.PaddedFoundLabel.Name = "PaddedFoundLabel";
            this.PaddedFoundLabel.Size = new System.Drawing.Size(443, 23);
            this.PaddedFoundLabel.TabIndex = 7;
            this.PaddedFoundLabel.Text = "Padded Object/s Found: 0";
            // 
            // ObjectsScannedLabel
            // 
            this.ObjectsScannedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectsScannedLabel.AutoEllipsis = true;
            this.ObjectsScannedLabel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ObjectsScannedLabel.Location = new System.Drawing.Point(62, 80);
            this.ObjectsScannedLabel.Name = "ObjectsScannedLabel";
            this.ObjectsScannedLabel.Size = new System.Drawing.Size(443, 23);
            this.ObjectsScannedLabel.TabIndex = 6;
            this.ObjectsScannedLabel.Text = "Objects Scanned: 0";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(35, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(642, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Scanning in progress. This may take a while.";
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(35, 174);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(642, 19);
            this.pBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pBar.TabIndex = 0;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(715, 451);
            this.Controls.Add(this.StagePanel);
            this.Controls.Add(this.HeaderPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaDetect-UI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.StagePanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.SummaryPanel.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ScanProgressPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel HeaderPanel;
        private Button SettingsButton;
        private Label SummaryLabel;
        private Label MainLabel;
        private Button ScanStopButton;
        private Panel StagePanel;
        private GroupBox groupBox1;
        private Panel ScanProgressPanel;
        private ProgressBar pBar;
        private Label ObjectsScannedLabel;
        private Label label4;
        private Label PaddedFoundLabel;
        private Label PaddedFixedLabel;
        private Label StatusText;
        private Panel SummaryPanel;
        private GroupBox groupBox2;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button FixButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem reScanToolStripMenuItem;
        private ToolTip toolTip1;
    }
}