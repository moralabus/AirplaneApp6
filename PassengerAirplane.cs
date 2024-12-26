using System;
using System.Collections.Generic;
using System.IO;

namespace AirplaneApp6
{
    public class PassengerAirplane : Airplane
    {
        public int PassengerCapacity { get; set; }
        public bool HasBusinessClass { get; set; }

        // Конструктор для PassengerAirplane
        public PassengerAirplane(string name, string model, int range, decimal fuelConsumption, DateTime manufactureDate, string foto, int passengerCapacity, bool hasBusinessClass)
            : base(name, model, range, fuelConsumption, manufactureDate, foto)
        {
            PassengerCapacity = passengerCapacity;
            HasBusinessClass = hasBusinessClass;
        }

        // Переопределение метода для получения информации
        public override string GetInfo()
        {
            return base.GetInfo() + $", Вместимость: {PassengerCapacity}, Бизнес-класс: {HasBusinessClass}";
        }

        // Переопределение метода записи в файл
        public override void WriteToFile(List<Airplane> airplanes, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (PassengerAirplane airplane in airplanes)
                {
                    writer.WriteLine($"Пассажирский {airplane.Name},{airplane.Model},{airplane.Range},{airplane.FuelConsumption},{airplane.ManufactureDate.ToShortDateString()},{airplane.Foto},{airplane.PassengerCapacity},{airplane.HasBusinessClass}");
                }
            }
        }
    }
}
