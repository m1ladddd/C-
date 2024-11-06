namespace TemperatureMonitoring.Models
{
    // Singleton-klasse voor het beheren van sensortypen
    public class SensorTypeManager
    {
        private static SensorTypeManager? _instance;
        private static readonly object _lock = new object();
        private Dictionary<int, string> sensorTypes = new Dictionary<int, string>();

        // Private constructor om directe instanties te voorkomen
        private SensorTypeManager() {}

        // Singleton-toegangspunt voor SensorTypeManager
        public static SensorTypeManager Instance
        {
            get
            {
                lock (_lock)
                {
                    // Controleer of er al een instantie bestaat, anders maak er een
                    if (_instance == null)
                    {
                        _instance = new SensorTypeManager();
                    }
                    return _instance;
                }
            }
        }

        // Haal het type sensor op voor een gegeven sensorId
        public string GetSensorType(int sensorId) => sensorTypes.TryGetValue(sensorId, out var type) ? type : "Unknown";

        // Voeg een nieuw sensortype toe aan de dictionary
        public void AddSensorType(int sensorId, string type) => sensorTypes[sensorId] = type;
    }
}