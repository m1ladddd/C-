using Microsoft.AspNetCore.Mvc;
using TemperatureMonitoring.Services;
using TemperatureMonitoring.Models;
using System.Linq;

namespace TemperatureMonitoring.Controllers
{
    [ApiController]
    [Route("sensor")]
    public class SensorController : ControllerBase
    {
        private readonly MockSensorService _mockSensorService;

        public SensorController(MockSensorService mockSensorService)
        {
            _mockSensorService = mockSensorService;
        }

        [HttpGet]
        public IActionResult GetSensorData(string? name = null, string? serial_number = null)
        {
            var sensors = _mockSensorService.GetMockSensors();

            if (name == null && serial_number == null)
            {
                // No parameters provided, return all sensors
                var allSensorsResponse = new
                {
                    items = sensors.Select(s => new SensorResponseDto
                    {
                        Id = s.Id,
                        SerialNumber = s.SerialNumber,
                        Name = s.Name,
                        LastMeasurements = s.LastMeasurements.Select(m => new MeasurementDto
                        {
                            Type = m.Type,
                            Value = m.Value,
                            Unit = m.Unit,
                            Timestamp = m.Timestamp
                        }).ToList(),
                        Aggregations = new AggregationsDto
                        {
                            Temperature = new MinMaxDto
                            {
                                MaxToday = s.Aggregations.Temperature.MaxToday,
                                MinToday = s.Aggregations.Temperature.MinToday,
                                Unit = s.Aggregations.Temperature.Unit
                            },
                            Humidity = new MinMaxDto
                            {
                                MaxToday = s.Aggregations.Humidity.MaxToday,
                                MinToday = s.Aggregations.Humidity.MinToday,
                                Unit = s.Aggregations.Humidity.Unit
                            }
                        },
                        LastMeasurementTimestamp = s.LastMeasurementTimestamp
                    }).ToList()
                };

                return Ok(allSensorsResponse);
            }

            // Search for a specific sensor by `name` or `serial_number`
            var result = sensors.FirstOrDefault(s =>
                (name != null && s.Name == name) ||
                (serial_number != null && s.SerialNumber == serial_number));

            if (result == null)
            {
                return NotFound(new { message = "Sensor not found" });
            }

            // Map the found sensor to a response
            var singleSensorResponse = new
            {
                items = new[]
                {
                    new SensorResponseDto
                    {
                        Id = result.Id,
                        SerialNumber = result.SerialNumber,
                        Name = result.Name,
                        LastMeasurements = result.LastMeasurements.Select(m => new MeasurementDto
                        {
                            Type = m.Type,
                            Value = m.Value,
                            Unit = m.Unit,
                            Timestamp = m.Timestamp
                        }).ToList(),
                        Aggregations = new AggregationsDto
                        {
                            Temperature = new MinMaxDto
                            {
                                MaxToday = result.Aggregations.Temperature.MaxToday,
                                MinToday = result.Aggregations.Temperature.MinToday,
                                Unit = result.Aggregations.Temperature.Unit
                            },
                            Humidity = new MinMaxDto
                            {
                                MaxToday = result.Aggregations.Humidity.MaxToday,
                                MinToday = result.Aggregations.Humidity.MinToday,
                                Unit = result.Aggregations.Humidity.Unit
                            }
                        },
                        LastMeasurementTimestamp = result.LastMeasurementTimestamp
                    }
                }
            };

            return Ok(singleSensorResponse);
        }
    }
}
