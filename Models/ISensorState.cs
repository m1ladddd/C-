namespace TemperatureMonitoring.Models
{
    // State interface to manage different sensor states
    public interface ISensorState
    {
        // Method to handle behavior based on temperature
        void Handle(SensorContext context, float temperature);
    }
}
