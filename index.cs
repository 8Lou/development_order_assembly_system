using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString = "server=localhost;database=заказы;uid=пользователь;pwd=пароль;";

    static void ДобавитьНоменклатуру(string название, string тип)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO Номенклатура (название, тип) VALUES ('{название}', '{тип}')";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Новая номенклатура успешно добавлена");
            }
        }
    }

    static void ДобавитьТочкуПроизводства(int id, string набор_номенклатуры, DateTime срок_производства)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO Точка_производства (id, набор_номенклатуры, срок_производства) VALUES ({id}, '{набор_номенклатуры}', '{срок_производства.ToString("yyyy-MM-dd")}')";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Новая точка производства успешно добавлена");
            }
        }
    }

    static void ДобавитьЗаказ(int id, int номер, DateTime дата, int точка_производства_id, int номенклатура_id, string статус)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"INSERT INTO Заказы (id, номер, дата, точка_производства_id, номенклатура_id, статус) " +
                           $"VALUES ({id}, {номер}, '{дата.ToString("yyyy-MM-dd")}', {точка_производства_id}, {номенклатура_id}, '{статус}')";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Новый заказ успешно добавлен");
            }
        }
    }

    static void ОтменитьЗаказ(int заказ_id)
    {
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            string query = $"DELETE FROM Заказы WHERE id = {заказ_id}";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Заказ успешно отменен");
            }
        }
    }

    static void Main()
    {
        ДобавитьНоменклатуру("Запчасть1", "запчасти");
        ДобавитьНоменклатуру("Комплект1", "комплекты");
        
        ДобавитьТочкуПроизводства(1, "Запчасть1, Комплект1", DateTime.Now.AddDays(7));

        ДобавитьЗаказ(1, 1001, DateTime.Now, 1, 1, "активный");

        ОтменитьЗаказ(1);
    }
}
