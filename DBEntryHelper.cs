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
        public void editOrder
            (
            string brandName,
            string modelName,
            string gosNum,
            int carId,
            string engineName,
            int engineId,
            string serviceName,
            int serviceId
            )
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = 
                    "UPDATE [cars] SET " +
                    "[brand] = @brand" +
                    "[model] = @model" +
                    "[gos_number] = @gosNumber" +
                    " WHERE [id] = @idCar " +
                    "UPDATE[engine] SET " +
                    "[name_engine] = @engine" +
                    " WHERE [id] = @idEngine " +
                    "UPDATE[services] SET " +
                    "[service_name] = @service" +
                    " WHERE [id] = @idService ";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                /*RED190220212030*/
                /*Поля для таблицы cars*/
                sqlCommand.Parameters.AddWithValue("@brand", brandName);
                sqlCommand.Parameters.AddWithValue("@model", modelName);
                sqlCommand.Parameters.AddWithValue("@gos_number", gosNum);
                sqlCommand.Parameters.AddWithValue("@idCar", carId);
                /*RED190220212031*/
                /*Поля для таблицы engine --> поправить engines*/
                sqlCommand.Parameters.AddWithValue("@engine", engineName);
                sqlCommand.Parameters.AddWithValue("@idEngine", engineId);
                /*RED190220212032*/
                /*Поля для таблицы services*/
                sqlCommand.Parameters.AddWithValue("@service", serviceName);
                sqlCommand.Parameters.AddWithValue("@idService", serviceId);
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }

        }

    }
}