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
            refreshGrid();

        }

        /*RED220220210240*/
        /*Для обновления данных в dataGridView1*/
        private void refreshGrid()
        {
            using (SQLiteConnection Connect = new SQLiteConnection(@"Data Source=.\carsOrders.db; Version=3;"))
            {
                string commandQuery = "SELECT orders.id AS 'Заказ', " +
                    "[model] AS 'Модель', " +
                    "[brand] AS 'Марка', " +
                    "[name_engine] AS 'Тип двигателя', " +
                    "[service_name] AS 'Услуга' " +
                    "FROM [cars], [engine], [services], [orders] " +
                    "WHERE [cars].[id] = [orders].[car_id] " +
                    "AND [engine].[id] = [orders].[engine_id] " +
                    "AND [services].[id] = [orders].[service_id]";
                /*Открываем подключение и выводим результат в dataGridView1*/
                Connect.Open();
                DataSet dataSet = new DataSet();
                SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(commandQuery, Connect);
                dataAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0].DefaultView;
                Connect.Close();

            }
        }
        /*RED180220211750*/
        /*Кнопка добавить запись в БД(Добавить заказ)*/
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        /*RED190220211611*/
        /*Кнопка редактировать запись*/
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string valueEntry = Convert.ToString(selectedRow.Cells["Заказ"].Value);
            List<String> listIds = dBEntryHelper.selectEntryOrder(Convert.ToInt32(valueEntry));
            form4.showFormFields(listIds);

                 
            form4.Show();
        }

        /*RED180220211624*/
        /*Кнопка удалить запись из БД*/
        private void button3_Click(object sender, EventArgs e)
        {
            /*RED210220211815*/
            /*Выбрть id из выделенной строки*/
            int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
            string valueEntry = Convert.ToString(selectedRow.Cells["Заказ"].Value);
            dBEntryHelper.deleteEntry( Convert.ToInt32(valueEntry));
            /*RED210220211900*/
            /*Class refreshData --> 2d+*/
            /*Copy from r22*/
            /*Обновляем данные*/
            refreshGrid();

        }

        /*RED210220211830*/
        /*Кнопка добавить услугу*/
        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        /*RED220220210255*/
        /*Кнопка обновить данные*/
        private void button5_Click(object sender, EventArgs e)
        {
            refreshGrid();
        }
    }
}
