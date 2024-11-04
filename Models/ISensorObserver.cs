namespace TemperatureMonitoring.Models
{
    public interface ISensorDataObserver
    {
        void Update(float temperature, float humidity, float battery);
    }
}
