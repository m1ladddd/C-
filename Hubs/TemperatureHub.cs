using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TemperatureMonitoring.Hubs
{
    // Deze hub stuurt temperatuurupdates naar alle verbonden clients
    public class TemperatureHub : Hub
    {
        // Methode om temperatuurupdates te versturen naar alle clients
        public async Task SendTemperatureUpdate(string sensorId, float temperature)
        {
            // Gebruik het SignalR mechanisme om de clients te informeren over een temperatuurwijziging
            await Clients.All.SendAsync("ReceiveTemperatureUpdate", sensorId, temperature);
        }
    }
}
