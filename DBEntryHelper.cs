using System;
using System.Data.SQLite;

namespace ServicesTestWork
{
    internal class DBEntryHelper
    {
        /*RED180220211700*/
        /* Удаление записи*/
        public void deleteEntry(string id)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "DELETE FROM [orders] WHERE [id] = @id";
                SQLiteCommand SqlCommand = new SQLiteCommand(commandQuery, Connect);
                SqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                Connect.Open();
                SqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
        /*RED180220211701*/
        /* Добавление записи "Тип двигателя"*/
        public void addEntryEngine(string typeEngine)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "INSERT INTO [engine] ([name_engine]) VALUES (@name)";
                SQLiteCommand SqlCommand = new SQLiteCommand(commandQuery, Connect);
                SqlCommand.Parameters.AddWithValue("@name", typeEngine);
                Connect.Open();
                SqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
        /*RED180220211704*/
        /* Добавление записи "Заказ"*/
        public void addEntryOrder(int carId, int serviceId, int engineId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "INSERT INTO [orders] ([car_id], [engine_id], [service_id]) VALUES (@carId, @engineId, @sarviceId)";
                SQLiteCommand SqlCommand = new SQLiteCommand(commandQuery, Connect);
                SqlCommand.Parameters.AddWithValue("@model", carId);
                SqlCommand.Parameters.AddWithValue("@brand", serviceId);
                SqlCommand.Parameters.AddWithValue("@gosNumber", engineId);
                Connect.Open();
                SqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
        /*RED180220211705*/
        /* Добавление записи "Автомобиль"*/
        public void addEntryCars(string model, string brand, string gosNumber)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "INSERT INTO [cars] ([model], [brand], [gos_number]) VALUES (@model, @brand, @gosNumber)";
                SQLiteCommand SqlCommand = new SQLiteCommand(commandQuery, Connect);
                SqlCommand.Parameters.AddWithValue("@model", model);
                SqlCommand.Parameters.AddWithValue("@brand", brand);
                SqlCommand.Parameters.AddWithValue("@gosNumber", gosNumber);
                Connect.Open();
                SqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
        /*RED180220211710*/
        /* Добавление записи "Услуга"*/
        public void addEntryServise(string nameService)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "INSERT INTO [services] ([service_name]) VALUES (@name)";
                SQLiteCommand SqlCommand = new SQLiteCommand(commandQuery, Connect);
                SqlCommand.Parameters.AddWithValue("@name", nameService);
                Connect.Open();
                SqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
        /*RED180220211714*/
        /* Редактирование записи "Заказ"*/
        public void editOrder()
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "UPDATE [dbTableName] SET [file_name] = @value WHERE [id] = @id";
                SQLiteCommand SqlCommand = new SQLiteCommand(commandQuery, Connect);
                SqlCommand.Parameters.AddWithValue("@value", "Новое имя файла");
                SqlCommand.Parameters.AddWithValue("@id", 1);
                Connect.Open();
                SqlCommand.ExecuteNonQuery();

                Connect.Close();
            }

        }

    }
}