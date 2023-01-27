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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.rdoDefault = new System.Windows.Forms.RadioButton();
            this.rdoParallelForEach = new System.Windows.Forms.RadioButton();
            this.lblTableSize = new System.Windows.Forms.Label();
            this.txtPingRate = new System.Windows.Forms.TextBox();
            this.txtChunkSize = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rdoAsync = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(713, 415);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "GET";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(12, 40);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(695, 23);
            this.txtFile.TabIndex = 1;
            this.txtFile.Text = "C:\\Users\\ryand\\OneDrive\\Desktop\\APICaller\\APICaller\\test1.csv";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(713, 40);
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
            this.dataGridView.Location = new System.Drawing.Point(12, 69);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(776, 340);
            this.dataGridView.TabIndex = 3;
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(12, 546);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(773, 247);
            this.txtOutput.TabIndex = 4;
            // 
            // lblLog
            // 
            this.lblLog.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLog.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLog.Location = new System.Drawing.Point(12, 796);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(773, 85);
            this.lblLog.TabIndex = 6;
            // 
            // rdoDefault
            // 
            this.rdoDefault.AutoSize = true;
            this.rdoDefault.Location = new System.Drawing.Point(16, 7);
            this.rdoDefault.Name = "rdoDefault";
            this.rdoDefault.Size = new System.Drawing.Size(63, 19);
            this.rdoDefault.TabIndex = 7;
            this.rdoDefault.Text = "Default";
            this.rdoDefault.UseVisualStyleBackColor = true;
            // 
            // rdoParallelForEach
            // 
            this.rdoParallelForEach.AutoSize = true;
            this.rdoParallelForEach.Checked = true;
            this.rdoParallelForEach.Location = new System.Drawing.Point(16, 32);
            this.rdoParallelForEach.Name = "rdoParallelForEach";
            this.rdoParallelForEach.Size = new System.Drawing.Size(116, 19);
            this.rdoParallelForEach.TabIndex = 8;
            this.rdoParallelForEach.Text = "Parallel.ForEach()";
            this.rdoParallelForEach.UseVisualStyleBackColor = true;
            // 
            // lblTableSize
            // 
            this.lblTableSize.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTableSize.Location = new System.Drawing.Point(647, 415);
            this.lblTableSize.Name = "lblTableSize";
            this.lblTableSize.Size = new System.Drawing.Size(60, 23);
            this.lblTableSize.TabIndex = 10;
            this.lblTableSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPingRate
            // 
            this.txtPingRate.Location = new System.Drawing.Point(236, 31);
            this.txtPingRate.Name = "txtPingRate";
            this.txtPingRate.Size = new System.Drawing.Size(100, 23);
            this.txtPingRate.TabIndex = 11;
            this.txtPingRate.Text = "200";
            // 
            // txtChunkSize
            // 
            this.txtChunkSize.Location = new System.Drawing.Point(359, 32);
            this.txtChunkSize.Name = "txtChunkSize";
            this.txtChunkSize.Size = new System.Drawing.Size(100, 23);
            this.txtChunkSize.TabIndex = 12;
            this.txtChunkSize.Text = "500";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdoAsync);
            this.panel1.Controls.Add(this.txtThreadCount);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rdoDefault);
            this.panel1.Controls.Add(this.txtChunkSize);
            this.panel1.Controls.Add(this.rdoParallelForEach);
            this.panel1.Controls.Add(this.txtPingRate);
            this.panel1.Location = new System.Drawing.Point(12, 440);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 100);
            this.panel1.TabIndex = 13;
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(484, 31);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(100, 23);
            this.txtThreadCount.TabIndex = 17;
            this.txtThreadCount.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(484, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Thread Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(359, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chunk Size";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(236, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Ping Rate";
            // 
            // rdoAsync
            // 
            this.rdoAsync.AutoSize = true;
            this.rdoAsync.Location = new System.Drawing.Point(16, 57);
            this.rdoAsync.Name = "rdoAsync";
            this.rdoAsync.Size = new System.Drawing.Size(57, 19);
            this.rdoAsync.TabIndex = 18;
            this.rdoAsync.Text = "Async";
            this.rdoAsync.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 890);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblTableSize);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnGenerate);
            this.Name = "frmMain";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnGenerate;
        private OpenFileDialog openFileDialog;
        private TextBox txtFile;
        private Button btnOpen;
        private DataGridView dataGridView;
        private TextBox txtOutput;
        private Label lblLog;
        private RadioButton rdoDefault;
        private RadioButton rdoParallelForEach;
        private Label lblTableSize;
        private TextBox txtPingRate;
        private TextBox txtChunkSize;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private TextBox txtThreadCount;
        private Label label3;
        private RadioButton rdoAsync;
    }
}