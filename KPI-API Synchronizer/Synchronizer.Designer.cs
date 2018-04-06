namespace KPI_API_Synchronizer
{
    partial class Synchronizer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxBulan = new System.Windows.Forms.ComboBox();
            this.textBoxTahun = new System.Windows.Forms.TextBox();
            this.buttonProcess = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.backgroundWorkerProcess = new System.ComponentModel.BackgroundWorker();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxKPI = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bulan";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tahun";
            // 
            // comboBoxBulan
            // 
            this.comboBoxBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBulan.FormattingEnabled = true;
            this.comboBoxBulan.Items.AddRange(new object[] {
            "Januari",
            "Februari",
            "Maret",
            "April",
            "Mei",
            "Juni",
            "Juli",
            "Agustus",
            "September",
            "Oktober",
            "November",
            "Desember"});
            this.comboBoxBulan.Location = new System.Drawing.Point(77, 19);
            this.comboBoxBulan.Name = "comboBoxBulan";
            this.comboBoxBulan.Size = new System.Drawing.Size(362, 21);
            this.comboBoxBulan.TabIndex = 2;
            // 
            // textBoxTahun
            // 
            this.textBoxTahun.Location = new System.Drawing.Point(77, 47);
            this.textBoxTahun.Name = "textBoxTahun";
            this.textBoxTahun.Size = new System.Drawing.Size(362, 20);
            this.textBoxTahun.TabIndex = 3;
            // 
            // buttonProcess
            // 
            this.buttonProcess.Location = new System.Drawing.Point(445, 19);
            this.buttonProcess.Name = "buttonProcess";
            this.buttonProcess.Size = new System.Drawing.Size(94, 48);
            this.buttonProcess.TabIndex = 4;
            this.buttonProcess.Text = "&Process";
            this.buttonProcess.UseVisualStyleBackColor = true;
            this.buttonProcess.Click += new System.EventHandler(this.buttonProcess_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(12, 115);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(523, 225);
            this.listBoxLog.TabIndex = 5;
            // 
            // backgroundWorkerProcess
            // 
            this.backgroundWorkerProcess.WorkerReportsProgress = true;
            this.backgroundWorkerProcess.WorkerSupportsCancellation = true;
            this.backgroundWorkerProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProcess_DoWork);
            this.backgroundWorkerProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProcess_ProgressChanged);
            this.backgroundWorkerProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProcess_RunWorkerCompleted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Periode";
            // 
            // comboBoxKPI
            // 
            this.comboBoxKPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxKPI.FormattingEnabled = true;
            this.comboBoxKPI.Location = new System.Drawing.Point(77, 74);
            this.comboBoxKPI.Name = "comboBoxKPI";
            this.comboBoxKPI.Size = new System.Drawing.Size(362, 21);
            this.comboBoxKPI.TabIndex = 7;
            // 
            // Synchronizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 352);
            this.Controls.Add(this.comboBoxKPI);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.buttonProcess);
            this.Controls.Add(this.textBoxTahun);
            this.Controls.Add(this.comboBoxBulan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Synchronizer";
            this.Text = "KPI Synchronizer";
            this.Load += new System.EventHandler(this.Synchronizer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxBulan;
        private System.Windows.Forms.TextBox textBoxTahun;
        private System.Windows.Forms.Button buttonProcess;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.ComponentModel.BackgroundWorker backgroundWorkerProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxKPI;
    }
}

