namespace TemperatureMonitoring.Models
{
    public class OnlineState : ISensorState
    {
        public void Handle(SensorContext context, float temperature)
        {
            Console.WriteLine($"Sensor is online. Current temperature: {temperature}°C");

            if (temperature > 50) // Stel een drempelwaarde in voor waarschuwingen
            {
                context.SetState(new WarningState());
            }
        }
    }
}
