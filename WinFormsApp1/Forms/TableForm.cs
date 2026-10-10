using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class TableForm : Form
    {
        //=============================================================================================================================================================================================
        public TableForm()
        {
            InitializeComponent();

            //Gọi trực tiếp hàm tải dữ liệu khi khởi tạo Form
            LoadTableData();
        }





        // Hàm nạp dữ liệu từ SQL Server lên DataGridView
        public void LoadTableData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Table_ID, Table_Number, Capacity, Status FROM [Table]";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgvTables.Rows.Clear(); // Xóa sạch dữ liệu cũ trước khi nạp mới

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                int number = reader.GetInt32(1);
                                int capacity = reader.GetInt32(2);
                                string status = reader.IsDBNull(3) ? "Available" : reader.GetString(3);

                                dgvTables.Rows.Add(id, number, capacity, status);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when loading Table data from Database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Nút ADD - Thêm bàn mới
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditTableForm editForm = new EditTableForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadTableData(); // Tải lại bảng sau khi thêm thành công
            }
        }





        // Nút UPDATE - Cập nhật thông tin bàn
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvTables.CurrentRow == null || dgvTables.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please click on a table in the list before clicking UPDATE!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvTables.CurrentRow;
            string id = selectedRow.Cells[0].Value?.ToString() ?? "";
            string number = selectedRow.Cells[1].Value?.ToString() ?? "";
            string capacity = selectedRow.Cells[2].Value?.ToString() ?? "";
            string status = selectedRow.Cells[3].Value?.ToString() ?? "Available";

            EditTableForm editForm = new EditTableForm();
            editForm.SetDataForUpdate(id, number, capacity, status);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadTableData(); // Tải lại bảng sau khi sửa thành công
            }
        }





        // Nút DELETE - Xóa bàn
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvTables.CurrentRow == null || dgvTables.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please click on a table in the list before clicking DELETE!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tableNum = dgvTables.CurrentRow.Cells[1].Value?.ToString() ?? "";
            string idStr = dgvTables.CurrentRow.Cells[0].Value?.ToString() ?? "0";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete Table {tableNum} (ID: {idStr})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(idStr, out int tableID))
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM [Table] WHERE Table_ID = @Table_ID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Table_ID", tableID);
                                command.ExecuteNonQuery();
                            }
                        }

                        LoadTableData(); // Tải lại bảng sau khi xóa thành công
                        MessageBox.Show("Table deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error when deleting table from Database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        // Nút SEARCH - Tìm kiếm bàn theo Table_ID
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                foreach (DataGridViewRow row in dgvTables.Rows)
                {
                    if (!row.IsNewRow) row.Visible = true;
                }
                return;
            }

            if (!int.TryParse(searchInput, out int searchID))
            {
                MessageBox.Show("Please enter a valid Table ID!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isFound = false;
            foreach (DataGridViewRow row in dgvTables.Rows)
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
                MessageBox.Show($"No table found with ID: {searchID}", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================================================================================================================================
    }
}