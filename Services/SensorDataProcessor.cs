using Microsoft.AspNetCore.SignalR;
using TemperatureMonitoring.Hubs;
using System.Threading.Tasks;
using TemperatureMonitoring.Observers;


namespace TemperatureMonitoring.Services
{
    public class SensorDataProcessor
    {
        private readonly IHubContext<TemperatureHub> _hubContext;

        public SensorDataProcessor(IHubContext<TemperatureHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task ProcessSensorDataAsync(float temperature, string sensorId)
        {
            // Verwerk data en stuur het naar alle verbonden clients via SignalR
            await _hubContext.Clients.All.SendAsync("ReceiveTemperatureUpdate", sensorId, temperature);
        }
    }
}
