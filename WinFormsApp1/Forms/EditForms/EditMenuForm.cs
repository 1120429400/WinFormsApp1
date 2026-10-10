using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class EditMenuForm : Form
    {
        //=============================================================================================================================================================================================
        public int ItemID { get; private set; }
        public string ItemName { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public decimal Price { get; private set; }

        private bool isEditMode = false;
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        public EditMenuForm()
        {
            InitializeComponent();
            InitializeCategories();
        }





        // Khởi tạo danh sách Category theo yêu cầu
        private void InitializeCategories()
        {
            cboCategory.Items.Clear();
            cboCategory.Items.Add("Appetizer");
            cboCategory.Items.Add("Main Course");
            cboCategory.Items.Add("Dessert");
            cboCategory.Items.Add("Beverage");

            // Mặc định chọn mục đầu tiên
            cboCategory.SelectedIndex = 0;
        }





        // Truyền dữ liệu sang form khi thực hiện UPDATE
        public void SetDataForUpdate(string id, string name, string category, string price)
        {
            isEditMode = true;

            txtItemID.Text = id;
            txtItemID.Enabled = false; // Khóa không cho sửa Item ID
            txtItemName.Text = name;

            if (cboCategory.Items.Contains(category))
            {
                cboCategory.SelectedItem = category;
            }
            else
            {
                cboCategory.Text = category;
            }

            txtPrice.Text = price;
        }
        //=============================================================================================================================================================================================










        //=============================================================================================================================================================================================
        // Xử lý khi nhấn nút Save
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra Item_ID (int >= 1)
            if (!int.TryParse(txtItemID.Text.Trim(), out int itemID) || itemID < 1)
            {
                MessageBox.Show("Item ID must be a positive integer (int) and greater than 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemID.Focus();
                return;
            }

            // 2. Kiểm tra Item_Name (Không được trống)
            if (string.IsNullOrWhiteSpace(txtItemName.Text))
            {
                MessageBox.Show("Please enter the item name!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtItemName.Focus();
                return;
            }

            // 3. Kiểm tra Category (Không được trống)
            string selectedCategory = cboCategory.Text.Trim();
            if (string.IsNullOrWhiteSpace(selectedCategory))
            {
                MessageBox.Show("Please select a category!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return;
            }

            // 4. Kiểm tra Price (decimal >= 0)
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Price must be a valid decimal number and greater than or equal to 0!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
                return;
            }

            ItemID = itemID;
            ItemName = txtItemName.Text.Trim();
            Category = selectedCategory;
            Price = price;

            // 5. Thêm mới hoặc Cập nhật vào Cơ sở dữ liệu SQL Server
            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();
                    string query;

                    if (isEditMode)
                    {
                        query = @"UPDATE Menu_Item 
                                  SET Item_Name = @Item_Name, Category = @Category, Price = @Price 
                                  WHERE Item_ID = @Item_ID";
                    }
                    else
                    {
                        query = @"INSERT INTO Menu_Item (Item_ID, Item_Name, Category, Price) 
                                  VALUES (@Item_ID, @Item_Name, @Category, @Price)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Item_ID", ItemID);
                        command.Parameters.AddWithValue("@Item_Name", ItemName);
                        command.Parameters.AddWithValue("@Category", Category);
                        // Truyền tham số kiểu decimal
                        command.Parameters.AddWithValue("@Price", Price);

                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show(isEditMode ? "Item updated successfully!" : "New item added successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred while saving data to the database:\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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