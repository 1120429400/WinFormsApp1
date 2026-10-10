using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class OrderForm : Form
    {
        //=============================================================================================================================================================================================
        public OrderForm()
        {
            InitializeComponent();
            LoadOrderData();
        }





        // Tải dữ liệu danh sách hóa đơn từ Database SQL Server
        public void LoadOrderData()
        {
            try
            {
                dgvOrders.AllowUserToAddRows = false; // Tắt dòng trống mặc định bên dưới DataGridView
                dgvOrders.Rows.Clear(); // Xóa sạch dữ liệu cữ
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = @"SELECT Order_ID, Customer_ID, Employee_ID, Table_ID, Order_Date, Total_Amount 
                                    FROM [Order]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgvOrders.Rows.Clear(); // Xóa sạch các dòng cũ trên DataGridView

                            while (reader.Read())
                            {
                                int orderId = reader.GetInt32(0);
                                string customerId = reader.IsDBNull(1) ? "N/A" : reader.GetInt32(1).ToString();
                                string employeeId = reader.IsDBNull(2) ? "N/A" : reader.GetInt32(2).ToString();
                                string tableId = reader.IsDBNull(3) ? "N/A" : reader.GetInt32(3).ToString();

                                string orderDate = reader.IsDBNull(4)
                                    ? ""
                                    : reader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm:ss");

                                string totalAmount = reader.IsDBNull(5)
                                    ? "0.00"
                                    : reader.GetDecimal(5).ToString("N2");

                                dgvOrders.Rows.Add(orderId, customerId, employeeId, tableId, orderDate, totalAmount);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when downloading order data from Database:\n" + ex.Message,
                                "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            EditOrderForm editForm = new EditOrderForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadOrderData();
            }
        }





        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null || dgvOrders.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an order from the table to edit!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvOrders.CurrentRow;
            string orderIdStr = selectedRow.Cells[0].Value?.ToString() ?? "0";

            if (int.TryParse(orderIdStr, out int orderId))
            {
                EditOrderForm editForm = new EditOrderForm();
                editForm.SetDataForUpdate(orderId);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadOrderData();
                }
            }
        }





        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow == null || dgvOrders.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an order from the table to delete!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string orderIdStr = dgvOrders.CurrentRow.Cells[0].Value?.ToString() ?? "0";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete order ID: {orderIdStr}?\nAll related order details will also be deleted!",
                                                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && int.TryParse(orderIdStr, out int orderID))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                    {
                        connection.Open();
                        using (SqlTransaction transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                // 1. Xóa tất cả Order_Detail liên quan trước
                                string deleteDetailsQuery = "DELETE FROM Order_Detail WHERE Order_ID = @Order_ID";
                                using (SqlCommand cmdDetails = new SqlCommand(deleteDetailsQuery, connection, transaction))
                                {
                                    cmdDetails.Parameters.AddWithValue("@Order_ID", orderID);
                                    cmdDetails.ExecuteNonQuery();
                                }

                                // 2. Xóa hợp lệ hóa đơn trong bảng [Order]
                                string deleteOrderQuery = "DELETE FROM [Order] WHERE Order_ID = @Order_ID";
                                using (SqlCommand cmdOrder = new SqlCommand(deleteOrderQuery, connection, transaction))
                                {
                                    cmdOrder.Parameters.AddWithValue("@Order_ID", orderID);
                                    cmdOrder.ExecuteNonQuery();
                                }

                                transaction.Commit();
                                MessageBox.Show("Order deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadOrderData();
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
                    MessageBox.Show("Error when deleting from Database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }





        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchInput = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (!row.IsNewRow) row.Visible = true;
                }
                return;
            }

            if (!int.TryParse(searchInput, out int searchID))
            {
                MessageBox.Show("Please enter a valid integer ID!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isFound = false;
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells[0].Value?.ToString(), out int currentID))
                {
                    if (currentID == searchID)
                    {
                        row.Visible = true;
                        isFound = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }

            if (!isFound)
            {
                MessageBox.Show($"Order not found with ID: {searchID}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================================================================================================================================
    }
}