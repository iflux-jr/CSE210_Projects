using System;
using System.IO;

public class SessionLogger
{
    private string _filePath = "MindfulnessLog.txt";

    public void LogSession(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {activityName,-20} | Duration: {duration} sec";
        File.AppendAllText(_filePath, logEntry + Environment.NewLine);
    }

    public void ShowLog()
    {
        if (File.Exists(_filePath))
        {
            string logContent = File.ReadAllText(_filePath);
            Console.WriteLine("\n🧘 Mindfulness Activity Log:");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine(logContent);
        }
        else
        {
            Console.WriteLine("\nNo log found yet. Try completing an activity first!");
        }
    }

    public void ClearLog()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
            Console.WriteLine("\n✅ Log cleared successfully!");
        }
        else
        {
            Console.WriteLine("\nNo log file to clear.");
        }
    }
}
