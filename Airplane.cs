using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

namespace AirplaneApp6
{
    public class Airplane
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public int Range { get; set; }
        public decimal FuelConsumption { get; set; }
        public DateTime ManufactureDate { get; set; }
        public string Foto { get; set; }

        // Статическое свойство для цвета фона
        public static Color BackColor
        {
            get
            {
                int currentDay = DateTime.Now.DayOfWeek.GetHashCode();
                return (currentDay % 2 == 1) ? Color.LightPink : Color.LightBlue;
            }
        }

        // Основной конструктор
        public Airplane(string name, string model, int range, decimal fuelConsumption, DateTime manufactureDate, string foto)
        {
            Name = name;
            Model = model;
            Range = range;
            FuelConsumption = fuelConsumption;
            ManufactureDate = manufactureDate;
            Foto = foto;
        }

        // Виртуальный метод для получения информации о самолете
        public virtual string GetInfo()
        {
            return $"Самолет: {Name}, Модель: {Model}, Дальность полета: {Range} км, Потребление горючего: {FuelConsumption} л/100км, Дата производства: {ManufactureDate.ToShortDateString()}";
        }

        // Нестатический метод записи в файл
        public virtual void WriteToFile(List<Airplane> airplanes, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Airplane airplane in airplanes)
                {
                    writer.WriteLine($"{airplane.Name},{airplane.Model},{airplane.Range},{airplane.FuelConsumption},{airplane.ManufactureDate.ToShortDateString()},{airplane.Foto}");
                }
            }
        }

        // Статический метод для чтения данных о самолетах из файла
        public static List<Airplane> ReadFromFile(string filePath)
        {
            List<Airplane> airplanes = new List<Airplane>();
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 6)
                    {
                        airplanes.Add(new Airplane(
                            parts[0].Trim(),
                            parts[1].Trim(),
                            int.Parse(parts[2]),
                            decimal.Parse(parts[3]),
                            DateTime.Parse(parts[4]),
                            parts[5].Trim()));
                    }
                }
            }
            return airplanes;
        }
    }
}
