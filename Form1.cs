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
    /*RED200220211158*/
    /*Форма Заказы*/
    public partial class Form1 : Form
    {
        private DBEntryHelper dBEntryHelper = new DBEntryHelper();
        public Form1()
        {
            InitializeComponent();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {

            }
        }
        /*RED180220211750*/
        /*Добавить запись в БД(Добавить заказ)*/
        private void button1_Click(object sender, EventArgs e)
        {

        }
        /*RED190220211611*/
        /*Редактировать запись*/
        private void button2_Click(object sender, EventArgs e)
        {

        }
        /*RED180220211624*/
        /*Удалить запись из БД*/
        private void button3_Click(object sender, EventArgs e)
        {
            string valueEntry = "0";
            dBEntryHelper.deleteEntry(valueEntry);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
