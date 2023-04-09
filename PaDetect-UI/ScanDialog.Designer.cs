namespace PaDetect_UI {
    partial class ScanDialog {
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
            this.FooterPanel = new System.Windows.Forms.Panel();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.FileScanRDButton = new System.Windows.Forms.RadioButton();
            this.FolderScanRDButton = new System.Windows.Forms.RadioButton();
            this.DriveScanRDButton = new System.Windows.Forms.RadioButton();
            this.FullScanRDButton = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.RemoveConfirmationCBox = new System.Windows.Forms.CheckBox();
            this.ScanObjectPanel = new System.Windows.Forms.Panel();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ShowDriveNotFixedLabel = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.FooterPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ScanObjectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // FooterPanel
            // 
            this.FooterPanel.Controls.Add(this.CancelBtn);
            this.FooterPanel.Controls.Add(this.OkButton);
            this.FooterPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FooterPanel.Location = new System.Drawing.Point(0, 358);
            this.FooterPanel.Name = "FooterPanel";
            this.FooterPanel.Size = new System.Drawing.Size(654, 64);
            this.FooterPanel.TabIndex = 9;
            // 
            // CancelBtn
            // 
            this.CancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CancelBtn.FlatAppearance.BorderSize = 0;
            this.CancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelBtn.Location = new System.Drawing.Point(532, 15);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(110, 37);
            this.CancelBtn.TabIndex = 9;
            this.CancelBtn.Text = "Cancel";
            this.CancelBtn.UseVisualStyleBackColor = false;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkButton.Location = new System.Drawing.Point(416, 15);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(110, 37);
            this.OkButton.TabIndex = 10;
            this.OkButton.Text = "Scan";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FileScanRDButton);
            this.groupBox1.Controls.Add(this.FolderScanRDButton);
            this.groupBox1.Controls.Add(this.DriveScanRDButton);
            this.groupBox1.Controls.Add(this.FullScanRDButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(201, 358);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scan Type";
            // 
            // FileScanRDButton
            // 
            this.FileScanRDButton.AutoSize = true;
            this.FileScanRDButton.Checked = true;
            this.FileScanRDButton.Location = new System.Drawing.Point(26, 38);
            this.FileScanRDButton.Name = "FileScanRDButton";
            this.FileScanRDButton.Size = new System.Drawing.Size(86, 24);
            this.FileScanRDButton.TabIndex = 2;
            this.FileScanRDButton.TabStop = true;
            this.FileScanRDButton.Text = "File scan";
            this.FileScanRDButton.UseVisualStyleBackColor = true;
            this.FileScanRDButton.CheckedChanged += new System.EventHandler(this.CheckChanged_Invoked);
            // 
            // FolderScanRDButton
            // 
            this.FolderScanRDButton.AutoSize = true;
            this.FolderScanRDButton.Location = new System.Drawing.Point(26, 68);
            this.FolderScanRDButton.Name = "FolderScanRDButton";
            this.FolderScanRDButton.Size = new System.Drawing.Size(105, 24);
            this.FolderScanRDButton.TabIndex = 1;
            this.FolderScanRDButton.Text = "Folder scan";
            this.FolderScanRDButton.UseVisualStyleBackColor = true;
            this.FolderScanRDButton.CheckedChanged += new System.EventHandler(this.CheckChanged_Invoked);
            // 
            // DriveScanRDButton
            // 
            this.DriveScanRDButton.AutoSize = true;
            this.DriveScanRDButton.Location = new System.Drawing.Point(26, 98);
            this.DriveScanRDButton.Name = "DriveScanRDButton";
            this.DriveScanRDButton.Size = new System.Drawing.Size(98, 24);
            this.DriveScanRDButton.TabIndex = 0;
            this.DriveScanRDButton.Text = "Drive scan";
            this.DriveScanRDButton.UseVisualStyleBackColor = true;
            this.DriveScanRDButton.CheckedChanged += new System.EventHandler(this.CheckChanged_Invoked);
            // 
            // FullScanRDButton
            // 
            this.FullScanRDButton.AutoSize = true;
            this.FullScanRDButton.Location = new System.Drawing.Point(26, 128);
            this.FullScanRDButton.Name = "FullScanRDButton";
            this.FullScanRDButton.Size = new System.Drawing.Size(86, 24);
            this.FullScanRDButton.TabIndex = 0;
            this.FullScanRDButton.Text = "Full scan";
            this.FullScanRDButton.UseVisualStyleBackColor = true;
            this.FullScanRDButton.CheckedChanged += new System.EventHandler(this.CheckChanged_Invoked);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.panel1.Controls.Add(this.ShowDriveNotFixedLabel);
            this.panel1.Controls.Add(this.ScanObjectPanel);
            this.panel1.Controls.Add(this.RemoveConfirmationCBox);
            this.panel1.Controls.Add(this.DescriptionLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(201, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 358);
            this.panel1.TabIndex = 11;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionLabel.AutoEllipsis = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(16, 24);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(425, 68);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Scan a specific file for checking a possible binary padding.";
            // 
            // RemoveConfirmationCBox
            // 
            this.RemoveConfirmationCBox.AutoSize = true;
            this.RemoveConfirmationCBox.Location = new System.Drawing.Point(22, 186);
            this.RemoveConfirmationCBox.Name = "RemoveConfirmationCBox";
            this.RemoveConfirmationCBox.Size = new System.Drawing.Size(262, 24);
            this.RemoveConfirmationCBox.TabIndex = 12;
            this.RemoveConfirmationCBox.Text = "Remove padded bytes once found.";
            this.RemoveConfirmationCBox.UseVisualStyleBackColor = true;
            // 
            // ScanObjectPanel
            // 
            this.ScanObjectPanel.Controls.Add(this.BrowseButton);
            this.ScanObjectPanel.Controls.Add(this.PathTextBox);
            this.ScanObjectPanel.Controls.Add(this.label1);
            this.ScanObjectPanel.Location = new System.Drawing.Point(15, 98);
            this.ScanObjectPanel.Name = "ScanObjectPanel";
            this.ScanObjectPanel.Size = new System.Drawing.Size(426, 72);
            this.ScanObjectPanel.TabIndex = 13;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BrowseButton.FlatAppearance.BorderSize = 0;
            this.BrowseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BrowseButton.Location = new System.Drawing.Point(359, 32);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(54, 27);
            this.BrowseButton.TabIndex = 14;
            this.BrowseButton.Text = "...";
            this.BrowseButton.UseVisualStyleBackColor = false;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.PathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PathTextBox.ForeColor = System.Drawing.Color.White;
            this.PathTextBox.Location = new System.Drawing.Point(7, 32);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(346, 27);
            this.PathTextBox.TabIndex = 13;
            this.PathTextBox.TextChanged += new System.EventHandler(this.PathTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Object Path:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.ShowHiddenFiles = true;
            this.openFileDialog1.Title = "Open to Check Object";
            // 
            // ShowDriveNotFixedLabel
            // 
            this.ShowDriveNotFixedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ShowDriveNotFixedLabel.AutoEllipsis = true;
            this.ShowDriveNotFixedLabel.ForeColor = System.Drawing.Color.Yellow;
            this.ShowDriveNotFixedLabel.Location = new System.Drawing.Point(15, 219);
            this.ShowDriveNotFixedLabel.Name = "ShowDriveNotFixedLabel";
            this.ShowDriveNotFixedLabel.Size = new System.Drawing.Size(426, 47);
            this.ShowDriveNotFixedLabel.TabIndex = 14;
            this.ShowDriveNotFixedLabel.Text = "Warning: The specified object was inside the drive that is not a fixed type.";
            this.ShowDriveNotFixedLabel.Visible = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.AddToRecent = false;
            this.folderBrowserDialog1.Description = "Select a Folder";
            this.folderBrowserDialog1.ShowHiddenFiles = true;
            this.folderBrowserDialog1.ShowNewFolderButton = false;
            this.folderBrowserDialog1.UseDescriptionForTitle = true;
            // 
            // ScanDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(654, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.FooterPanel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Start Scan";
            this.FooterPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ScanObjectPanel.ResumeLayout(false);
            this.ScanObjectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel FooterPanel;
        private Button CancelBtn;
        private Button OkButton;
        private GroupBox groupBox1;
        private Panel panel1;
        private RadioButton FileScanRDButton;
        private RadioButton FolderScanRDButton;
        private RadioButton FullScanRDButton;
        private RadioButton DriveScanRDButton;
        private Label DescriptionLabel;
        private CheckBox RemoveConfirmationCBox;
        private Panel ScanObjectPanel;
        private Button BrowseButton;
        private TextBox PathTextBox;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private Label ShowDriveNotFixedLabel;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}