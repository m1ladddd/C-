using System;
using System.IO;

namespace TemperatureMonitoring
{
    public static class Logger
    {
        private static readonly string logFilePath = "log.txt";

        // Methode om berichten naar een logbestand te schrijven
        public static void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.WriteLine($"{DateTime.UtcNow}: {message}");
            }
        }

        // Methode om fouten te loggen
        public static void LogError(Exception ex)
        {
            Log($"ERROR: {ex.Message}\nStackTrace: {ex.StackTrace}");
        }
    }
}
