// SensorResponseDto.cs
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TemperatureMonitoring.Models
{
    public class SensorResponseDto
    {
        public int Id { get; set; }

        [JsonPropertyName("serial_number")]
        public string SerialNumber { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("last_measurements")]
        public List<MeasurementDto> LastMeasurements { get; set; }

        [JsonPropertyName("aggregations")]
        public AggregationsDto Aggregations { get; set; }

        [JsonPropertyName("last_measurement_timestamp")]
        public DateTime LastMeasurementTimestamp { get; set; }
    }

    public class MeasurementDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("value")]
        public double Value { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }

        [JsonPropertyName("timestamp")]
        public DateTime Timestamp { get; set; }
    }

    public class AggregationsDto
    {
        [JsonPropertyName("temperature")]
        public MinMaxDto Temperature { get; set; }

        [JsonPropertyName("humidity")]
        public MinMaxDto Humidity { get; set; }
    }

    public class MinMaxDto
    {
        [JsonPropertyName("max_today")]
        public double MaxToday { get; set; }

        [JsonPropertyName("min_today")]
        public double MinToday { get; set; }

        [JsonPropertyName("unit")]
        public string Unit { get; set; }
    }
}