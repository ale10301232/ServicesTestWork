using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesTestWork
{
    /*
     * Задача PowerLine
     */
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        /*Кнопка Рассчитать*/
        private void button1_Click(object sender, EventArgs e)
        {
            int selectedItemCarType = comboBox1.SelectedIndex; //  Выбранный Тип автомобиля

            if (textBox1.Text != "" &&
                textBox4.Text != "" &&
                textBox2.Text != "" &&
                selectedItemCarType > -1
            )
            {
                double fuelTankVal = Convert.ToDouble(textBox1.Text); // Объём топлива
                double fuelConsumption = Convert.ToDouble(textBox4.Text); // Средний расход топлива
                double speedAuto = Convert.ToDouble(textBox2.Text); // Скорость автомобиля
                Cars cars = new Cars(fuelTankVal, speedAuto, fuelConsumption);
                string resultMain = Math.Round(cars.GetRoadValue()).ToString();
                label6.Text = ("Осталось проехать без учёта груза и пассажиров:" + resultMain + " км.");
                string resultMainFuel = Math.Round(cars.GetRoadTimeValue(Convert.ToInt32(resultMain))).ToString();
                label6.Text = (label6.Text + "\n" + "При скорости " + speedAuto + "км/ч будет затрачено времени: " +
                    resultMainFuel + " ч. на поездку без учёта груза и пассажиров");

                /*Выбран легковой автомобиль*/
                if (selectedItemCarType == 0)
                {
                    if (comboBox2.SelectedIndex > -1)
                    {
                        int passengers = Convert.ToInt32(comboBox2.SelectedIndex + 1); // Пассажиры
                        PassengerCar passengerCar = new PassengerCar(fuelTankVal, speedAuto, fuelConsumption, passengers);
                        string result = Math.Round(passengerCar.GetRoadValueWPassengers()).ToString();
                        label6.Text = (label6.Text + "\n" + "Осталось проехать с учётом пассажиров:" + result + " км.");
                        string resultFuel = Math.Round(cars.GetRoadTimeValue(Convert.ToInt32(result))).ToString();
                        label6.Text = (label6.Text + "\n" + "При скорости " + speedAuto + "км/ч будет затрачено времени: " +
                            resultFuel + " ч. на поездку с учётом пассажиров");
                    }
                    else
                    {
                        MessageBox.Show("Выберите количество пассажиров");
                    }
                }

                /*Выбран грузовой автомобиль*/
                if (selectedItemCarType == 1)
                {
                    if (textBox3.Text != "")
                    {
                        int loadCapacityAuto = Convert.ToInt32(textBox3.Text); // Грузоподъёмность
                        AutoTruck autoTruck = new AutoTruck(fuelTankVal, speedAuto, fuelConsumption, loadCapacityAuto);
                        string result = Math.Round(autoTruck.GetRoadValueWLoadCapacityAuto()).ToString();
                        label6.Text = (label6.Text + "\n" + "Осталось проехать с учётом груза:" + result + " км.");
                        string resultFuel = Math.Round(cars.GetRoadTimeValue(Convert.ToInt32(result))).ToString();
                        label6.Text = (label6.Text + "\n" + "При скорости " + speedAuto + 
                            "км/ч будет затрачено времени: " +
                            resultFuel + " ч. на поездку с учётом груза");
                    }
                    else
                    {
                        MessageBox.Show("Заполните текущюю грузоподъёмность автомобиля");
                    }
                }
            }
            else
            {
                MessageBox.Show("Все основные поля должны быть заполнены(Тип, Объём топлива, " +
                    "Средний расход топлива, Скорость автомобиля)");
            }
        }
        /*Скрытие полей*/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = "";
            //Легковой автомобиль
            if (comboBox1.SelectedIndex == 0)
            {
                label5.Visible = true;
                comboBox2.Visible = true;
            }
            else
            {
                label5.Visible = false;
                comboBox2.Visible = false;
            }
            //Грузовой автомобиль
            if (comboBox1.SelectedIndex == 1)
            {
                label4.Visible = true;
                textBox3.Visible = true;
            }
            else
            {
                label4.Visible = false;
                textBox3.Visible = false;
            }
        }
        /* Валидация вводимых данных*/
        public bool ValidateKeyPress(char key)
        {
            if (!Char.IsDigit(key) && key != 8 && key != 44) // цифры, BackSpace и запятая
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*Назначаем валидацию на текстовые поля*/
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidateKeyPress(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidateKeyPress(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidateKeyPress(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = ValidateKeyPress(e.KeyChar);
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
