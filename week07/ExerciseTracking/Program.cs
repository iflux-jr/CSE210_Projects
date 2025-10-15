using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create activities
        Running run = new Running("03 Nov 2022", 30, 3.0);      // 3 miles in 30 mins
        Cycling cycle = new Cycling("03 Nov 2022", 30, 6.0);    // 6 mph average
        Swimming swim = new Swimming("03 Nov 2022", 30, 20);    // 20 laps

        // Store all activities in a list
        List<Activity> activities = new List<Activity>() { run, cycle, swim };

        // Display each activity summary
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}