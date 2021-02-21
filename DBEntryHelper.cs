using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace ServicesTestWork
{
    internal class DBEntryHelper
    {
        /*RED190220211329*/
        /* 
         * commandQuery - переменная для хранения запроса
         * sqlCommand - экземпляр --> передача commandQuery в методе ExecuteNonQuery
         * Connect - строка подключения к БД
         */
        /*RED220220210110*/
        /* Select записи по строке sqlSelect возвращает Id*/
        public List<String> selectRowEngine(string sqlSelect)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                List<String> entries = new List<string>();
                string commandQuery = sqlSelect;
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                /*Открываем подключение и считываем результат commandQuery*/
                Connect.Open();
                SQLiteDataReader query = sqlCommand.ExecuteReader();
                /*Добавляем результат в список entries*/
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        entries.Add(query["name_engine"].ToString());
                    }
                }
                Connect.Close();
                return entries;
            }

        }

        /*RED210220212330*/
        /* Select записи по строке sqlSelect возвращает Id*/
        public string selectRow(string sqlSelect)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string result = "";
                string commandQuery = sqlSelect;
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                /*Открываем подключение и считываем результат commandQuery*/
                Connect.Open();
                SQLiteDataReader query = sqlCommand.ExecuteReader();
                /*Добавляем результат в список entries*/
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        result = query["id"].ToString();
                    }
                }
                Connect.Close();
                return result;
            }
            
        }

        /*RED180220211700*/
        /* Удаление записи*/
        public void deleteEntry(int id)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "DELETE FROM [orders] WHERE [id] = @id";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@id", id);
                /*Открываем подключение*/
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
                /*Открываем подключение*/
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
                string commandQuery = "INSERT INTO [orders] ([car_id], [engine_id], [service_id]) VALUES (@carId, @sarviceId, @engineId)";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@carId", carId);
                sqlCommand.Parameters.AddWithValue("@sarviceId", serviceId);
                sqlCommand.Parameters.AddWithValue("@engineId", engineId);
                /*Открываем подключение*/
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
                
                /*Открываем подключение*/
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }

        /*RED180220211710*/
        /* Добавление записи "Услуга"*/
        public void addEntryServise(string nameService, int engineId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "INSERT INTO [services] ([service_name],[engine_id]) VALUES (@name, @engine)";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@name", nameService);
                sqlCommand.Parameters.AddWithValue("@engine", engineId);
                /*Открываем подключение*/
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }

        /*RED180220211714*/
        /* Редактирование таблицы Cars*/
        public void editCar(string brandName, string modelName, string gosNum, int carId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "UPDATE [cars] SET [brand] = @brand, [model] = @model, [gos_number] = @gosNumber WHERE [id] = @idCar";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);

                /*RED190220212030*/
                sqlCommand.Parameters.AddWithValue("@brand", brandName);
                sqlCommand.Parameters.AddWithValue("@model", modelName);
                sqlCommand.Parameters.AddWithValue("@gosNumber", gosNum);
                sqlCommand.Parameters.AddWithValue("@idCar", carId);
                /*Открываем подключение*/
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }

        }

        /*RED200220210949*/
        /*NOTUSE*/
        /* Редактирование таблицы Двигатели*/
        public void editEngine(string engineName, int engineId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "UPDATE[engine] SET [name_engine] = @engine WHERE [id] = @idEngine";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);

                /*RED190220212031*/
                sqlCommand.Parameters.AddWithValue("@engine", engineName);
                sqlCommand.Parameters.AddWithValue("@idEngine", engineId);
                /*Открываем подключение*/
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }

        }

        /*RED200220210950*/
        /*NOTUSE*/
        /* Редактирование таблицы Услуги*/
        public void editService(string serviceName, int serviceId, int engineId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "UPDATE [services] SET [service_name] = @service, [engine_id] = @idEngine WHERE [id] = @idService";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);

                /*RED190220212032*/
                sqlCommand.Parameters.AddWithValue("@service", serviceName);
                sqlCommand.Parameters.AddWithValue("@idService", serviceId);
                sqlCommand.Parameters.AddWithValue("@idEngine", engineId);
                /*Открываем подключение*/
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }
        }
     
        /*RED220220210250*/
        /*Select Заказов --> возврае списка с объектанми Orders*/
        public List<String> selectEntryOrder(int orderId)
        {
            List<String> entries = new List<string>();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                entries.Clear();
                /*RED200220212352*/
                /*Предзагрузка элементов из таблицы engine в comboBox1*/
                string commandQuery = "SELECT * FROM [orders] WHERE id = " + orderId;
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                /*Открываем подключение и считываем результат commandQuery*/
                Connect.Open();
                SQLiteDataReader query = sqlCommand.ExecuteReader();
                /*Добавляем результат в список entries*/
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        entries.Add(query["car_id"].ToString());
                        entries.Add(query["engine_id"].ToString());
                        entries.Add(query["service_id"].ToString());
                        entries.Add(query["id"].ToString());
                    }
                    
                }
                Connect.Close();
                return entries;

            }
        }

        /*RED220220210250*/
        /* Редактирование таблицы Orders*/
        public void editEntryOrder(int carId, int engineId, int serviceId, int orderId)
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "UPDATE [orders] SET [car_id] = @carId, [engine_id] = @engineId, [service_id] = @serviceId WHERE [id] = @orderId";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                sqlCommand.Parameters.AddWithValue("@carId", carId);
                sqlCommand.Parameters.AddWithValue("@engineId", engineId);
                sqlCommand.Parameters.AddWithValue("@serviceId", serviceId);
                sqlCommand.Parameters.AddWithValue("@orderId", orderId);
                /*Открываем подключение*/
                Connect.Open();
                sqlCommand.ExecuteNonQuery();
                Connect.Close();
            }

        }
    }
}