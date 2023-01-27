namespace APICaller
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.lblTableSize = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTaskDelay = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.txtBaseURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPingRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkPreviewCSV = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(6, 19);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(631, 23);
            this.txtFile.TabIndex = 1;
            this.txtFile.Text = "C:\\Users\\ryand\\OneDrive\\Desktop\\APICaller\\APICaller\\test1.csv";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(643, 19);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Open...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(6, 89);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(712, 237);
            this.dataGridView.TabIndex = 3;
            // 
            // lblTableSize
            // 
            this.lblTableSize.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTableSize.Location = new System.Drawing.Point(643, 60);
            this.lblTableSize.Name = "lblTableSize";
            this.lblTableSize.Size = new System.Drawing.Size(75, 23);
            this.lblTableSize.TabIndex = 10;
            this.lblTableSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabMain);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Location = new System.Drawing.Point(12, 5);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(741, 498);
            this.tabControl.TabIndex = 15;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.label6);
            this.tabMain.Controls.Add(this.txtTaskDelay);
            this.tabMain.Controls.Add(this.label5);
            this.tabMain.Controls.Add(this.txtThreadCount);
            this.tabMain.Controls.Add(this.txtBaseURL);
            this.tabMain.Controls.Add(this.label3);
            this.tabMain.Controls.Add(this.btnGenerate);
            this.tabMain.Controls.Add(this.label1);
            this.tabMain.Controls.Add(this.txtPingRate);
            this.tabMain.Controls.Add(this.label4);
            this.tabMain.Controls.Add(this.chkPreviewCSV);
            this.tabMain.Controls.Add(this.label2);
            this.tabMain.Controls.Add(this.txtFile);
            this.tabMain.Controls.Add(this.dataGridView);
            this.tabMain.Controls.Add(this.lblTableSize);
            this.tabMain.Controls.Add(this.btnOpen);
            this.tabMain.Location = new System.Drawing.Point(4, 24);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(733, 470);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(260, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Task Delay";
            // 
            // txtTaskDelay
            // 
            this.txtTaskDelay.Location = new System.Drawing.Point(260, 397);
            this.txtTaskDelay.Name = "txtTaskDelay";
            this.txtTaskDelay.Size = new System.Drawing.Size(100, 23);
            this.txtTaskDelay.TabIndex = 26;
            this.txtTaskDelay.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(133, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Thread Count";
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(133, 397);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(100, 23);
            this.txtThreadCount.TabIndex = 24;
            this.txtThreadCount.Text = "100";
            // 
            // txtBaseURL
            // 
            this.txtBaseURL.Location = new System.Drawing.Point(6, 355);
            this.txtBaseURL.Name = "txtBaseURL";
            this.txtBaseURL.Size = new System.Drawing.Size(631, 23);
            this.txtBaseURL.TabIndex = 23;
            this.txtBaseURL.Text = "https://api.artic.edu/api/v1/artworks/";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(9, 339);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 22;
            this.label3.Text = "Base URL";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(643, 355);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 19;
            this.btnGenerate.Text = "GET";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Ping Rate";
            // 
            // txtPingRate
            // 
            this.txtPingRate.Location = new System.Drawing.Point(9, 397);
            this.txtPingRate.Name = "txtPingRate";
            this.txtPingRate.Size = new System.Drawing.Size(100, 23);
            this.txtPingRate.TabIndex = 20;
            this.txtPingRate.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(6, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Options";
            // 
            // chkPreviewCSV
            // 
            this.chkPreviewCSV.AutoSize = true;
            this.chkPreviewCSV.Checked = true;
            this.chkPreviewCSV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreviewCSV.Location = new System.Drawing.Point(6, 64);
            this.chkPreviewCSV.Name = "chkPreviewCSV";
            this.chkPreviewCSV.Size = new System.Drawing.Size(91, 19);
            this.chkPreviewCSV.TabIndex = 17;
            this.chkPreviewCSV.Text = "Preview CSV";
            this.chkPreviewCSV.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "CSV File";
            // 
            // tabOptions
            // 
            this.tabOptions.Location = new System.Drawing.Point(4, 24);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(733, 470);
            this.tabOptions.TabIndex = 1;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 506);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(760, 22);
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 528);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabControl);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabMain.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private OpenFileDialog openFileDialog;
        private TextBox txtFile;
        private Button btnOpen;
        private DataGridView dataGridView;
        private Label lblTableSize;
        private TabControl tabControl;
        private TabPage tabMain;
        private Label label4;
        private CheckBox chkPreviewCSV;
        private Label label2;
        private TabPage tabOptions;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lblStatus;
        private TextBox txtBaseURL;
        private Label label3;
        private Button btnGenerate;
        private Label label1;
        private TextBox txtPingRate;
        private Label label5;
        private TextBox txtThreadCount;
        private Label label6;
        private TextBox txtTaskDelay;
    }
}