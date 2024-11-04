using Microsoft.AspNetCore.Mvc;
using TemperatureMonitoring.Services;

namespace TemperatureMonitoring.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperatureController : ControllerBase
    {
        private readonly MockSensorService _mockSensorService;

        public TemperatureController(MockSensorService mockSensorService)
        {
            _mockSensorService = mockSensorService;
        }

        [HttpGet("mock-data")]
        public IActionResult GetMockData(string? serialNumber = null)
        {
            var sensors = _mockSensorService.GetMockSensors();
            var sensor = sensors.FirstOrDefault(s => s.SerialNumber == serialNumber);

            if (sensor == null)
            {
                return NotFound(new { message = "Sensor not found" });
            }

            return Ok(sensor);
        }
    }
}
