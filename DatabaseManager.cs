using System;
using System.Data;
using System.Data.SqlClient;

namespace OrderAssemblySystem
{
    public class DatabaseManager
    {
        private string connectionString = "Your Connection String Here";

        public DataTable LoadInventoryData()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Inventory";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                connection.Open();
                adapter.Fill(dataTable);
            }

            return dataTable;
        }

        public void AddOrderItem(string nomenclatureName, int quantity)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO OrderItems (NomenclatureName, Quantity) VALUES (@NomenclatureName, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@NomenclatureName", nomenclatureName);
                command.Parameters.AddWithValue("@Quantity", quantity);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
