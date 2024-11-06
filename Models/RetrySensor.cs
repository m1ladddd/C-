using System;

namespace TemperatureMonitoring.Models
{
    public class RetrySensor : Sensor
    {
        private const int MaxRetries = 3;
        
        // Override van de UpdateData-methode met retry-mechanisme
        public override void UpdateData()
        {
            int retries = 0;
            bool updateSucceeded = false;

            while (retries < MaxRetries && !updateSucceeded)
            {
                try
                {
                    // Roep de basis-UpdateData-methode aan om de data bij te werken
                    base.UpdateData();
                    Console.WriteLine("Data updated successfully.");
                    updateSucceeded = true; // Markeer de update als geslaagd
                }
                catch (Exception ex)
                {
                    retries++;
                    Console.WriteLine($"Update failed, retrying ({retries}/{MaxRetries})... Error: {ex.Message}");
                    
                    // Optioneel: een korte pauze tussen retries, bijv. 500 ms
                    System.Threading.Thread.Sleep(500);
                }
            }

            // Als de update na de maximale retries nog steeds niet is geslaagd
            if (!updateSucceeded)
            {
                Console.WriteLine("Max retries reached. Update failed permanently.");
            }
        }
    }
}
