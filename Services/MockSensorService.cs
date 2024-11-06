using System;
using System.Collections.Generic;
using System.Threading;
using TemperatureMonitoring.Models; // Zorg ervoor dat je de Models namespace hebt toegevoegd

namespace TemperatureMonitoring.Services
{
    public class MockSensorService
    {
        // Methode om een lijst van mock sensoren terug te geven, inclusief RetrySensor
        public List<Sensor> GetMockSensors()
        {
            return new List<Sensor>
            {
                new RetrySensor
                {
                    Id = 1,
                    SerialNumber = "123456",
                    Name = "Sensor 1",
                    LastMeasurements = new List<Measurement>
                    {
                        new Measurement { Type = "Temperature", Value = 20.0, Unit = "Celsius", Timestamp = DateTime.UtcNow },
                        new Measurement { Type = "Humidity", Value = 45.0, Unit = "Percent", Timestamp = DateTime.UtcNow },
                    },
                    Aggregations = new Aggregations
                    {
                        Temperature = new MinMax { MaxToday = 25.5, MinToday = 18.3, Unit = "Celsius" },
                        Humidity = new MinMax { MaxToday = 50.0, MinToday = 30.0, Unit = "Percent" }
                    },
                    LastMeasurementTimestamp = DateTime.UtcNow
                },
                new Sensor
                {
                    Id = 2,
                    SerialNumber = "654321",
                    Name = "Sensor 2",
                    LastMeasurements = new List<Measurement>
                    {
                        new Measurement { Type = "Temperature", Value = 22.0, Unit = "Celsius", Timestamp = DateTime.UtcNow },
                        new Measurement { Type = "Humidity", Value = 40.0, Unit = "Percent", Timestamp = DateTime.UtcNow },
                    },
                    Aggregations = new Aggregations
                    {
                        Temperature = new MinMax { MaxToday = 27.0, MinToday = 19.0, Unit = "Celsius" },
                        Humidity = new MinMax { MaxToday = 55.0, MinToday = 35.0, Unit = "Percent" }
                    },
                    LastMeasurementTimestamp = DateTime.UtcNow
                },
                // New Sensor 3
                new RetrySensor
                {
                    Id = 3,
                    SerialNumber = "789456",
                    Name = "Sensor 3",
                    LastMeasurements = new List<Measurement>
                    {
                        new Measurement { Type = "Temperature", Value = 18.5, Unit = "Celsius", Timestamp = DateTime.UtcNow },
                        new Measurement { Type = "Humidity", Value = 55.0, Unit = "Percent", Timestamp = DateTime.UtcNow },
                    },
                    Aggregations = new Aggregations
                    {
                        Temperature = new MinMax { MaxToday = 24.5, MinToday = 16.3, Unit = "Celsius" },
                        Humidity = new MinMax { MaxToday = 60.0, MinToday = 35.0, Unit = "Percent" }
                    },
                    LastMeasurementTimestamp = DateTime.UtcNow
                },
                // New Sensor 4
                new Sensor
                {
                    Id = 4,
                    SerialNumber = "321654",
                    Name = "Sensor 4",
                    LastMeasurements = new List<Measurement>
                    {
                        new Measurement { Type = "Temperature", Value = 21.0, Unit = "Celsius", Timestamp = DateTime.UtcNow },
                        new Measurement { Type = "Humidity", Value = 50.0, Unit = "Percent", Timestamp = DateTime.UtcNow },
                    },
                    Aggregations = new Aggregations
                    {
                        Temperature = new MinMax { MaxToday = 26.7, MinToday = 20.0, Unit = "Celsius" },
                        Humidity = new MinMax { MaxToday = 52.0, MinToday = 45.0, Unit = "Percent" }
                    },
                    LastMeasurementTimestamp = DateTime.UtcNow
                }
            };
        }

        // Simuleer temperatuurverwerking voor een specifieke sensor
        public void SimulateTemperatureReading(float temperature, Sensor sensor)
        {
            sensor.LastMeasurements.Add(new Measurement
            {
                Type = "Temperature",
                Value = temperature,
                Unit = "Celsius",
                Timestamp = DateTime.UtcNow
            });

            // Update de data met RetrySensor logica als sensor een RetrySensor is
            sensor.UpdateData();

            Console.WriteLine($"Simulated temperature reading of {temperature}°C for sensor {sensor.Name}");
        }

        // Methode om gelijktijdige temperatuurmetingen te simuleren
        public void SimulateConcurrentReadings()
        {
            var sensors = GetMockSensors();
            foreach (var sensor in sensors)
            {
                // Simuleer een temperatuurmeting in een achtergrondthread
                ThreadPool.QueueUserWorkItem(state =>
                {
                    SimulateTemperatureReading(25.0f, sensor); // Pas de temperatuur aan zoals gewenst
                });
            }
        }
    }
}
