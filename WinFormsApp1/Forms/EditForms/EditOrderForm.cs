using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditOrderForm : Form
    {
        //=============================================================================================================================================================================================
        // Properties
        public int OrderID { get; private set; }
        private bool isEditMode = false;
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Class trợ giúp Binding dữ liệu cho ComboBox
        private class ComboboxItem
        {
            public string Text { get; set; } = string.Empty;
            public object Value { get; set; } = 0;

            public override string ToString()
            {
                return Text;
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        public EditOrderForm()
        {
            InitializeComponent();
            SetupDataGridViewColumns();
            LoadComboBoxData();
        }





        // Thiết lập cấu trúc DataGridView chứa chi tiết đơn hàng
        private void SetupDataGridViewColumns()
        {
            if (dgvOrderDetails.Columns.Count == 0)
            {
                dgvOrderDetails.Columns.Add("ItemID", "Item ID");
                dgvOrderDetails.Columns.Add("ItemName", "Menu Item");
                dgvOrderDetails.Columns.Add("Quantity", "Quantity");
                dgvOrderDetails.Columns.Add("Price", "Price");

                // Ẩn cột ItemID nếu không muốn hiển thị ra UI
                dgvOrderDetails.Columns["ItemID"]?.Visible = false;
            }
        }





        // Load dữ liệu thả xuống (Customer, Employee, Table, Menu Item)
        private void LoadComboBoxData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    // 1. Tải Khách hàng
                    cboCustomer.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT Customer_ID, Name FROM Customer", connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            cboCustomer.Items.Add(new ComboboxItem { Text = $"{id} - {name}", Value = id });
                        }
                    }

                    // 2. Tải Nhân viên
                    cboEmployee.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT Employee_ID, Name FROM Employee", connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            cboEmployee.Items.Add(new ComboboxItem { Text = $"{id} - {name}", Value = id });
                        }
                    }

                    // 3. Tải Bàn ăn
                    cboTable.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT Table_ID, Table_Number FROM [Table]", connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            int num = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                            cboTable.Items.Add(new ComboboxItem { Text = $"Table {num}", Value = id });
                        }
                    }

                    // 4. Tải Menu món ăn
                    cboMenuItem.Items.Clear();
                    using (SqlCommand cmd = new SqlCommand("SELECT Item_ID, Item_Name, Price FROM Menu_Item", connection))
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                            decimal price = reader.IsDBNull(2) ? 0m : reader.GetDecimal(2);
                            cboMenuItem.Items.Add(new ComboboxItem { Text = $"{name} ({price:N0} VNĐ)", Value = id });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while loading dropdown lists:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Thiết lập dữ liệu khi gọi sửa đơn hàng
        public void SetDataForUpdate(int orderId)
        {
            isEditMode = true;
            this.OrderID = orderId;
            txtOrderID.Text = orderId.ToString();
            txtOrderID.Enabled = false; // Khóa Order ID

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    // Tải thông tin Order
                    string queryOrder = "SELECT Customer_ID, Employee_ID, Table_ID, Order_Date, Total_Amount FROM [Order] WHERE Order_ID = @Order_ID";
                    using (SqlCommand cmd = new SqlCommand(queryOrder, connection))
                    {
                        cmd.Parameters.AddWithValue("@Order_ID", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int customerId = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                                int employeeId = reader.IsDBNull(1) ? 0 : reader.GetInt32(1);
                                int tableId = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);

                                SelectComboboxByValue(cboCustomer, customerId);
                                SelectComboboxByValue(cboEmployee, employeeId);
                                SelectComboboxByValue(cboTable, tableId);

                                if (!reader.IsDBNull(3)) dtpOrderDate.Value = reader.GetDateTime(3);
                                txtTotalAmount.Text = reader.IsDBNull(4) ? "0.00" : reader.GetDecimal(4).ToString("F2");
                            }
                        }
                    }

                    // Tải danh sách các món trong Order_Detail
                    string queryDetail = @"SELECT od.Item_ID, m.Item_Name, od.Quantity, m.Price 
                                           FROM Order_Detail od
                                           JOIN Menu_Item m ON od.Item_ID = m.Item_ID
                                           WHERE od.Order_ID = @Order_ID";

                    using (SqlCommand cmd = new SqlCommand(queryDetail, connection))
                    {
                        cmd.Parameters.AddWithValue("@Order_ID", orderId);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            dgvOrderDetails.Rows.Clear();
                            while (reader.Read())
                            {
                                int itemId = reader.GetInt32(0);
                                string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                int qty = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                decimal price = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3);

                                dgvOrderDetails.Rows.Add(itemId, name, qty, price);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while loading order details:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void SelectComboboxByValue(ComboBox cbo, int value)
        {
            foreach (ComboboxItem item in cbo.Items)
            {
                if ((int)item.Value == value)
                {
                    cbo.SelectedItem = item;
                    break;
                }
            }
        }
        //=============================================================================================================================================================================================











        //=============================================================================================================================================================================================
        // Nút Add Item (Thêm món vào chi tiết đơn)
        private void btnAddItem_Click_1(object sender, EventArgs e)
        {
            if (cboMenuItem.SelectedItem == null)
            {
                MessageBox.Show("Please select a menu item!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int qty = (int)nudQuantity.Value;
            if (qty <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ComboboxItem selectedMenu = (ComboboxItem)cboMenuItem.SelectedItem;
            int itemId = (int)selectedMenu.Value;

            // Kiểm tra xem món ăn này đã được thêm trong DataGridView chưa
            bool exists = false;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.IsNewRow) continue;
                if (int.TryParse(row.Cells["ItemID"].Value?.ToString(), out int existingId) && existingId == itemId)
                {
                    int oldQty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = oldQty + qty;
                    exists = true;
                    break;
                }
            }

            if (!exists)
            {
                // Lấy đơn giá từ SQL
                decimal price = GetMenuItemPrice(itemId);
                dgvOrderDetails.Rows.Add(itemId, selectedMenu.Text, qty, price);
            }

            CalculateTotalAmount();
        }





        // Lấy giá món ăn
        private decimal GetMenuItemPrice(int itemId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Price FROM Menu_Item WHERE Item_ID = @Item_ID";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Item_ID", itemId);
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) return Convert.ToDecimal(result);
                    }
                }
            }
            catch { }
            return 0m;
        }





        // Nút Remove Item (Xóa món khỏi chi tiết đơn)
        private void btnRemoveItem_Click_1(object sender, EventArgs e)
        {
            if (dgvOrderDetails.CurrentRow != null && !dgvOrderDetails.CurrentRow.IsNewRow)
            {
                dgvOrderDetails.Rows.Remove(dgvOrderDetails.CurrentRow);
                CalculateTotalAmount();
            }
            else
            {
                MessageBox.Show("Please select an item to remove!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }





        // Tính tổng tiền tự động
        private void CalculateTotalAmount()
        {
            decimal total = 0m;
            foreach (DataGridViewRow row in dgvOrderDetails.Rows)
            {
                if (row.IsNewRow) continue;
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);
                total += qty * price;
            }
            txtTotalAmount.Text = total.ToString("F2");
        }





        // Nút Add Order / Save
        private void btnAddOrder_Click_1(object sender, EventArgs e)
        {
            // 1. Validation dữ liệu đầu vào (Check trước khi mở Connection)
            if (cboCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEmployee.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboTable.SelectedItem == null)
            {
                MessageBox.Show("Please select a table!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvOrderDetails.Rows.Count == 0 || (dgvOrderDetails.Rows.Count == 1 && dgvOrderDetails.Rows[0].IsNewRow))
            {
                MessageBox.Show("The order must have at least 1 menu item!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int currentOrderId = this.OrderID;

            // Chuyển phần check txtOrderID lên đây nếu ở chế độ Thêm mới
            if (!isEditMode)
            {
                if (!int.TryParse(txtOrderID.Text.Trim(), out currentOrderId) || currentOrderId < 1)
                {
                    MessageBox.Show("Order ID must be a positive integer (int) and greater than 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtOrderID.Focus();
                    return;
                }
            }

            int customerId = (int)((ComboboxItem)cboCustomer.SelectedItem).Value;
            int employeeId = (int)((ComboboxItem)cboEmployee.SelectedItem).Value;
            int tableId = (int)((ComboboxItem)cboTable.SelectedItem).Value;
            DateTime orderDate = dtpOrderDate.Value;
            decimal totalAmount = decimal.TryParse(txtTotalAmount.Text, out decimal t) ? t : 0m;

            // 2. Thực thi Database Transaction
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            if (!isEditMode)
                            {
                                // Chế độ Thêm mới Đơn hàng
                                string insertOrderQuery = @"INSERT INTO [Order] (Order_ID, Customer_ID, Employee_ID, Table_ID, Order_Date, Total_Amount) 
                                                   VALUES (@Order_ID, @Customer_ID, @Employee_ID, @Table_ID, @Order_Date, @Total_Amount)";

                                using (SqlCommand cmd = new SqlCommand(insertOrderQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Order_ID", currentOrderId);
                                    cmd.Parameters.AddWithValue("@Customer_ID", customerId);
                                    cmd.Parameters.AddWithValue("@Employee_ID", employeeId);
                                    cmd.Parameters.AddWithValue("@Table_ID", tableId);
                                    cmd.Parameters.AddWithValue("@Order_Date", orderDate);
                                    cmd.Parameters.AddWithValue("@Total_Amount", totalAmount);

                                    cmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Chế độ Cập nhật Đơn hàng
                                string updateOrderQuery = @"UPDATE [Order] 
                                                   SET Customer_ID = @Customer_ID, Employee_ID = @Employee_ID, 
                                                       Table_ID = @Table_ID, Order_Date = @Order_Date, Total_Amount = @Total_Amount 
                                                   WHERE Order_ID = @Order_ID";

                                using (SqlCommand cmd = new SqlCommand(updateOrderQuery, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Order_ID", currentOrderId);
                                    cmd.Parameters.AddWithValue("@Customer_ID", customerId);
                                    cmd.Parameters.AddWithValue("@Employee_ID", employeeId);
                                    cmd.Parameters.AddWithValue("@Table_ID", tableId);
                                    cmd.Parameters.AddWithValue("@Order_Date", orderDate);
                                    cmd.Parameters.AddWithValue("@Total_Amount", totalAmount);

                                    cmd.ExecuteNonQuery();
                                }

                                // Xóa các chi tiết cũ trước khi thêm lại
                                string deleteOldDetails = "DELETE FROM Order_Detail WHERE Order_ID = @Order_ID";
                                using (SqlCommand cmd = new SqlCommand(deleteOldDetails, connection, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@Order_ID", currentOrderId);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 3. Chèn danh sách chi tiết đơn hàng
                            string insertDetailQuery = @"INSERT INTO Order_Detail (Order_ID, Item_ID, Quantity) 
                                               VALUES (@Order_ID, @Item_ID, @Quantity)";

                            using (SqlCommand cmdDetail = new SqlCommand(insertDetailQuery, connection, transaction))
                            {
                                cmdDetail.Parameters.Add("@Order_ID", SqlDbType.Int);
                                cmdDetail.Parameters.Add("@Item_ID", SqlDbType.Int);
                                cmdDetail.Parameters.Add("@Quantity", SqlDbType.Int);

                                foreach (DataGridViewRow row in dgvOrderDetails.Rows)
                                {
                                    if (row.IsNewRow) continue;

                                    cmdDetail.Parameters["@Order_ID"].Value = currentOrderId;
                                    cmdDetail.Parameters["@Item_ID"].Value = Convert.ToInt32(row.Cells["ItemID"].Value);
                                    cmdDetail.Parameters["@Quantity"].Value = Convert.ToInt32(row.Cells["Quantity"].Value);

                                    cmdDetail.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show(isEditMode ? "Cập nhật đơn hàng thành công!" : "Tạo đơn hàng mới thành công!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving the order to the database:\n" + ex.Message,
                                "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Nút Clear / Làm mới
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            if (cboCustomer.Items.Count > 0) cboCustomer.SelectedIndex = -1;
            if (cboEmployee.Items.Count > 0) cboEmployee.SelectedIndex = -1;
            if (cboTable.Items.Count > 0) cboTable.SelectedIndex = -1;
            if (cboMenuItem.Items.Count > 0) cboMenuItem.SelectedIndex = -1;

            dtpOrderDate.Value = DateTime.Now;
            nudQuantity.Value = 1;
            dgvOrderDetails.Rows.Clear();
            txtTotalAmount.Text = "0.00";
        }
        //=============================================================================================================================================================================================
    }
}