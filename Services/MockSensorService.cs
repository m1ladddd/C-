using System;
using System.Collections.Generic;
using TemperatureMonitoring.Models; // Make sure to include your Models namespace

namespace TemperatureMonitoring.Services
{
    public class MockSensorService
    {
        public List<Sensor> GetMockSensors()
        {
            return new List<Sensor>
            {
                new Sensor
                {
                    Id = 1,
                    SerialNumber = "123456", // First sensor serial number
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
                    SerialNumber = "654321", // Second sensor serial number
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
                }
            };
        }
    }
}
