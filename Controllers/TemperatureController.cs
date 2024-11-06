using Microsoft.AspNetCore.Mvc;
using TemperatureMonitoring.Services;

namespace TemperatureMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly MockSensorService _mockSensorService;

        // Constructor voor Dependency Injection van MockSensorService,
        // zodat dezelfde Singleton-instantie van MockSensorService hergebruikt wordt.
        public TemperatureController(MockSensorService mockSensorService)
        {
            _mockSensorService = mockSensorService;
        }

        [HttpGet("mock-data")]
        public IActionResult GetMockData(string? serialNumber = null)
        {
            // Gebruik de facade-functionaliteit van MockSensorService om sensorgegevens op te halen.
            var sensors = _mockSensorService.GetMockSensors();
            var sensor = sensors.FirstOrDefault(s => s.SerialNumber == serialNumber);

            if (sensor == null)
            {
                // Retoureer een 404-fout als de sensor niet gevonden is
                return NotFound(new { message = "Sensor not found" });
            }

            return Ok(sensor); // Retoureer de gegevens van de gevonden sensor
        }
    }
}