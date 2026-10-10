using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditEmployeeForm : Form
    {
        //=============================================================================================================================================================================================
        public int EmployeeID { get; private set; }
        public string EmployeeName { get; private set; } = string.Empty;
        public string Position { get; private set; } = string.Empty;
        public string? Phone { get; private set; }

        // Biến cờ để xác định chế độ Sửa (true) hay Thêm mới (false)
        private bool isEditMode = false;
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        public EditEmployeeForm()
        {
            InitializeComponent();
        }





        // Hàm gọi từ EmployeeForm khi cần sửa dữ liệu nhân viên
        public void SetDataForUpdate(string id, string name, string position, string phone)
        {
            isEditMode = true; // Đánh dấu đang ở chế độ cập nhật

            txtEmployeeID.Text = id;
            txtEmployeeID.Enabled = false; // Khóa trường ID không cho chỉnh sửa
            txtName.Text = name;
            txtPosition.Text = position;
            txtPhone.Text = phone;
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Xử lý khi nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Employee_ID: Phải là số nguyên >= 1
            if (!int.TryParse(txtEmployeeID.Text.Trim(), out int employeeID) || employeeID < 1)
            {
                MessageBox.Show("Employee ID must be a positive integer!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeID.Focus();
                return;
            }

            // 2. Validate Name: Không được để trống
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Name!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 3. Validate Position: Không được để trống
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Please enter Position!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return;
            }

            // 4. Validate Phone: Cho phép để trống, nhưng nếu nhập thì không chứa chữ cái
            string inputPhone = txtPhone.Text.Trim();
            if (!string.IsNullOrEmpty(inputPhone))
            {
                if (inputPhone.Any(char.IsLetter))
                {
                    MessageBox.Show("Phone number cannot contain letters!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
            }

            // Gán dữ liệu vào các thuộc tính
            EmployeeID = employeeID;
            EmployeeName = txtName.Text.Trim();
            Position = txtPosition.Text.Trim();
            Phone = string.IsNullOrWhiteSpace(inputPhone) ? null : inputPhone;

            // 5. Lưu thông tin vào Database SQL
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    string query;
                    if (isEditMode)
                    {
                        // Lệnh SQL khi cập nhật nhân viên
                        query = @"UPDATE Employee 
                                  SET Name = @Name, Position = @Position, Phone = @Phone 
                                  WHERE Employee_ID = @Employee_ID";
                    }
                    else
                    {
                        // Lệnh SQL khi thêm mới nhân viên
                        query = @"INSERT INTO Employee (Employee_ID, Name, Position, Phone) 
                                  VALUES (@Employee_ID, @Name, @Position, @Phone)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Employee_ID", EmployeeID);
                        command.Parameters.AddWithValue("@Name", EmployeeName);
                        command.Parameters.AddWithValue("@Position", Position);

                        // Nếu Phone null thì truyền DBNull.Value vào SQL
                        command.Parameters.AddWithValue("@Phone", (object?)Phone ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(isEditMode ? "Employee updated successfully!" : "Employee added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving to the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
