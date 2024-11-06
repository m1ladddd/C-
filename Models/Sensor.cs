using System;
using System.Collections.Generic;

namespace TemperatureMonitoring.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public List<Measurement> LastMeasurements { get; set; } = new List<Measurement>();
        public Aggregations Aggregations { get; set; }
        public DateTime LastMeasurementTimestamp { get; set; }

        private static readonly Random _random = new Random();

        // Virtual UpdateData-methode zodat hij overschreven kan worden door subclasses zoals RetrySensor
        public virtual void UpdateData()
        {
            // Genereer een willekeurige temperatuur en luchtvochtigheid
            double temperature = Math.Round(15.0 + _random.NextDouble() * 10.0, 2); // 15°C - 25°C
            double humidity = Math.Round(30.0 + _random.NextDouble() * 40.0, 2); // 30% - 70%

            // Voeg de nieuwe metingen toe aan LastMeasurements
            LastMeasurements.Add(new Measurement
            {
                Type = "Temperature",
                Value = temperature,
                Unit = "Celsius",
                Timestamp = DateTime.UtcNow
            });
            LastMeasurements.Add(new Measurement
            {
                Type = "Humidity",
                Value = humidity,
                Unit = "Percent",
                Timestamp = DateTime.UtcNow
            });

            // Update de aggregatiewaarden voor de dag
            Aggregations = Aggregations ?? new Aggregations();
            Aggregations.Temperature = new MinMax
            {
                MaxToday = Math.Max(Aggregations.Temperature?.MaxToday ?? temperature, temperature),
                MinToday = Math.Min(Aggregations.Temperature?.MinToday ?? temperature, temperature),
                Unit = "Celsius"
            };
            Aggregations.Humidity = new MinMax
            {
                MaxToday = Math.Max(Aggregations.Humidity?.MaxToday ?? humidity, humidity),
                MinToday = Math.Min(Aggregations.Humidity?.MinToday ?? humidity, humidity),
                Unit = "Percent"
            };

            // Update de tijd van de laatste meting
            LastMeasurementTimestamp = DateTime.UtcNow;

            Console.WriteLine($"Updated data for sensor: {Name}. Temperature: {temperature}°C, Humidity: {humidity}%");
        }
    }

    public class Measurement
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Aggregations
    {
        public MinMax Temperature { get; set; }
        public MinMax Humidity { get; set; }
    }

    public class MinMax
    {
        public double MaxToday { get; set; }
        public double MinToday { get; set; }
        public string Unit { get; set; }
    }
}
