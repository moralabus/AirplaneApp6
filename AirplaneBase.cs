using System.Collections.Generic;
using System.IO;

namespace AirplaneApp6
{
    public class AirplaneBase
    {

        // Статический метод для записи данных о самолетах в текстовый файл
        public sealed void WriteToFile(List<Airplane> airplanes, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Airplane airplane in airplanes)
                {
                    // Запись данных самолета в файл, разделенных запятыми
                    writer.WriteLine($"{airplane.Name},{airplane.Model},{airplane.Range},{airplane.FuelConsumption},{airplane.ManufactureDate.ToShortDateString()},{airplane.Foto}");
                }
            }
        }
    }
}