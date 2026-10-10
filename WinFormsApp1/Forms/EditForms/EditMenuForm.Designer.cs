namespace WinFormsApp1
{
    partial class EditMenuForm
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
            cboCategory = new ComboBox();
            txtPrice = new TextBox();
            label4 = new Label();
            label3 = new Label();
            txtItemName = new TextBox();
            label2 = new Label();
            txtItemID = new TextBox();
            label1 = new Label();
            btnCancel = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // cboCategory
            // 
            cboCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategory.FormattingEnabled = true;
            cboCategory.Items.AddRange(new object[] { "Appetizer", "Main Course", "Dessert", "Beverage" });
            cboCategory.Location = new Point(264, 201);
            cboCategory.Name = "cboCategory";
            cboCategory.Size = new Size(521, 28);
            cboCategory.TabIndex = 61;
            // 
            // txtPrice
            // 
            txtPrice.Font = new Font("Segoe UI", 15F);
            txtPrice.Location = new Point(264, 257);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(521, 41);
            txtPrice.TabIndex = 60;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(177, 260);
            label4.Name = "label4";
            label4.Size = new Size(81, 35);
            label4.TabIndex = 59;
            label4.Text = "Price :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(131, 192);
            label3.Name = "label3";
            label3.Size = new Size(127, 35);
            label3.TabIndex = 58;
            label3.Text = "Category :";
            // 
            // txtItemName
            // 
            txtItemName.Font = new Font("Segoe UI", 15F);
            txtItemName.Location = new Point(264, 121);
            txtItemName.Name = "txtItemName";
            txtItemName.Size = new Size(521, 41);
            txtItemName.TabIndex = 57;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 15F);
            label2.Location = new Point(107, 124);
            label2.Name = "label2";
            label2.Size = new Size(151, 35);
            label2.TabIndex = 56;
            label2.Text = "Item Name :";
            // 
            // txtItemID
            // 
            txtItemID.Font = new Font("Segoe UI", 15F);
            txtItemID.Location = new Point(264, 50);
            txtItemID.Name = "txtItemID";
            txtItemID.Size = new Size(521, 41);
            txtItemID.TabIndex = 55;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(149, 53);
            label1.Name = "label1";
            label1.Size = new Size(109, 35);
            label1.TabIndex = 54;
            label1.Text = "Item ID :";
            // 
            // btnCancel
            // 
            btnCancel.Font = new Font("Segoe UI", 25F);
            btnCancel.Location = new Point(575, 398);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(210, 138);
            btnCancel.TabIndex = 63;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("Segoe UI", 25F);
            btnSave.Location = new Point(161, 398);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(210, 138);
            btnSave.TabIndex = 62;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // EditMenuForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cboCategory);
            Controls.Add(txtPrice);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtItemName);
            Controls.Add(label2);
            Controls.Add(txtItemID);
            Controls.Add(label1);
            Name = "EditMenuForm";
            Text = "EditMenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategory;
        private TextBox txtPrice;
        private Label label4;
        private Label label3;
        private TextBox txtItemName;
        private Label label2;
        private TextBox txtItemID;
        private Label label1;
        private Button btnCancel;
        private Button btnSave;
    }
}