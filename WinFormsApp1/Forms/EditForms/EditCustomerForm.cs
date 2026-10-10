using Microsoft.Data.SqlClient;
using System;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditCustomerForm : Form
    {
        //=============================================================================================================================================================================================
        public int CustomerID { get; private set; }
        public string CustomerName { get; private set; } = string.Empty;
        public string? Phone { get; private set; }
        public string? Email { get; private set; }

        // Biến cờ để nhận biết Form đang ở chế độ Sửa (true) hay Thêm mới (false)
        private bool isEditMode = false;
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        public EditCustomerForm()
        {
            InitializeComponent();
        }





        // Hàm gọi khi nhấn nút UPDATE từ CustomerForm
        public void SetDataForUpdate(string id, string name, string phone, string email)
        {
            isEditMode = true; // Đánh dấu là chế độ Cập nhật

            txtCustomerID.Text = id;
            txtCustomerID.Enabled = false; // Khóa không cho sửa Customer_ID (Khóa chính)
            txtName.Text = name;
            txtPhone.Text = phone;
            txtEmail.Text = email;
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Xử lý khi nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Customer_ID: Khóa chính, là số nguyên >= 1
            if (!int.TryParse(txtCustomerID.Text.Trim(), out int customerID) || customerID < 1)
            {
                MessageBox.Show("Customer ID must be an integer greater than or equal to 1!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerID.Focus();
                return;
            }

            // 2. Validate Name: Không được để trống
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter Name!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }

            // 3. Validate Phone: Nếu người dùng có nhập thì KHÔNG ĐƯỢC chứa chữ cái
            string inputPhone = txtPhone.Text.Trim();
            if (!string.IsNullOrEmpty(inputPhone))
            {
                // Kiểm tra xem chuỗi phone có chứa ký tự chữ cái hay không
                if (inputPhone.Any(char.IsLetter))
                {
                    MessageBox.Show("Phone number cannot contain letters!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return;
                }
            }

            // 4. Lấy giá trị từ TextBox (Nếu rỗng thì gán null)
            CustomerID = customerID;
            CustomerName = txtName.Text.Trim();
            Phone = string.IsNullOrWhiteSpace(inputPhone) ? null : inputPhone;
            Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();

            // 5. Lưu vào SQL Database
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    string query;
                    if (isEditMode)
                    {
                        // Câu lệnh UPDATE khi ở chế độ sửa
                        query = @"UPDATE Customer 
                                  SET Name = @Name, Phone = @Phone, Email = @Email 
                                  WHERE Customer_ID = @Customer_ID";
                    }
                    else
                    {
                        // Câu lệnh INSERT khi ở chế độ thêm mới
                        query = @"INSERT INTO Customer (Customer_ID, Name, Phone, Email) 
                                  VALUES (@Customer_ID, @Name, @Phone, @Email)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Customer_ID", CustomerID);
                        command.Parameters.AddWithValue("@Name", CustomerName);

                        // Dùng DBNull.Value nếu biến bị null để SQL Server lưu đúng giá trị NULL
                        command.Parameters.AddWithValue("@Phone", (object?)Phone ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Email", (object?)Email ?? DBNull.Value);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(isEditMode ? "Customer updated successfully!" : "Customer added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving to the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Xử lý khi nhấn nút Cancel
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //=============================================================================================================================================================================================
    }
}