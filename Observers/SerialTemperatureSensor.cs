using System;
using System.Collections.Generic;
using System.IO.Ports; // Zorg dat System.IO.Ports is geïnstalleerd via NuGet
using System.Threading;
using TemperatureMonitoring.Observers;

namespace TemperatureMonitoring.Observers
{
    public class SerialTemperatureSensor
    {
        private readonly List<ITemperatureObserver> _observers = new List<ITemperatureObserver>();
        private readonly SerialPort _serialPort;
        private bool _keepReading;

        public SerialTemperatureSensor(string portName, int baudRate = 9600)
        {
            _serialPort = new SerialPort(portName, baudRate);
            _serialPort.DataReceived += OnDataReceived;
        }

        public void Start()
        {
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                _keepReading = true;
            }
        }

        public void Stop()
        {
            _keepReading = false;
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
            }
        }

        // Observer management methods
        public void AddObserver(ITemperatureObserver observer) => _observers.Add(observer);
        public void RemoveObserver(ITemperatureObserver observer) => _observers.Remove(observer);

        // Notify all observers
        private void NotifyObservers(float temperature)
        {
            foreach (var observer in _observers)
            {
                observer.UpdateTemperature(temperature);
            }
        }

        // Data received event handler
        private void OnDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!_keepReading) return;

            try
            {
                string data = _serialPort.ReadLine();
                if (float.TryParse(data, out float temperature))
                {
                    NotifyObservers(temperature);
                }
                else
                {
                    Console.WriteLine("Invalid temperature data received.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading from serial port: {ex.Message}");
            }
        }
    }
}
