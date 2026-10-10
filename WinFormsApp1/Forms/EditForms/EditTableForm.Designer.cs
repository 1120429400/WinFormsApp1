namespace WinFormsApp1
{
    partial class EditTableForm
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
            cboStatus = new ComboBox();
            label4 = new Label();
            txtCapacity = new TextBox();
            label3 = new Label();
            txtTableNumber = new TextBox();
            label2 = new Label();
            txtTableID = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Available", "Occupied" });
            cboStatus.Location = new Point(276, 282);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(217, 28);
            cboStatus.TabIndex = 73;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(177, 275);
            label4.Name = "label4";
            label4.Size = new Size(93, 35);
            label4.TabIndex = 72;
            label4.Text = "Status :";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Segoe UI", 15F);
            txtCapacity.Location = new Point(276, 204);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(521, 41);
            txtCapacity.TabIndex = 71;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(142, 207);
            label3.Name = "label3";
            label3.Size = new Size(128, 35);
            label3.TabIndex = 70;
            label3.Text = "Capacity : ";
            // 
            // txtTableNumber
            // 
            txtTableNumber.Font = new Font("Segoe UI", 15F);
            txtTableNumber.Location = new Point(276, 136);
            txtTableNumber.Name = "txtTableNumber";
            txtTableNumber.Size = new Size(521, 41);
            txtTableNumber.TabIndex = 69;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(87, 139);
            label2.Name = "label2";
            label2.Size = new Size(183, 35);
            label2.TabIndex = 68;
            label2.Text = "Table Number :";
            // 
            // txtTableID
            // 
            txtTableID.Font = new Font("Segoe UI", 15F);
            txtTableID.Location = new Point(276, 65);
            txtTableID.Name = "txtTableID";
            txtTableID.Size = new Size(521, 41);
            txtTableID.TabIndex = 67;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(154, 68);
            label1.Name = "label1";
            label1.Size = new Size(116, 35);
            label1.TabIndex = 66;
            label1.Text = "Table ID :";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 25F);
            btnCancel.Location = new Point(587, 410);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(210, 138);
            btnCancel.TabIndex = 75;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 25F);
            btnSave.Location = new Point(173, 410);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 138);
            btnSave.TabIndex = 74;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EditTableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboStatus);
            Controls.Add(label4);
            Controls.Add(txtCapacity);
            Controls.Add(label3);
            Controls.Add(txtTableNumber);
            Controls.Add(label2);
            Controls.Add(txtTableID);
            Controls.Add(label1);
            Name = "EditTableForm";
            Text = "EditTableForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboStatus;
        private Label label4;
        private TextBox txtCapacity;
        private Label label3;
        private TextBox txtTableNumber;
        private Label label2;
        private TextBox txtTableID;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
    }
}