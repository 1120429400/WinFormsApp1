using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CustomerForm : Form
    {
        //=============================================================================================================================================================================================
        public CustomerForm()
        {
            InitializeComponent();
            LoadCustomerData();
        }





        public void LoadCustomerData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Customer_ID, Name, Phone, Email FROM Customer";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgvCustomers.Rows.Clear(); // Xóa sạch các dòng cũ trên DataGridView

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                string phone = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                string email = reader.IsDBNull(3) ? "" : reader.GetString(3);

                                dgvCustomers.Rows.Add(id, name, phone, email);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data from the database: " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditCustomerForm editForm = new EditCustomerForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                int id = editForm.CustomerID;
                string name = editForm.CustomerName;
                string phone = editForm.Phone ?? "";
                string email = editForm.Email ?? "";
                dgvCustomers.Rows.Add(id, name, phone, email);
                // Sau khi thêm thành công vào SQL, tải lại toàn bộ bảng đã cập nhật trên DataGridView
                LoadCustomerData();
            }
        }





        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a row in the table before clicking UPDATE!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvCustomers.CurrentRow;
            string id = selectedRow.Cells[0].Value?.ToString() ?? "";
            string name = selectedRow.Cells[1].Value?.ToString() ?? "";
            string phone = selectedRow.Cells[2].Value?.ToString() ?? "";
            string email = selectedRow.Cells[3].Value?.ToString() ?? "";

            EditCustomerForm editForm = new EditCustomerForm();
            editForm.SetDataForUpdate(id, name, phone, email);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedRow.Cells[0].Value = editForm.CustomerID;
                selectedRow.Cells[1].Value = editForm.CustomerName;
                selectedRow.Cells[2].Value = editForm.Phone;
                selectedRow.Cells[3].Value = editForm.Email;
                // Sau khi sửa thành công vào SQL, tải lại dữ liệu mới nhất
                LoadCustomerData();
            }
        }





        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null || dgvCustomers.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a row in the table before clicking DELETE!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string customerName = dgvCustomers.CurrentRow.Cells[1].Value?.ToString() ?? "this customer";
            string idStr = dgvCustomers.CurrentRow.Cells[0].Value?.ToString() ?? "0";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {customerName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(idStr, out int customerID))
                {
                    try
                    {
                        // Thực hiện xóa dòng tương ứng trong Database SQL
                        using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM Customer WHERE Customer_ID = @Customer_ID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Customer_ID", customerID);
                                command.ExecuteNonQuery();
                            }
                        }

                        dgvCustomers.Rows.Remove(dgvCustomers.CurrentRow);
                        // Sau khi xóa xong trong DB, tải lại DataGridView
                        LoadCustomerData();
                        MessageBox.Show("Successfully deleted!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while deleting from the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                foreach (DataGridViewRow row in dgvCustomers.Rows)
                {
                    if (!row.IsNewRow) row.Visible = true;
                }
                return;
            }

            if (!int.TryParse(searchInput, out int searchID))
            {
                MessageBox.Show("Please enter a valid numeric ID!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isFound = false;
            foreach (DataGridViewRow row in dgvCustomers.Rows)
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
                MessageBox.Show($"Customer with ID {searchID} not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================================================================================================================================
    }
}