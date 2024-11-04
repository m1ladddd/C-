namespace TemperatureMonitoring.Models
{
    public class SensorTypeManager
    {
        private static SensorTypeManager? _instance;
        private static readonly object _lock = new object();
        private Dictionary<int, string> sensorTypes = new Dictionary<int, string>();

        private SensorTypeManager() {}

        public static SensorTypeManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SensorTypeManager();
                    }
                    return _instance;
                }
            }
        }

        public string GetSensorType(int sensorId) => sensorTypes.TryGetValue(sensorId, out var type) ? type : "Unknown";
        public void AddSensorType(int sensorId, string type) => sensorTypes[sensorId] = type;
    }
}
