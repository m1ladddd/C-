namespace TemperatureMonitoring.Observers
{
    public class TemperatureLogger : ITemperatureObserver
    {
        public void UpdateTemperature(float temperature)
        {
            Console.WriteLine($"Received temperature update: {temperature}°C");
        }
    }
}
