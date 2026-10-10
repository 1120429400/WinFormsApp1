namespace WinFormsApp1
{
    partial class OrderForm
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
            dgvOrders = new DataGridView();
            colOrderID = new DataGridViewTextBoxColumn();
            colCustomerID = new DataGridViewTextBoxColumn();
            colEmployeeID = new DataGridViewTextBoxColumn();
            colTableID = new DataGridViewTextBoxColumn();
            colOrderDate = new DataGridViewTextBoxColumn();
            colTotalAmount = new DataGridViewTextBoxColumn();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnCreate = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { colOrderID, colCustomerID, colEmployeeID, colTableID, colOrderDate, colTotalAmount });
            dgvOrders.Location = new Point(41, 31);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.RowHeadersWidth = 51;
            dgvOrders.Size = new Size(876, 296);
            dgvOrders.TabIndex = 0;
            // 
            // colOrderID
            // 
            colOrderID.HeaderText = "Order ID";
            colOrderID.MinimumWidth = 6;
            colOrderID.Name = "colOrderID";
            colOrderID.Width = 137;
            // 
            // colCustomerID
            // 
            colCustomerID.HeaderText = "Customer ID";
            colCustomerID.MinimumWidth = 6;
            colCustomerID.Name = "colCustomerID";
            colCustomerID.Width = 137;
            // 
            // colEmployeeID
            // 
            colEmployeeID.HeaderText = "Employee ID";
            colEmployeeID.MinimumWidth = 6;
            colEmployeeID.Name = "colEmployeeID";
            colEmployeeID.Width = 138;
            // 
            // colTableID
            // 
            colTableID.HeaderText = "Table ID";
            colTableID.MinimumWidth = 6;
            colTableID.Name = "colTableID";
            colTableID.Width = 137;
            // 
            // colOrderDate
            // 
            colOrderDate.HeaderText = "Order Date";
            colOrderDate.MinimumWidth = 6;
            colOrderDate.Name = "colOrderDate";
            colOrderDate.Width = 137;
            // 
            // colTotalAmount
            // 
            colTotalAmount.HeaderText = "Total Amount";
            colTotalAmount.MinimumWidth = 6;
            colTotalAmount.Name = "colTotalAmount";
            colTotalAmount.Width = 137;
            // 
            // btnDelete
            // 
            btnDelete.Font = new Font("Segoe UI", 15F);
            btnDelete.Location = new Point(748, 469);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(169, 100);
            btnDelete.TabIndex = 40;
            btnDelete.Text = "DELETE";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click_1;
            // 
            // btnUpdate
            // 
            btnUpdate.Font = new Font("Segoe UI", 15F);
            btnUpdate.Location = new Point(395, 469);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(169, 100);
            btnUpdate.TabIndex = 39;
            btnUpdate.Text = "UPDATE";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click_1;
            // 
            // btnCreate
            // 
            btnCreate.Font = new Font("Segoe UI", 15F);
            btnCreate.Location = new Point(41, 469);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(177, 100);
            btnCreate.TabIndex = 38;
            btnCreate.Text = "CREATE";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click_1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(279, 376);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(169, 27);
            txtSearch.TabIndex = 59;
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Segoe UI", 15F);
            btnSearch.Location = new Point(41, 365);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(214, 48);
            btnSearch.TabIndex = 58;
            btnSearch.Text = "SEARCH";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click_1;
            // 
            // OrderForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnCreate);
            Controls.Add(dgvOrders);
            Name = "OrderForm";
            Text = "Order List";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnCreate;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridViewTextBoxColumn colOrderID;
        private DataGridViewTextBoxColumn colCustomerID;
        private DataGridViewTextBoxColumn colEmployeeID;
        private DataGridViewTextBoxColumn colTableID;
        private DataGridViewTextBoxColumn colOrderDate;
        private DataGridViewTextBoxColumn colTotalAmount;
    }
}