using System.Collections.Generic;
using System.Linq;
using TemperatureMonitoring.Models;

public interface ISensorRepository
{
    // Retrieve all sensors
    IEnumerable<Sensor> GetAllSensors();
    
    // Retrieve a sensor by its ID
    Sensor GetSensorById(int id);
}

public class SensorRepository : ISensorRepository
{
    private readonly List<Sensor> _sensors;

    public SensorRepository()
    {
        // Initialize with mock data
        _sensors = new List<Sensor>
        {
            new Sensor { Id = 1, Name = "Temperature Sensor", SerialNumber = "123456" },
            new Sensor { Id = 2, Name = "Humidity Sensor", SerialNumber = "654321" }
        };
    }

    public IEnumerable<Sensor> GetAllSensors() => _sensors;

    public Sensor GetSensorById(int id) => _sensors.FirstOrDefault(s => s.Id == id);
}
