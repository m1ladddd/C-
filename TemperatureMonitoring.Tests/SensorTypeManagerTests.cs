using TemperatureMonitoring.Models;
using Xunit;
using TemperatureMonitoring.Observers;


namespace TemperatureMonitoring.Tests
{
    public class SensorTypeManagerTests
    {
        [Fact]
        public void SensorTypeManager_Should_Return_Single_Instance()
        {
            // Arrange & Act
            var instance1 = SensorTypeManager.Instance;
            var instance2 = SensorTypeManager.Instance;

            // Assert
            Assert.Same(instance1, instance2); // Beide instanties moeten hetzelfde zijn
        }
    }
}
