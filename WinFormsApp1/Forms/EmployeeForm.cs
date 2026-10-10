using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EmployeeForm : Form
    {
        //=============================================================================================================================================================================================
        public EmployeeForm()
        {
            InitializeComponent();
            LoadEmployeeData();
        }





        public void LoadEmployeeData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Employee_ID, Name, Position, Phone FROM Employee";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgvEmployees.Rows.Clear(); // Xóa sạch các dòng cũ trên DataGridView

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                string position = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                string phone = reader.IsDBNull(3) ? "" : reader.GetString(3);

                                dgvEmployees.Rows.Add(id, name, position, phone);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee data from the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Nút ADD - Thêm mới nhân viên
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditEmployeeForm editForm = new EditEmployeeForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                int id = editForm.EmployeeID;
                string name = editForm.EmployeeName;
                string position = editForm.Position;
                string phone = editForm.Phone ?? "";
                dgvEmployees.Rows.Add(id, name, position, phone);
                // Sau khi lưu xong vào SQL, tải lại bảng để hiển thị
                LoadEmployeeData();
            }
        }





        // Nút UPDATE - Cập nhật nhân viên dang chọn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null || dgvEmployees.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an employee from the list before receiving the update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvEmployees.CurrentRow;
            string id = selectedRow.Cells[0].Value?.ToString() ?? "";
            string name = selectedRow.Cells[1].Value?.ToString() ?? "";
            string position = selectedRow.Cells[2].Value?.ToString() ?? "";
            string phone = selectedRow.Cells[3].Value?.ToString() ?? "";

            EditEmployeeForm editForm = new EditEmployeeForm();
            editForm.SetDataForUpdate(id, name, position, phone);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                selectedRow.Cells[0].Value = editForm.EmployeeID;
                selectedRow.Cells[1].Value = editForm.EmployeeName;
                selectedRow.Cells[2].Value = editForm.Position;
                selectedRow.Cells[3].Value = editForm.Phone;
                // Tải lại bảng sau khi cập nhật dữ liệu thành công
                LoadEmployeeData();
            }
        }





        // Nút DELETE - Xóa nhân viên khỏi Database và DataGridView
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null || dgvEmployees.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select an employee from the list before receiving the delete!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string empName = dgvEmployees.CurrentRow.Cells[1].Value?.ToString() ?? "this employee";
            string idStr = dgvEmployees.CurrentRow.Cells[0].Value?.ToString() ?? "0";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete employee {empName}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(idStr, out int employeeID))
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM Employee WHERE Employee_ID = @Employee_ID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Employee_ID", employeeID);
                                command.ExecuteNonQuery();
                            }
                        }

                        dgvEmployees.Rows.Remove(dgvEmployees.CurrentRow);
                        // Tải lại DataGridView sau khi xóa thành công
                        LoadEmployeeData();
                        MessageBox.Show("Employee deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error occurred while deleting employee from the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        // Nút SEARCH - Tìm kiếmm theo ID nhân viên
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                foreach (DataGridViewRow row in dgvEmployees.Rows)
                {
                    if (!row.IsNewRow) row.Visible = true;
                }
                return;
            }

            if (!int.TryParse(searchInput, out int searchID))
            {
                MessageBox.Show("Please enter a valid employee ID!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isFound = false;
            foreach (DataGridViewRow row in dgvEmployees.Rows)
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
                MessageBox.Show($"Employee with ID {searchID} not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================================================================================================================================
    }
}