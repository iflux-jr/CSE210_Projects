// -----------------------------------------------------------------------------
// Author: Emmanuel Uko
// Date: 05 October 2025
// Course: CSE 210 - Programming with Classes
// Assignment: W04 Team Activity - Foundation Program Design
//
// EXCEEDING REQUIREMENTS:
// To go beyond the base requirements, I implemented a SessionLogger class that:
// 1. Saves each completed activity (name and duration) into a text file ("MindfulnessLog.txt").
// 2. Allows users to view their full activity log from within the program.
// 3. Includes an option to clear the log file directly from the main menu.
// 4. Formats log entries with timestamps for better readability.
//
// These additions enhance user experience, persistence, and maintainability,
// showing practical use of file handling and encapsulation in C#.
// -----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Prepare prompts/questions as before
        List<string> reflectPrompts = new List<string> {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        List<string> reflectQuestions = new List<string> {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        List<string> listingPrompts = new List<string> {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        // Instantiate the session logger (make sure SessionLogger.cs is in project)
        SessionLogger logger = new SessionLogger();

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("=== Mindfulness Activities ===");
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Clear Activity Log");
            Console.WriteLine("6. Exit");
            Console.Write("Selection: ");
            string choice = Console.ReadLine();

            Activity activity = null;
            switch (choice.Trim())
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectingActivity(reflectPrompts, reflectQuestions);
                    break;
                case "3":
                    activity = new ListingActivity(listingPrompts);
                    break;
                case "4":
                    // Show log and pause
                    logger.ShowLog();
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    continue;
                case "5":
                    logger.ClearLog();
                    Console.WriteLine("log cleared successfully.");
                    Console.WriteLine("\nPress Enter to return to menu...");
                    Console.ReadLine();
                    continue;
                case "6":
                    exit = true;
                    continue;
                default:
                    Console.WriteLine("Invalid selection. Press Enter to continue.");
                    Console.ReadLine();
                    continue;
            }

            // Get duration from user
            int seconds = PromptForDuration();
            activity.SetDuration(seconds);

            // Run the activity
            activity.Run();

            // Log the session safely (so logging errors don't crash the program)
            try
            {
                logger.LogSession(activity.Name, seconds);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: could not write log. {ex.Message}");
            }

            Console.WriteLine();
            Console.Write("Would you like to do another activity? (y/n): ");
            string again = Console.ReadLine().Trim().ToLower();
            if (again != "y" && again != "yes")
            {
                exit = true;
            }
        }

        Console.WriteLine("Thank you for using the Mindfulness program. Goodbye!");
    }

    private static int PromptForDuration()
    {
        while (true)
        {
            Console.Write("Enter duration in seconds (e.g., 60): ");
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int secs) && secs >= 0)
            {
                return secs;
            }
            Console.WriteLine("Please enter a valid non-negative integer for seconds.");
        }
    }
}
