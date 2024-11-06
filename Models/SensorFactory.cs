namespace TemperatureMonitoring.Models
{
    public static class SensorFactory
    {
        // Fabriekspatroon voor het aanmaken van sensoren op basis van het type
        public static Sensor CreateSensor(string type)
        {
            switch (type)
            {
                case "Temperature":
                    return new Sensor { Name = "Temperature Sensor", SerialNumber = "123456" };
                case "Humidity":
                    return new Sensor { Name = "Humidity Sensor", SerialNumber = "654321" };
                default:
                    return new Sensor { Name = "Default Sensor", SerialNumber = "789123" };
            }
        }
    }
}
