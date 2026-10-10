using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditTableForm : Form
    {
        //=============================================================================================================================================================================================
        public int TableID { get; private set; }
        public int TableNumber { get; private set; }
        public int Capacity { get; private set; }
        public string Status { get; private set; } = "Available";

        private bool isEditMode = false;
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        public EditTableForm()
        {
            InitializeComponent();
            InitializeComboBox();
        }





        // Tự động nạp 2 giá trị "Available" và "Occupied" vào ComboBox
        private void InitializeComboBox()
        {
            cboStatus.Items.Clear();
            cboStatus.Items.Add("Available");
            cboStatus.Items.Add("Occupied");
            cboStatus.SelectedIndex = 0; // Mặc định chọn Available
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList; // Không cho phép nhập chữ linh tinh
        }





        // Hàm truyền dữ liệu khi thực hiện UPDATE
        public void SetDataForUpdate(string id, string number, string capacity, string status)
        {
            isEditMode = true;

            txtTableID.Text = id;
            txtTableID.Enabled = false; // Khóa không cho sửa Table_ID
            txtTableNumber.Text = number;
            txtCapacity.Text = capacity;

            if (cboStatus.Items.Contains(status))
            {
                cboStatus.SelectedItem = status;
            }
            else
            {
                cboStatus.SelectedIndex = 0;
            }
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Xử lý khi nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Table_ID (Số nguyên >= 1)
            if (!int.TryParse(txtTableID.Text.Trim(), out int tableID) || tableID < 1)
            {
                MessageBox.Show("Table ID must be a positive integer (int) and greater than 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTableID.Focus();
                return;
            }

            // 2. Validate Table_Number (Số nguyên >= 1)
            if (!int.TryParse(txtTableNumber.Text.Trim(), out int tableNumber) || tableNumber < 1)
            {
                MessageBox.Show("Table Number must be a positive integer (int) and greater than 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTableNumber.Focus();
                return;
            }

            // 3. Validate Capacity (Số nguyên >= 1)
            if (!int.TryParse(txtCapacity.Text.Trim(), out int capacity) || capacity < 1)
            {
                MessageBox.Show("Capacity must be a positive integer (int) and greater than 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCapacity.Focus();
                return;
            }

            // 4. Validate Status từ ComboBox
            if (cboStatus.SelectedItem == null)
            {
                MessageBox.Show("Please select a Status (Available or Occupied)!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboStatus.Focus();
                return;
            }

            TableID = tableID;
            TableNumber = tableNumber;
            Capacity = capacity;
            Status = cboStatus.SelectedItem.ToString() ?? "Available";

            // 5. Lưu dữ liệu vào SQL Server
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (isEditMode)
                    {
                        query = @"UPDATE [Table] 
                                  SET Table_Number = @Table_Number, Capacity = @Capacity, Status = @Status 
                                  WHERE Table_ID = @Table_ID";
                    }
                    else
                    {
                        query = @"INSERT INTO [Table] (Table_ID, Table_Number, Capacity, Status) 
                                  VALUES (@Table_ID, @Table_Number, @Capacity, @Status)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Table_ID", TableID);
                        command.Parameters.AddWithValue("@Table_Number", TableNumber);
                        command.Parameters.AddWithValue("@Capacity", Capacity);
                        command.Parameters.AddWithValue("@Status", Status);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(isEditMode ? "Table updated successfully!" : "New table added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving data to the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Xử lý khi nhấn nút Cancel
        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //=============================================================================================================================================================================================
    }
}