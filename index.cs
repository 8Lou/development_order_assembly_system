using System;
using MySql.Data.MySqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "server=localhost;database=заказы;uid=пользователь;pwd=пароль;";
        
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string название = "Запчасть1";
            string тип = "запчасти";

            string query = $"INSERT INTO Номенклатура (название, тип) VALUES ('{название}', '{тип}')";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Новая номенклатура успешно добавлена");
                }
                else
                {
                    Console.WriteLine("Ошибка при добавлении номенклатуры");
                }
            }
        }
    }
}
