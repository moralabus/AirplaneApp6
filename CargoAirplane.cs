using System;

namespace AirplaneApp6
{
    public class CargoAirplane : Airplane
    {
        public int CargoCapacity { get; set; }
        public string CargoType { get; set; }

        // Конструктор для CargoAirplane
        public CargoAirplane(string name, string model, int range, decimal fuelConsumption, DateTime manufactureDate, string foto, int cargoCapacity, string cargoType)
            : base(name, model, range, fuelConsumption, manufactureDate, foto)
        {
            CargoCapacity = cargoCapacity;
            CargoType = cargoType;
        }

        // Переопределение метода для получения информации
        public override string GetInfo()
        {
            return base.GetInfo() + $", Грузоподъемность: {CargoCapacity}, Тип груза: {CargoType}";
        }
    }
}
