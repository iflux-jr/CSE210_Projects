using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts;

    public ListingActivity(List<string> prompts)
        : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = prompts ?? new List<string>();
    }

    // Show a prompt, give the user a short countdown to think, then collect inputs until time expires
    public override void Run()
    {
        ShowStart();

        if (_prompts.Count == 0)
        {
            Console.WriteLine("No prompts available. Ending activity.");
            ShowEnd();
            return;
        }

        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine($"  {prompt}");
        Console.WriteLine();
        Console.Write("You will have a few seconds to think before listing. Ready? ");
        ShowSpinner(2);
        Console.WriteLine();
        Console.WriteLine("Begin listing items (press Enter after each).");

        DateTime end = ComputeEndTime();
        List<string> responses = new List<string>();

        while (DateTime.Now < end)
        {
            // Inform user of remaining seconds (optional)
            TimeSpan remaining = end - DateTime.Now;
            Console.Write($"> ({(int)remaining.TotalSeconds}s left) ");
            // Use ReadLine with a timeout-like pattern: if user waits past end time, break
            // Simple implementation: if time remains > 0, read; otherwise break
            if (DateTime.Now >= end) break;

            // ReadLine will block; but since time is limited and spec allows simple behavior,
            // we trust the user to press Enter within reasonable time. We'll nevertheless check time afterwards.
            string line = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(line))
            {
                responses.Add(line.Trim());
            }
            // if time already passed, break (defensive)
            if (DateTime.Now >= end) break;
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {responses.Count} item{(responses.Count == 1 ? "" : "s")}.");
        if (responses.Count > 0)
        {
            Console.WriteLine("Your items:");
            foreach (var r in responses)
            {
                Console.WriteLine($" - {r}");
            }
        }

        ShowEnd();
    }
}