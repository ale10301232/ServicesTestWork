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

        /*RED200220211155*/
        /*Кнопка добавить*/
        private void button1_Click(object sender, EventArgs e)
        {
            string nameEngine = textBox1.Text;
            int engineId = comboBox1.SelectedIndex;
            /*RED210220211335*/
            if (nameEngine != "" && comboBox1.SelectedIndex != -1)
            {
                dBEntryHelper.addEntryServise(nameEngine, ++engineId);
                MessageBox.Show("Запись добавлена");
            }
            else
            {
                MessageBox.Show("Имя услуги и тип двигателя не может быть пустым");
            }
            
            textBox1.Text = "";

        }

        /*RED200220211151*/
        /*Кнопка закрыть*/
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}