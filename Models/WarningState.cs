namespace TemperatureMonitoring.Models
{
    public class WarningState : ISensorState
    {
        public void Handle(SensorContext context, float temperature)
        {
            Console.WriteLine($"Warning! High temperature detected: {temperature}°C");

            if (temperature <= 50) // Terug naar online status als temperatuur daalt
            {
                context.SetState(new OnlineState());
            }
        }
    }
}
