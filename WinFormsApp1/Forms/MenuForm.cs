using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class MenuForm : Form
    {
        //=============================================================================================================================================================================================
        public MenuForm()
        {
            InitializeComponent();
            LoadMenuData();
        }





        // Đọc dữ liệu từ cơ sở dữ liệu lên DataGridView
        public void LoadMenuData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT Item_ID, Item_Name, Category, Price FROM Menu_Item";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgvMenuItems.Rows.Clear();

                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                string category = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                decimal price = reader.IsDBNull(3) ? 0m : reader.GetDecimal(3);

                                dgvMenuItems.Rows.Add(id, name, category, price);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when loading Menu list:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Nút ADD
        private void btnAdd_Click(object sender, EventArgs e)
        {
            EditMenuForm editForm = new EditMenuForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadMenuData();
            }
        }





        // Nút UPDATE
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.CurrentRow == null || dgvMenuItems.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a row in the list to update!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = dgvMenuItems.CurrentRow;
            string id = selectedRow.Cells[0].Value?.ToString() ?? "";
            string name = selectedRow.Cells[1].Value?.ToString() ?? "";
            string category = selectedRow.Cells[2].Value?.ToString() ?? "";
            string price = selectedRow.Cells[3].Value?.ToString() ?? "0";

            EditMenuForm editForm = new EditMenuForm();
            editForm.SetDataForUpdate(id, name, category, price);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadMenuData();
            }
        }





        // Nút DELETE
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvMenuItems.CurrentRow == null || dgvMenuItems.CurrentRow.IsNewRow)
            {
                MessageBox.Show("Please select a row in the list to delete!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string itemName = dgvMenuItems.CurrentRow.Cells[1].Value?.ToString() ?? "";
            string idStr = dgvMenuItems.CurrentRow.Cells[0].Value?.ToString() ?? "0";

            DialogResult result = MessageBox.Show($"Are you sure you want to delete the item '{itemName}' (ID: {idStr})?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (int.TryParse(idStr, out int itemID))
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                        {
                            connection.Open();
                            string query = "DELETE FROM Menu_Item WHERE Item_ID = @Item_ID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Item_ID", itemID);
                                command.ExecuteNonQuery();
                            }
                        }

                        LoadMenuData();
                        MessageBox.Show("Item deleted successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error when deleting from database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }





        // Nút SEARCH
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchInput = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchInput))
            {
                foreach (DataGridViewRow row in dgvMenuItems.Rows)
                {
                    if (!row.IsNewRow) row.Visible = true;
                }
                return;
            }

            if (!int.TryParse(searchInput, out int searchID))
            {
                MessageBox.Show("Please enter a valid Item ID (integer)!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool found = false;
            foreach (DataGridViewRow row in dgvMenuItems.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells[0].Value?.ToString(), out int currentID))
                {
                    if (currentID == searchID)
                    {
                        row.Visible = true;
                        found = true;
                    }
                    else
                    {
                        row.Visible = false;
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show($"Item with ID {searchID} not found.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //=============================================================================================================================================================================================
    }
}