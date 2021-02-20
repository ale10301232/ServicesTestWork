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
    /*RED200220211152*/
    /*Форма добавление услуги*/
    public partial class Form2 : Form
    {
        private DBEntryHelper dBEntryHelper = new DBEntryHelper();
        public Form2()
        {
            InitializeComponent();
            List<String> entries = new List<string>(); //
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                /*Открываем подключение*/
                Connect.Open();
                string commandQuery = "SELECT * FROM [engine]";
                SQLiteCommand sqlCommand = new SQLiteCommand(commandQuery, Connect);
                SQLiteDataReader query = sqlCommand.ExecuteReader();

                while (query.Read())
                {
                    entries.Add(query.GetString(0));
                }
                Connect.Close();
                comboBox1.Items.Add(entries);
            }
        }

        /*RED200220211155*/
        /*Кнопка добавить*/
        private void button1_Click(object sender, EventArgs e)
        {
            
            string nameEngine = textBox1.Text;
            int engineId = comboBox1.SelectedIndex;
            dBEntryHelper.addEntryServise(nameEngine, ++engineId);
        }

        /*RED200220211151*/
        /*Кнопка закрыть*/
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}