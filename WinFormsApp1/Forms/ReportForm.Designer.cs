namespace WinFormsApp1
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.GroupBox grpReportResult;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnExport;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblReportType = new Label();
            cmbReportType = new ComboBox();
            lblFromDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblToDate = new Label();
            dtpToDate = new DateTimePicker();
            btnGenerate = new Button();
            grpReportResult = new GroupBox();
            dgvReport = new DataGridView();
            btnExport = new Button();
            grpReportResult.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // lblReportType
            // 
            lblReportType.AutoSize = true;
            lblReportType.Location = new Point(40, 35);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(92, 20);
            lblReportType.TabIndex = 0;
            lblReportType.Text = "Report Type:";
            // 
            // cmbReportType
            // 
            cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportType.Items.AddRange(new object[] { "Daily Orders", "Sales Summary", "Customer Orders", "Menu Item Sales" });
            cmbReportType.Location = new Point(140, 32);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(220, 28);
            cmbReportType.TabIndex = 1;
            // 
            // lblFromDate
            // 
            lblFromDate.AutoSize = true;
            lblFromDate.Location = new Point(40, 80);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(46, 20);
            lblFromDate.TabIndex = 2;
            lblFromDate.Text = "From:";
            // 
            // dtpFromDate
            // 
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(90, 77);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(160, 27);
            dtpFromDate.TabIndex = 3;
            // 
            // lblToDate
            // 
            lblToDate.AutoSize = true;
            lblToDate.Location = new Point(300, 80);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(28, 20);
            lblToDate.TabIndex = 4;
            lblToDate.Text = "To:";
            // 
            // dtpToDate
            // 
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(335, 77);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(160, 27);
            dtpToDate.TabIndex = 5;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(500, 72);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(160, 32);
            btnGenerate.TabIndex = 6;
            btnGenerate.Text = "GENERATE REPORT";
            btnGenerate.Click += btnGenerate_Click_1;
            // 
            // grpReportResult
            // 
            grpReportResult.Controls.Add(dgvReport);
            grpReportResult.Location = new Point(25, 125);
            grpReportResult.Name = "grpReportResult";
            grpReportResult.Size = new Size(780, 370);
            grpReportResult.TabIndex = 7;
            grpReportResult.TabStop = false;
            grpReportResult.Text = "Report Result";
            // 
            // dgvReport
            // 
            dgvReport.AllowUserToAddRows = false;
            dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReport.ColumnHeadersHeight = 29;
            dgvReport.Location = new Point(20, 30);
            dgvReport.Name = "dgvReport";
            dgvReport.ReadOnly = true;
            dgvReport.RowHeadersWidth = 51;
            dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReport.Size = new Size(740, 300);
            dgvReport.TabIndex = 0;
            // 
            // btnExport
            // 
            btnExport.Location = new Point(650, 515);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(110, 32);
            btnExport.TabIndex = 8;
            btnExport.Text = "EXPORT";
            btnExport.Click += btnExport_Click_1;
            // 
            // ReportForm
            // 
            ClientSize = new Size(850, 600);
            Controls.Add(lblReportType);
            Controls.Add(cmbReportType);
            Controls.Add(lblFromDate);
            Controls.Add(dtpFromDate);
            Controls.Add(lblToDate);
            Controls.Add(dtpToDate);
            Controls.Add(btnGenerate);
            Controls.Add(grpReportResult);
            Controls.Add(btnExport);
            Name = "ReportForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reports";
            grpReportResult.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
