namespace WinFormsApp1
{
    public partial class MainForm : Form
    {
        private string userRole;
        

        
        
        
        //Hàm chạy chính
        ///////////////////////////////////////////////
        public MainForm(string role)
        {
            InitializeComponent();
            userRole = role;

            if (userRole == "Staff")
            {
                btnEmployee.Enabled = false;
            }
        }

        ///////////////////////////////////////////////





        //Các hàm button
        ///////////////////////////////////////////////
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            EmployeeForm employeeForm = new EmployeeForm();
            employeeForm.Show();
        }

        private void btnTable_Click(object sender, EventArgs e)
        {
            TableForm tableForm = new TableForm();
            tableForm.Show();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportForm reportForm = new ReportForm();
            reportForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        ///////////////////////////////////////////////
    }
}
