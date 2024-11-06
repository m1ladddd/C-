using TemperatureMonitoring.Models;
using TemperatureMonitoring.Services;

public interface ISensorFactory
{
    // Definieert een methode voor het aanmaken van een sensor zonder te specificeren welk type sensor
    Sensor CreateSensor();
}

public class TemperatureSensorFactory : ISensorFactory
{
    // Maakt een temperatuur sensor aan met een vast serienummer en naam
    public Sensor CreateSensor() => new Sensor { Name = "Temperature Sensor", SerialNumber = "123456" };
}

public class HumiditySensorFactory : ISensorFactory
{
    // Maakt een vochtigheidssensor aan met een vast serienummer en naam
    public Sensor CreateSensor() => new Sensor { Name = "Humidity Sensor", SerialNumber = "654321" };
}
