namespace WinFormsApp1
{
    partial class MainForm
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
            lblTitle = new Label();
            btnCustomer = new Button();
            btnEmployee = new Button();
            btnTable = new Button();
            btnOrder = new Button();
            btnMenu = new Button();
            btnReports = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 25F, FontStyle.Bold);
            lblTitle.Location = new Point(201, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(664, 57);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Restaurant Management System";
            // 
            // btnCustomer
            // 
            btnCustomer.Font = new Font("Segoe UI", 20F);
            btnCustomer.Location = new Point(51, 109);
            btnCustomer.Name = "btnCustomer";
            btnCustomer.Size = new Size(452, 112);
            btnCustomer.TabIndex = 1;
            btnCustomer.Text = "Customer Management 👤";
            btnCustomer.UseVisualStyleBackColor = true;
            btnCustomer.Click += btnCustomer_Click;
            // 
            // btnEmployee
            // 
            btnEmployee.Font = new Font("Segoe UI", 20F);
            btnEmployee.Location = new Point(556, 109);
            btnEmployee.Name = "btnEmployee";
            btnEmployee.Size = new Size(452, 112);
            btnEmployee.TabIndex = 2;
            btnEmployee.Text = "Employee Management 👨‍💼";
            btnEmployee.UseVisualStyleBackColor = true;
            btnEmployee.Click += btnEmployee_Click;
            // 
            // btnTable
            // 
            btnTable.Font = new Font("Segoe UI", 20F);
            btnTable.Location = new Point(51, 247);
            btnTable.Name = "btnTable";
            btnTable.Size = new Size(452, 112);
            btnTable.TabIndex = 3;
            btnTable.Text = "Table Management \U0001fa91";
            btnTable.UseVisualStyleBackColor = true;
            btnTable.Click += btnTable_Click;
            // 
            // btnOrder
            // 
            btnOrder.Font = new Font("Segoe UI", 20F);
            btnOrder.Location = new Point(51, 385);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(452, 112);
            btnOrder.TabIndex = 4;
            btnOrder.Text = "Order Management \U0001f6d2";
            btnOrder.UseVisualStyleBackColor = true;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnMenu
            // 
            btnMenu.Font = new Font("Segoe UI", 20F);
            btnMenu.Location = new Point(556, 247);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(452, 112);
            btnMenu.TabIndex = 5;
            btnMenu.Text = "Menu Management 🍔";
            btnMenu.UseVisualStyleBackColor = true;
            btnMenu.Click += btnMenu_Click;
            // 
            // btnReports
            // 
            btnReports.Font = new Font("Segoe UI", 20F);
            btnReports.Location = new Point(556, 385);
            btnReports.Name = "btnReports";
            btnReports.Size = new Size(452, 112);
            btnReports.TabIndex = 6;
            btnReports.Text = "Reports 📊";
            btnReports.UseVisualStyleBackColor = true;
            btnReports.Click += btnReports_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1082, 653);
            Controls.Add(btnReports);
            Controls.Add(btnMenu);
            Controls.Add(btnOrder);
            Controls.Add(btnTable);
            Controls.Add(btnEmployee);
            Controls.Add(btnCustomer);
            Controls.Add(lblTitle);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Restaurant Management System";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnCustomer;
        private Button btnEmployee;
        private Button btnTable;
        private Button btnOrder;
        private Button btnMenu;
        private Button btnReports;
    }
}
