using TemperatureMonitoring.Observers;
using System;
using System.Threading.Tasks;

namespace TemperatureMonitoring.Services
{
    public class AsyncTemperatureProcessor
    {
        private readonly TemperatureSensor _sensor;

        public AsyncTemperatureProcessor(TemperatureSensor sensor)
        {
            _sensor = sensor;
        }

        public async Task ProcessTemperatureDataAsync(float temperature)
        {
            await Task.Delay(500); // Simuleer een vertraging om data te verwerken
            Console.WriteLine($"Asynchronously processing temperature: {temperature}°C");
            _sensor.NewTemperatureData(temperature); // Notificeer observers na verwerking
        }
    }
}
