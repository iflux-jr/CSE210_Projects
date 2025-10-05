using System;
using System.Threading;

public abstract class Activity
{
    // Encapsulated member variables (private)
    private string _name;
    private string _description;
    private int _durationSeconds;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _durationSeconds = 0;
    }

    // Public getters (no direct setters to enforce encapsulation)
    public string Name => _name;
    public string Description => _description;
    public int DurationSeconds => _durationSeconds;

    // Set duration (validates input)
    public void SetDuration(int seconds)
    {
        if (seconds < 0) seconds = 0;
        _durationSeconds = seconds;
    }

    // Common start message
    public void ShowStart()
    {
        Console.Clear();
        Console.WriteLine($"--- {Name} ---");
        Console.WriteLine();
        Console.WriteLine(Description);
        Console.WriteLine();
        Console.WriteLine($"This activity will run for {DurationSeconds} second{(DurationSeconds == 1 ? "" : "s")}.");
        Console.WriteLine();
        Console.Write("Get ready... ");
        ShowSpinner(3);
        Console.WriteLine();
    }

    // Common end message
    public void ShowEnd()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {Name} for {DurationSeconds} second{(DurationSeconds == 1 ? "" : "s")}.");
        ShowSpinner(3);
        Console.WriteLine();
    }

    // Simple spinner animation for 'seconds' seconds
    public void ShowSpinner(int seconds)
    {
        string[] seq = new string[] { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(seq[i % seq.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    // Countdown display (shows numbers 3..1 or specified seconds)
    public void PauseWithCountdown(int seconds)
    {
        for (int s = seconds; s >= 1; s--)
        {
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b"); // erase
        }
    }

    // Each derived class must implement Run which performs the activity
    public abstract void Run();

    // Helper to ensure time accounting for child classes
    protected DateTime ComputeEndTime()
    {
        return DateTime.Now.AddSeconds(DurationSeconds);
    }
}