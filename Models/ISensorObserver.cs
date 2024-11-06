namespace TemperatureMonitoring.Models
{
    // Observer interface for monitoring sensor data changes
    public interface ISensorDataObserver
    {
        // Update method to notify observers of changes
        void Update(float temperature, float humidity, float battery);
    }
}
