using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Program.Connection
{
    internal class Connect
    {
        private readonly string _connectionString = "Data Source=Localhost;Initial Catalog=master;User ID=sa;Password=sqladmin";
        private readonly string _connectionStringCompany = "Data Source=Localhost;Initial Catalog=Warehouse;User ID=sa;Password=sqladmin";

        public bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionStringCompany))
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                LogError(ex);
                return false;
            }
        }

        public void OpenConnection()
        {
            try
            {
                using (var conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected successfully.");
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void CreateDatabase(string database)
        {
            try
            {
                string sql = File.ReadAllText("..\\..\\Quary\\ReCreateDatabase.sql");
                sql = sql.Replace("Company", database);

                using (var conn = new SqlConnection(_connectionString))
                using (var command = new SqlCommand(sql, conn))
                {
                    if (MessageBox.Show("سوف يتم إنشاء قاعدة البيانات؟", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Database created successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void CreateTables(string sql, string year)
        {
            try
            {
                string dbConnectionString = _connectionString.Replace("master", "Company" + year);
                sql = sql.Replace("Company", "Company" + year);

                using (var conn = new SqlConnection(dbConnectionString))
                using (var command = new SqlCommand(sql, conn))
                {
                    if (MessageBox.Show("سوف يتم إنشاء جداول البرنامج", "رسالة تأكيد", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Tables created successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        public void ResetTable()
        {
            string sql =
                "DBCC CHECKIDENT('material_credit', RESEED, 0); " +
                "DBCC CHECKIDENT('material_credit_return', RESEED, 0); " +
                "DBCC CHECKIDENT('material_debit', RESEED, 0); " +
                "DBCC CHECKIDENT('material_debit_return', RESEED, 0); ";

            ExecuteNonQuery(sql, _connectionStringCompany, "تمت العملية بنجاح");
        }

        public void Backup(string file, int num)
        {
            string sql = $"BACKUP DATABASE [Company] TO DISK = N'{file}\\Company.bak' WITH RETAINDAYS = {num}, NOFORMAT, NOINIT, NAME = N'Company-Full Database Backup', SKIP, NOREWIND, NOUNLOAD, STATS = 10";

            ExecuteNonQuery(sql, _connectionStringCompany, "تمت العملية بنجاح");
        }

        public void RestoreDatabase(string file)
        {
            string sql = $"RESTORE DATABASE [Company] FROM DISK = N'{file}' WITH FILE = 1, NOUNLOAD, REPLACE, STATS = 10";

            ExecuteNonQuery(sql, _connectionString, "تمت العملية بنجاح");
        }

        private void ExecuteNonQuery(string sql, string connectionString, string successMessage)
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                using (var command = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show(successMessage, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void ShowError(Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void LogError(Exception ex)
        {
            // Implement your logging here, for example, logging to a file or an event log.
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
