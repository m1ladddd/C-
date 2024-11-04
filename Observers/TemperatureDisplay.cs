using TemperatureMonitoring.Observers;

namespace TemperatureMonitoring.Observers
{
    public class TemperatureDisplay : ITemperatureObserver
    {
        public float CurrentTemperature { get; private set; }

        // Implementation of the UpdateTemperature method
        public void UpdateTemperature(float temperature)
        {
            CurrentTemperature = temperature;
            DisplayTemperature();
        }

        private void DisplayTemperature()
        {
            // Logic to display the current temperature
            Console.WriteLine($"Current temperature: {CurrentTemperature}");
        }
    }
}
