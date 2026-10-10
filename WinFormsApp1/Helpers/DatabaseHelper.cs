using Microsoft.Data.SqlClient;

namespace WinFormsApp1
{
    public static class DatabaseHelper
    {
        public static string ConnectionString = @"Server=.\SQLEXPRESS;Database=Restaurant;Trusted_Connection=True;TrustServerCertificate=True;";
    }
}