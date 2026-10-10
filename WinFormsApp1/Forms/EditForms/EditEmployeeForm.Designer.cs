namespace WinFormsApp1
{
    partial class EditEmployeeForm
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
            txtPhone = new TextBox();
            label4 = new Label();
            txtPosition = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtEmployeeID = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 15F);
            txtPhone.Location = new Point(282, 264);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(521, 41);
            txtPhone.TabIndex = 42;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(179, 267);
            label4.Name = "label4";
            label4.Size = new Size(97, 35);
            label4.TabIndex = 41;
            label4.Text = "Phone :";
            // 
            // txtPosition
            // 
            txtPosition.Font = new Font("Segoe UI", 15F);
            txtPosition.Location = new Point(282, 196);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(521, 41);
            txtPosition.TabIndex = 40;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(161, 199);
            label3.Name = "label3";
            label3.Size = new Size(115, 35);
            label3.TabIndex = 39;
            label3.Text = "Position :";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 15F);
            txtName.Location = new Point(282, 128);
            txtName.Name = "txtName";
            txtName.Size = new Size(521, 41);
            txtName.TabIndex = 38;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(182, 131);
            label2.Name = "label2";
            label2.Size = new Size(94, 35);
            label2.TabIndex = 37;
            label2.Text = "Name :";
            // 
            // txtEmployeeID
            // 
            txtEmployeeID.Font = new Font("Segoe UI", 15F);
            txtEmployeeID.Location = new Point(282, 57);
            txtEmployeeID.Name = "txtEmployeeID";
            txtEmployeeID.Size = new Size(521, 41);
            txtEmployeeID.TabIndex = 36;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(110, 60);
            label1.Name = "label1";
            label1.Size = new Size(168, 35);
            label1.TabIndex = 35;
            label1.Text = "Employee ID :";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 25F);
            btnCancel.Location = new Point(596, 387);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(210, 138);
            btnCancel.TabIndex = 62;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click_1;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 25F);
            btnSave.Location = new Point(182, 387);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 138);
            btnSave.TabIndex = 61;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EditEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtPhone);
            Controls.Add(label4);
            Controls.Add(txtPosition);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtEmployeeID);
            Controls.Add(label1);
            Name = "EditEmployeeForm";
            Text = "EditEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPhone;
        private Label label4;
        private TextBox txtPosition;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtEmployeeID;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
    }
}