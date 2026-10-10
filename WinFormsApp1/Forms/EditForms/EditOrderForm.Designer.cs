namespace WinFormsApp1
{
    partial class EditOrderForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            grpOrder = new GroupBox();
            lblOrderID = new Label();
            txtOrderID = new TextBox();
            lblCustomer = new Label();
            cboCustomer = new ComboBox();
            lblEmployee = new Label();
            cboEmployee = new ComboBox();
            lblTable = new Label();
            cboTable = new ComboBox();
            lblOrderDate = new Label();
            dtpOrderDate = new DateTimePicker();
            txtTotalAmount = new TextBox();
            lblTotalAmount = new Label();
            grpDetail = new GroupBox();
            lblMenuItem = new Label();
            cboMenuItem = new ComboBox();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            btnAddItem = new Button();
            btnRemoveItem = new Button();
            dgvOrderDetails = new DataGridView();
            ItemID = new DataGridViewTextBoxColumn();
            ItemName = new DataGridViewTextBoxColumn();
            Quantity = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            grpActions = new GroupBox();
            btnAddOrder = new Button();
            btnClear = new Button();
            grpOrder.SuspendLayout();
            grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).BeginInit();
            grpActions.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(24, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(295, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Order Management";
            // 
            // grpOrder
            // 
            grpOrder.Controls.Add(lblOrderID);
            grpOrder.Controls.Add(txtOrderID);
            grpOrder.Controls.Add(lblCustomer);
            grpOrder.Controls.Add(cboCustomer);
            grpOrder.Controls.Add(lblEmployee);
            grpOrder.Controls.Add(cboEmployee);
            grpOrder.Controls.Add(lblTable);
            grpOrder.Controls.Add(cboTable);
            grpOrder.Controls.Add(lblOrderDate);
            grpOrder.Controls.Add(dtpOrderDate);
            grpOrder.Controls.Add(txtTotalAmount);
            grpOrder.Controls.Add(lblTotalAmount);
            grpOrder.Location = new Point(20, 65);
            grpOrder.Name = "grpOrder";
            grpOrder.Size = new Size(929, 170);
            grpOrder.TabIndex = 1;
            grpOrder.TabStop = false;
            grpOrder.Text = "Order";
            // 
            // lblOrderID
            // 
            lblOrderID.AutoSize = true;
            lblOrderID.Location = new Point(25, 40);
            lblOrderID.Name = "lblOrderID";
            lblOrderID.Size = new Size(69, 20);
            lblOrderID.TabIndex = 0;
            lblOrderID.Text = "Order ID:";
            // 
            // txtOrderID
            // 
            txtOrderID.Location = new Point(150, 36);
            txtOrderID.Name = "txtOrderID";
            txtOrderID.Size = new Size(265, 27);
            txtOrderID.TabIndex = 1;
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(467, 39);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(75, 20);
            lblCustomer.TabIndex = 2;
            lblCustomer.Text = "Customer:";
            // 
            // cboCustomer
            // 
            cboCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCustomer.Location = new Point(592, 35);
            cboCustomer.Name = "cboCustomer";
            cboCustomer.Size = new Size(300, 28);
            cboCustomer.TabIndex = 3;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.Location = new Point(467, 79);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(78, 20);
            lblEmployee.TabIndex = 4;
            lblEmployee.Text = "Employee:";
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.Location = new Point(592, 75);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(300, 28);
            cboEmployee.TabIndex = 5;
            // 
            // lblTable
            // 
            lblTable.AutoSize = true;
            lblTable.Location = new Point(467, 119);
            lblTable.Name = "lblTable";
            lblTable.Size = new Size(47, 20);
            lblTable.TabIndex = 6;
            lblTable.Text = "Table:";
            // 
            // cboTable
            // 
            cboTable.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTable.Location = new Point(592, 115);
            cboTable.Name = "cboTable";
            cboTable.Size = new Size(300, 28);
            cboTable.TabIndex = 7;
            // 
            // lblOrderDate
            // 
            lblOrderDate.AutoSize = true;
            lblOrderDate.Location = new Point(25, 80);
            lblOrderDate.Name = "lblOrderDate";
            lblOrderDate.Size = new Size(86, 20);
            lblOrderDate.TabIndex = 8;
            lblOrderDate.Text = "Order Date:";
            // 
            // dtpOrderDate
            // 
            dtpOrderDate.Location = new Point(150, 76);
            dtpOrderDate.Name = "dtpOrderDate";
            dtpOrderDate.Size = new Size(265, 27);
            dtpOrderDate.TabIndex = 9;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.Location = new Point(150, 116);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.ReadOnly = true;
            txtTotalAmount.Size = new Size(265, 27);
            txtTotalAmount.TabIndex = 11;
            txtTotalAmount.Text = "0.00";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Location = new Point(25, 120);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(102, 20);
            lblTotalAmount.TabIndex = 10;
            lblTotalAmount.Text = "Total Amount:";
            // 
            // grpDetail
            // 
            grpDetail.Controls.Add(lblMenuItem);
            grpDetail.Controls.Add(cboMenuItem);
            grpDetail.Controls.Add(lblQuantity);
            grpDetail.Controls.Add(nudQuantity);
            grpDetail.Controls.Add(btnAddItem);
            grpDetail.Controls.Add(btnRemoveItem);
            grpDetail.Controls.Add(dgvOrderDetails);
            grpDetail.Location = new Point(20, 251);
            grpDetail.Name = "grpDetail";
            grpDetail.Size = new Size(929, 309);
            grpDetail.TabIndex = 2;
            grpDetail.TabStop = false;
            grpDetail.Text = "Order Detail";
            // 
            // lblMenuItem
            // 
            lblMenuItem.AutoSize = true;
            lblMenuItem.Location = new Point(25, 40);
            lblMenuItem.Name = "lblMenuItem";
            lblMenuItem.Size = new Size(83, 20);
            lblMenuItem.TabIndex = 0;
            lblMenuItem.Text = "Menu Item:";
            // 
            // cboMenuItem
            // 
            cboMenuItem.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMenuItem.Location = new Point(140, 36);
            cboMenuItem.Name = "cboMenuItem";
            cboMenuItem.Size = new Size(574, 28);
            cboMenuItem.TabIndex = 1;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(25, 80);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(68, 20);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Quantity:";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(140, 78);
            nudQuantity.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(100, 27);
            nudQuantity.TabIndex = 3;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAddItem
            // 
            btnAddItem.Location = new Point(752, 26);
            btnAddItem.Name = "btnAddItem";
            btnAddItem.Size = new Size(140, 38);
            btnAddItem.TabIndex = 6;
            btnAddItem.Text = "Add Item";
            btnAddItem.UseVisualStyleBackColor = true;
            btnAddItem.Click += btnAddItem_Click_1;
            // 
            // btnRemoveItem
            // 
            btnRemoveItem.Location = new Point(752, 78);
            btnRemoveItem.Name = "btnRemoveItem";
            btnRemoveItem.Size = new Size(140, 38);
            btnRemoveItem.TabIndex = 7;
            btnRemoveItem.Text = "Remove Item";
            btnRemoveItem.UseVisualStyleBackColor = true;
            btnRemoveItem.Click += btnRemoveItem_Click_1;
            // 
            // dgvOrderDetails
            // 
            dgvOrderDetails.AllowUserToAddRows = false;
            dgvOrderDetails.AllowUserToDeleteRows = false;
            dgvOrderDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrderDetails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrderDetails.Columns.AddRange(new DataGridViewColumn[] { ItemID, ItemName, Quantity, Price });
            dgvOrderDetails.Location = new Point(25, 130);
            dgvOrderDetails.MultiSelect = false;
            dgvOrderDetails.Name = "dgvOrderDetails";
            dgvOrderDetails.ReadOnly = true;
            dgvOrderDetails.RowHeadersWidth = 51;
            dgvOrderDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrderDetails.Size = new Size(867, 149);
            dgvOrderDetails.TabIndex = 8;
            // 
            // ItemID
            // 
            ItemID.HeaderText = "Item ID";
            ItemID.MinimumWidth = 6;
            ItemID.Name = "ItemID";
            ItemID.ReadOnly = true;
            ItemID.Visible = false;
            // 
            // ItemName
            // 
            ItemName.HeaderText = "Menu Item";
            ItemName.MinimumWidth = 6;
            ItemName.Name = "ItemName";
            ItemName.ReadOnly = true;
            // 
            // Quantity
            // 
            Quantity.HeaderText = "Quantity";
            Quantity.MinimumWidth = 6;
            Quantity.Name = "Quantity";
            Quantity.ReadOnly = true;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            // 
            // grpActions
            // 
            grpActions.Controls.Add(btnAddOrder);
            grpActions.Controls.Add(btnClear);
            grpActions.Location = new Point(443, 582);
            grpActions.Name = "grpActions";
            grpActions.Size = new Size(506, 90);
            grpActions.TabIndex = 3;
            grpActions.TabStop = false;
            grpActions.Text = "Actions";
            // 
            // btnAddOrder
            // 
            btnAddOrder.Location = new Point(25, 35);
            btnAddOrder.Name = "btnAddOrder";
            btnAddOrder.Size = new Size(200, 40);
            btnAddOrder.TabIndex = 0;
            btnAddOrder.Text = "Add Order";
            btnAddOrder.Click += btnAddOrder_Click_1;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(278, 35);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(200, 40);
            btnClear.TabIndex = 1;
            btnClear.Text = "Clear";
            btnClear.Click += btnClear_Click_1;
            // 
            // EditOrderForm
            // 
            ClientSize = new Size(1011, 688);
            Controls.Add(lblTitle);
            Controls.Add(grpOrder);
            Controls.Add(grpDetail);
            Controls.Add(grpActions);
            Name = "EditOrderForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Edit";
            grpOrder.ResumeLayout(false);
            grpOrder.PerformLayout();
            grpDetail.ResumeLayout(false);
            grpDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvOrderDetails).EndInit();
            grpActions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpOrder;
        private System.Windows.Forms.Label lblOrderID;
        private System.Windows.Forms.TextBox txtOrderID;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cboEmployee;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.ComboBox cboTable;
        private System.Windows.Forms.Label lblOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.Label lblMenuItem;
        private System.Windows.Forms.ComboBox cboMenuItem;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnAddOrder;
        private System.Windows.Forms.Button btnClear;
        private DataGridViewTextBoxColumn ItemID;
        private DataGridViewTextBoxColumn ItemName;
        private DataGridViewTextBoxColumn Quantity;
        private DataGridViewTextBoxColumn Price;
    }
}
