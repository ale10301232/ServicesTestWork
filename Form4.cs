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
    /*RED220220210216*/
    /*Форма редактирование записи в заказы*/
    public partial class Form4 : Form
    {
        DBEntryHelper dBEntryHelper = new DBEntryHelper();
        public Form4()
        {
            InitializeComponent();

        }
        int currentIdCar = 0;
        int currentOdOrder = 0;
        public void showFormFields(List<String> idFields)
        {
            int carIdField = Convert.ToInt32(idFields[0]);
            this.currentIdCar = Convert.ToInt32(idFields[0]);
            this.currentOdOrder = Convert.ToInt32(idFields[3]);
            List<String> entriesEngine = new List<string>();
            /*RED200220212352*/
            entriesEngine.Clear();
            comboBox1.Items.Clear();
            entriesEngine = dBEntryHelper.selectRowEngine("SELECT id, name_engine FROM [engine]");

            foreach (var item in entriesEngine)
            {
                comboBox1.Items.Add(item);
            }

            List<String> entriesSelectOrder = new List<string>();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "SELECT id, " +
                    "[model], " +
                    "[brand], " +
                    "[gos_number] " +
                    "FROM [cars] " +
                    "WHERE [id] = " + carIdField;
                /*Открываем подключение и выводим результат в dataGridView1*/
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                /*Открываем подключение и считываем результат commandQuery*/
                Connect.Open();
                SQLiteDataReader query = sqlCommand.ExecuteReader();
                /*Добавляем результат в список entries*/
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        entriesSelectOrder.Add(query["model"].ToString());
                        entriesSelectOrder.Add(query["brand"].ToString());
                        entriesSelectOrder.Add(query["gos_number"].ToString());
                    }
                }
                Connect.Close();
                textBox1.Text = entriesSelectOrder[0];
                textBox2.Text = entriesSelectOrder[1];
                textBox3.Text = entriesSelectOrder[2];
            


            }

        }
        /*RED220220210155*/
        /*Кнопка записать*/
        private void button1_Click(object sender, EventArgs e)
        {
            int engineId = Convert.ToInt32(comboBox1.SelectedIndex + 1);
            int serviceId = Convert.ToInt32(comboBox2.SelectedIndex + 1);
            dBEntryHelper.editCar(textBox1.Text, textBox2.Text, textBox3.Text, currentIdCar);
            dBEntryHelper.editEntryOrder(currentIdCar, engineId, serviceId, currentOdOrder);
            this.Close();
        }
        /*RED220220210150*/
        /*comboBox1 - смена типа двигателя, заполнение comboBox2 услугами*/
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            List<String> entriesService = new List<string>();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                /*RED200220212352*/
                entriesService.Clear();
                comboBox2.Items.Clear();
                string commandQuery = "SELECT service_name, engine_id FROM [services] WHERE engine_id = " + (Convert.ToInt32(comboBox1.SelectedIndex + 1));
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                Connect.Open();
                SQLiteDataReader query = sqlCommand.ExecuteReader();
                if (query.HasRows)
                {
                    while (query.Read())
                    {
                        entriesService.Add(query["service_name"].ToString());
                    }
                }
                Connect.Close();
                foreach (var item in entriesService)
                {
                    comboBox2.Items.Add(item);
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
