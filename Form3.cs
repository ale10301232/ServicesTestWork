using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesTestWork
{
    /*RED210220212306*/
    /*Форма добавление новой записи в заказы*/
    public partial class Form3 : Form
    {
        DBEntryHelper dBEntryHelper = new DBEntryHelper();
        public Form3()
        {
            InitializeComponent();
            List<String> entries = new List<string>();
            entries.Clear();
            comboBox1.Items.Clear();
            /*RED200220212352*/
            /*Предзагрузка элементов из таблицы engine в comboBox1*/
            string commandQuery = "SELECT id, name_engine FROM [engine]";
            entries = dBEntryHelper.selectRowEngine(commandQuery);

            foreach (var item in entries)
            {
                comboBox1.Items.Add(item);
            }

        }
        /*RED210220212303*/
        /*comboBox1 - смена типа двигателя, заполнение comboBox2 услугами*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<String> entries = new List<string>();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                /*RED200220212352*/
                entries.Clear();
                comboBox2.Items.Clear();
                string commandQuery = "SELECT service_name, engine_id FROM [services] WHERE engine_id = " + (Convert.ToInt32(comboBox1.SelectedIndex + 1));
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                Connect.Open();
                SQLiteDataReader query = sqlCommand.ExecuteReader();
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        entries.Add(query["service_name"].ToString());
                    }
                }
                Connect.Close();
                foreach (var item in entries)
                {
                    comboBox2.Items.Add(item);
                }

            }
        }

        private void comboBox1_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        /*RED210220212303*/
        /*Кнопка записать*/
        private void button1_Click(object sender, EventArgs e)
        {
            
            string modelCar = textBox1.Text; // Модель автомобиля
            string brandCar = textBox2.Text; // Марка автомобиля
            string gosNumber = textBox3.Text; // Гос.номер автомобиля
            int engineId = Convert.ToInt32(comboBox1.SelectedIndex + 1); // тип двигателя
            int serviceId = Convert.ToInt32(comboBox2.SelectedIndex + 1); // услуга
            if (modelCar != "" &&
                brandCar != "" &&
                gosNumber != "" &&
                engineId != 0 &&
                serviceId != 0
                )
            {
                dBEntryHelper.addEntryCars(modelCar, brandCar, gosNumber);
                string carId = dBEntryHelper.selectRow("SELECT Id FROM cars ORDER BY Id DESC LIMIT 1"); // ...
                dBEntryHelper.addEntryOrder(Convert.ToInt32(carId), serviceId, engineId);
                MessageBox.Show("Запись добавлена");
                this.Close();
            }
            else
            {
                MessageBox.Show("Все поля должны быть заполнены");
            }
            
        }

        /*RED220220210300*/
        /*Кнопка отменить*/
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
