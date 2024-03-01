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

                               try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при загрузке данных из базы данных: " + ex.Message);
                }

                //connection.Open();
                //adapter.Fill(dataTable);
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

                //connection.Open();
                //command.ExecuteNonQuery();
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при добавлении номенклатуры в заказ: " + ex.Message);
                }
            }
        }
    }
}
