namespace TemperatureMonitoring.Models
{
    public interface ISensorState
    {
        void Handle(SensorContext context, float temperature);
    }
}
