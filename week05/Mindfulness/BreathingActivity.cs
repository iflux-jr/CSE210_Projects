using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // No extra member variables required for the core behavior

    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Implement the breathing sequence:
    // Alternate "Breathe in..." and "Breathe out..." with countdowns until duration elapsed.
    public override void Run()
    {
        ShowStart();

        DateTime end = ComputeEndTime();
        bool inhale = true;

        while (DateTime.Now < end)
        {
            if (inhale)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                // choose a comfortable countdown for inhale
                PauseWithCountdown(4);
            }
            else
            {
                Console.WriteLine();
                Console.Write("Breathe out... ");
                // choose a comfortable countdown for exhale
                PauseWithCountdown(6);
            }

            inhale = !inhale;

            // short spinner between breaths
            Console.Write(" ");
            ShowSpinner(1);
            Console.WriteLine();
        }

        ShowEnd();
    }
}