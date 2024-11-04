using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TemperatureMonitoring.Hubs
{
    public class TemperatureHub : Hub
    {
        public async Task SendTemperatureUpdate(string sensorId, float temperature)
        {
            await Clients.All.SendAsync("ReceiveTemperatureUpdate", sensorId, temperature);
        }
    }
}
