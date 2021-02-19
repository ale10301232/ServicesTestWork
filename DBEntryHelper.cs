using System;
using System.Data.SQLite;

namespace ServicesTestWork
{
    internal class DBEntryHelper
    {
        /*RED190220211329*/
        /* 
         * commandQuery - переменная для хранение записи запроса
         * sqlCommand - экземпляр --> передача commandQuery в методе ExecuteNonQuery
         * Connect - строка подключения к БД
         */
        /*RED180220211700*/
        /* Удаление записи*/
        public void deleteEntry(string id)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "DELETE FROM [orders] WHERE [id] = @id";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
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
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@name", typeEngine);
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
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
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@model", carId);
                sqlCommand.Parameters.AddWithValue("@brand", serviceId);
                sqlCommand.Parameters.AddWithValue("@gosNumber", engineId);
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
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
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@model", model);
                sqlCommand.Parameters.AddWithValue("@brand", brand);
                sqlCommand.Parameters.AddWithValue("@gosNumber", gosNumber);
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
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
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@name", nameService);
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
        /*RED180220211714*/
        /* Редактирование записи "Заказ"*/
        public void editOrder()
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "UPDATE [orders] SET [file_name] = @value WHERE [id] = @id";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@value", "Новое имя файла");
                sqlCommand.Parameters.AddWithValue("@id", 1);
                Connect.Open();
                sqlCommand.ExecuteNonQuery();

                Connect.Close();
            }

        }

    }
}