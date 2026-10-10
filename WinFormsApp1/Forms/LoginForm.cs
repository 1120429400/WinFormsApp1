using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Please enter your username.");
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your password.");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT Password_Hash, Role
                FROM [User]
                WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Invalid username or password.");
                                return;
                            }

                            string storedHash = reader["Password_Hash"].ToString()!;
                            string role = reader["Role"].ToString()!;

                            bool isValid = PasswordHelper.VerifyPassword(password, storedHash);

                            if (!isValid)
                            {
                                MessageBox.Show("Invalid username or password.");
                                return;
                            }

                            MessageBox.Show("Login successful!");

                            MainForm mainForm = new MainForm(role);

                            mainForm.Show();

                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login failed:\n" + ex.Message);
            }
        }
    }
}
