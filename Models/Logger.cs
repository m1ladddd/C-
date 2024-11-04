namespace TemperatureMonitoring.Models
{
    public class Logger : ISensorDataObserver
    {
        public void Update(float temperature, float humidity, float battery)
        {
            Console.WriteLine($"Temperature: {temperature}, Humidity: {humidity}, Battery: {battery}");
        }
    }
}
