using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _rand = new Random();

    public ReflectingActivity(List<string> prompts, List<string> questions)
        : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = prompts ?? new List<string>();
        _questions = questions ?? new List<string>();
    }

    // Show a random prompt, then show questions with pauses until duration elapses
    public override void Run()
    {
        ShowStart();

        if (_prompts.Count == 0 || _questions.Count == 0)
        {
            Console.WriteLine("No prompts or questions found. Ending activity.");
            ShowEnd();
            return;
        }

        // Select a random prompt
        string prompt = _prompts[_rand.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Prompt:");
        Console.WriteLine($"  {prompt}");
        Console.WriteLine();
        Console.Write("When you have something in mind, press Enter to continue...");
        Console.ReadLine();

        DateTime end = ComputeEndTime();

        // Loop showing random questions and pause for reflection until time runs out
        while (DateTime.Now < end)
        {
            string question = _questions[_rand.Next(_questions.Count)];
            Console.WriteLine();
            Console.WriteLine("Reflect on:");
            Console.WriteLine($"  {question}");
            // pause with spinner for a few seconds (e.g., 8 seconds)
            ShowSpinner(8);
            Console.WriteLine();
        }

        ShowEnd();
    }
}