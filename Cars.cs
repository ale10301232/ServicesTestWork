using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesTestWork
{
    /*
     * Задача PowerLine
     * fuelTankVal -- Объём топлива/остаток
     * speedAuto -- Скорость авто
     * fuelConsumption -- Средний расход топлива
     * loadCapacityAuto -- Грузоподъёмность
     * passengers -- Число пассажиров
     * GetRoadValue() -- Метод подсчёта расстояния(общий для всех)
     * GetRoadTimeValue() -- Метод для подсчёта времени на поездку(общий для всех на основе полученного roadValue)
     * GetRoadValueWPassengers() -- Метод подсчёта расстояния с учётом пассажиров
     * GetRoadValueWLoadCapacityAuto() -- Метод подсчёта расстояния с учётом груза
     */
    class Cars
    {
        public double SpeedAuto { get; set; }
        public double FuelTankVal  { get; set; }
        public double FuelConsumption { get; set; }
        public string TypeAuto { get; set; }
        public Cars(double fuelTankVal, double speedAuto, double fuelConsumption)
        {
            FuelTankVal = fuelTankVal;
            SpeedAuto = speedAuto;
            FuelConsumption = fuelConsumption;
        }
        /*Подсчёт расстояния*/
        /*RED300720220000*/
        public double GetRoadValue()
        {
            double roadResult;
            roadResult = (FuelTankVal / FuelConsumption) * 100;
            //Исключение отрицательного значения
            if (roadResult < 0)
            {
                roadResult = 0;
            }
            return roadResult;
        }
        /*Подсчёт времени на поездку*/
        /*RED300720220000*/
        public double GetRoadTimeValue(int roadValue)
        {
            double fuelResult;
            fuelResult = roadValue / SpeedAuto;
            return fuelResult;
        }

    }
    class PassengerCar : Cars 
    { 
        public int Passengers { get; set; }
        public PassengerCar(double fuelTankVal, double speedAuto, double fuelConsumption, int passengers) 
            : base(fuelTankVal, speedAuto, fuelConsumption)
        {
            Passengers = passengers;

        }
        /*Подсчёт расстояния (с пассажирами)*/
        /*RED300720220000*/
        public double GetRoadValueWPassengers()
        {
            double roadResult, roadResultPassengers;
            roadResult = GetRoadValue();
            roadResultPassengers = roadResult - (roadResult / 100 * (Passengers * 6));
            //Исключение отрицательного значения
            if (roadResultPassengers < 0)
            {
                roadResultPassengers = 0;
            }
            return roadResultPassengers;
        }

    }
    class SportCar : Cars
    {
        public int Passengers { get; set; }
        public SportCar(double fuelTankVal, double speedAuto, double fuelConsumption)
            : base(fuelTankVal, speedAuto, fuelConsumption)
        {

        }


    }
    class AutoTruck : Cars
    {
        public int LoadCapacityAuto { get; set; }
        public AutoTruck(double fuelTankVal, double speedAuto, double fuelConsumption, int loadCapacityAuto)
            : base(fuelTankVal, speedAuto, fuelConsumption)
        {
            LoadCapacityAuto = loadCapacityAuto;

        }
        /*Подсчёт расстояния(с грузом)*/
        /*RED300720220000*/
        public double GetRoadValueWLoadCapacityAuto()
        {
            double roadResult, roadResultLoadCapacity;
            roadResult = GetRoadValue();
            roadResultLoadCapacity = roadResult - (roadResult / 100 * (LoadCapacityAuto / 200 * 4));
            //Исключение отрицательного значения
            if (roadResultLoadCapacity < 0)
            {
                roadResultLoadCapacity = 0;
            }
            return roadResultLoadCapacity;
        }

    }
}
