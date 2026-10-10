namespace WinFormsApp1
{
    partial class EditCustomerForm
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
            txtEmail = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label3 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            txtCustomerID = new TextBox();
            label5 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 15F);
            txtEmail.Location = new Point(281, 270);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(521, 41);
            txtEmail.TabIndex = 58;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(188, 273);
            label4.Name = "label4";
            label4.Size = new Size(87, 35);
            label4.TabIndex = 57;
            label4.Text = "Email :";
            // 
            // txtPhone
            // 
            txtPhone.Font = new Font("Segoe UI", 15F);
            txtPhone.Location = new Point(281, 202);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(521, 41);
            txtPhone.TabIndex = 56;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(178, 205);
            label3.Name = "label3";
            label3.Size = new Size(97, 35);
            label3.TabIndex = 55;
            label3.Text = "Phone :";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 15F);
            txtName.Location = new Point(281, 134);
            txtName.Name = "txtName";
            txtName.Size = new Size(521, 41);
            txtName.TabIndex = 54;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(181, 137);
            label2.Name = "label2";
            label2.Size = new Size(94, 35);
            label2.TabIndex = 53;
            label2.Text = "Name :";
            // 
            // txtCustomerID
            // 
            txtCustomerID.Font = new Font("Segoe UI", 15F);
            txtCustomerID.Location = new Point(281, 63);
            txtCustomerID.Name = "txtCustomerID";
            txtCustomerID.Size = new Size(521, 41);
            txtCustomerID.TabIndex = 52;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F);
            label5.Location = new Point(109, 66);
            label5.Name = "label5";
            label5.Size = new Size(166, 35);
            label5.TabIndex = 51;
            label5.Text = "Customer ID :";
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 25F);
            btnSave.Location = new Point(178, 418);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 138);
            btnSave.TabIndex = 59;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 25F);
            btnCancel.Location = new Point(592, 418);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(210, 138);
            btnCancel.TabIndex = 60;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // EditCustomerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtPhone);
            Controls.Add(label3);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(txtCustomerID);
            Controls.Add(label5);
            Name = "EditCustomerForm";
            Text = "EditCustomerForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPhone;
        private Label label3;
        private TextBox txtName;
        private Label label2;
        private TextBox txtCustomerID;
        private Label label5;
        private Button btnSave;
        private Button btnCancel;
    }
}