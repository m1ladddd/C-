using Xunit;
using TemperatureMonitoring.Tests;
using TemperatureMonitoring;
using TemperatureMonitoring.Observers;


namespace TemperatureMonitoring
{
    public class SensorTypeManager
    {
        private static SensorTypeManager _instance;

        private SensorTypeManager() { }

        public static SensorTypeManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SensorTypeManager();
                }
                return _instance;
            }
        }
    }
}

public class SingletonPatternTests
{
    [Fact]
    public void Test_SingletonBehavior()
    {
        // Arrange
        var manager = SensorTypeManager.Instance;

        // Act
        // ... your test logic ...

        // Assert
        // ... your assertions ...
    }
} 