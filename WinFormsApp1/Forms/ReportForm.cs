using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }





        private void ReportForm_Load(object sender, EventArgs e)
        {
            // Mặc định chọn báo cáo đầu tiên
            cmbReportType.SelectedIndex = 0;

            // Mặc định: từ đầu tháng đến hôm nay
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;
        }





        // Xử lý khi nhấn nút Generate
        private void btnGenerate_Click_1(object sender, EventArgs e)
        {
            if (cmbReportType.SelectedItem == null)
            {
                MessageBox.Show("Please select the report type!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string reportType = cmbReportType.SelectedItem.ToString() ?? "";
            DateTime fromDate = dtpFromDate.Value.Date;
            DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1); // Cuối ngày

            try
            {
                switch (reportType)
                {
                    case "Daily Orders":
                        GenerateDailyOrdersReport(fromDate, toDate);
                        break;
                    case "Sales Summary":
                        GenerateSalesSummaryReport(fromDate, toDate);
                        break;
                    case "Customer Orders":
                        GenerateCustomerOrdersReport(fromDate, toDate);
                        break;
                    case "Menu Item Sales":
                        GenerateMenuItemSalesReport(fromDate, toDate);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when generating report:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Báo cáo đơn hàng theo ngày
        private void GenerateDailyOrdersReport(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    CAST(o.Order_Date AS DATE) AS [Date],
                    COUNT(o.Order_ID) AS [Total Orders],
                    SUM(o.Total_Amount) AS [Total Revenue]
                FROM [Order] o
                WHERE o.Order_Date BETWEEN @FromDate AND @ToDate
                GROUP BY CAST(o.Order_Date AS DATE)
                ORDER BY [Date] DESC";

            LoadReportData(query, fromDate, toDate);
        }





        // Báo cáo tổng quan doanh thu
        private void GenerateSalesSummaryReport(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    COUNT(o.Order_ID) AS [Total Orders],
                    SUM(o.Total_Amount) AS [Total Revenue],
                    AVG(o.Total_Amount) AS [Average Order Value],
                    COUNT(DISTINCT o.Customer_ID) AS [Total Customers],
                    COUNT(DISTINCT o.Table_ID) AS [Tables Used]
                FROM [Order] o
                WHERE o.Order_Date BETWEEN @FromDate AND @ToDate";

            LoadReportData(query, fromDate, toDate);
        }





        // Báo cáo đơn hàng theo khách hàng
        private void GenerateCustomerOrdersReport(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    c.Customer_ID,
                    c.Name AS [Customer Name],
                    COUNT(o.Order_ID) AS [Total Orders],
                    SUM(o.Total_Amount) AS [Total Spent]
                FROM Customer c
                INNER JOIN [Order] o ON c.Customer_ID = o.Customer_ID
                WHERE o.Order_Date BETWEEN @FromDate AND @ToDate
                GROUP BY c.Customer_ID, c.Name
                ORDER BY [Total Spent] DESC";

            LoadReportData(query, fromDate, toDate);
        }





        // Báo cáo doanh số món ăn
        private void GenerateMenuItemSalesReport(DateTime fromDate, DateTime toDate)
        {
            string query = @"
                SELECT 
                    m.Item_ID,
                    m.Item_Name AS [Item Name],
                    m.Category,
                    SUM(od.Quantity) AS [Total Quantity Sold],
                    SUM(od.Quantity * m.Price) AS [Total Revenue]
                FROM Menu_Item m
                INNER JOIN Order_Detail od ON m.Item_ID = od.Item_ID
                INNER JOIN [Order] o ON od.Order_ID = o.Order_ID
                WHERE o.Order_Date BETWEEN @FromDate AND @ToDate
                GROUP BY m.Item_ID, m.Item_Name, m.Category
                ORDER BY [Total Quantity Sold] DESC";

            LoadReportData(query, fromDate, toDate);
        }





        // Hàm chung để load dữ liệu báo cáo
        private void LoadReportData(string query, DateTime fromDate, DateTime toDate)
        {
            using (SqlConnection connection = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvReport.DataSource = dataTable;

                        // Tự động điều chỉnh độ rộng cột
                        dgvReport.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                        MessageBox.Show($"Loaded {dataTable.Rows.Count} rows of data!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }





        // Xử lý khi nhấn nút Export
        private void btnExport_Click_1(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV File|*.csv|Text File|*.txt";
            saveDialog.FileName = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Ghi header
                    for (int i = 0; i < dgvReport.Columns.Count; i++)
                    {
                        sb.Append(dgvReport.Columns[i].HeaderText);
                        if (i < dgvReport.Columns.Count - 1)
                            sb.Append(",");
                    }
                    sb.AppendLine();

                    // Ghi dữ liệu
                    foreach (DataGridViewRow row in dgvReport.Rows)
                    {
                        if (row.IsNewRow) continue;

                        for (int i = 0; i < dgvReport.Columns.Count; i++)
                        {
                            sb.Append(row.Cells[i].Value?.ToString() ?? "");
                            if (i < dgvReport.Columns.Count - 1)
                                sb.Append(",");
                        }
                        sb.AppendLine();
                    }

                    File.WriteAllText(saveDialog.FileName, sb.ToString());
                    MessageBox.Show("Report exported successfully!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error when exporting file:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
