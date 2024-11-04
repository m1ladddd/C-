using System.Collections.Generic;

namespace TemperatureMonitoring.Observers
{
    public class TemperatureSensor
    {
        private readonly List<ITemperatureObserver> _observers = new List<ITemperatureObserver>();
        private float _temperature;

        // Attach an observer
        public void Attach(ITemperatureObserver observer)
        {
            _observers.Add(observer);
        }

        // Detach an observer
        public void Detach(ITemperatureObserver observer)
        {
            _observers.Remove(observer);
        }

        // Method to set temperature; kept for compatibility with tests
        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
            NotifyObservers();
        }

        // Update the temperature and notify observers (alternative method name)
        public void NewTemperatureData(float temperature)
        {
            SetTemperature(temperature);  // Using SetTemperature internally for backward compatibility
        }

        // Notify all observers about the temperature change
        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.UpdateTemperature(_temperature);
            }
        }
    }
}
