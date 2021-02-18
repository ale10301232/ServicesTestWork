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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\TestDB.db; Version=3;"))
            {

            }
        }
        /*RED180220211624*/
        /*Удаить запись из БД*/
        private void button3_Click(object sender, EventArgs e)
        {
            DBEntryHelper dBEntryHelper = new DBEntryHelper();
            string valueEntry = "0";
            dBEntryHelper.deleteEntry(valueEntry);
        }

        /*RED180220211750*/
        /*Добавить запись в БД(Добавить заказ)*/
        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
