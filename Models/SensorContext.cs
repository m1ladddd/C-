namespace TemperatureMonitoring.Models
{
    public class SensorContext
    {
        private ISensorState _state;

        public SensorContext()
        {
            _state = new OnlineState(); // Begin met de OnlineStatus
        }

        public void SetState(ISensorState state)
        {
            _state = state;
            Console.WriteLine($"Sensor state changed to: {state.GetType().Name}");
        }

        public void Handle(float temperature)
        {
            _state.Handle(this, temperature);
        }
    }
}
