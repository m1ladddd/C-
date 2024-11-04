namespace TemperatureMonitoring.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string Name { get; set; }
        public List<Measurement> LastMeasurements { get; set; }
        public Aggregations Aggregations { get; set; }
        public DateTime LastMeasurementTimestamp { get; set; }
    }

    public class Measurement
    {
        public string Type { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class Aggregations
    {
        public MinMax Temperature { get; set; }
        public MinMax Humidity { get; set; }
    }

    public class MinMax
    {
        public double MaxToday { get; set; }
        public double MinToday { get; set; }
        public string Unit { get; set; }
    }
}
