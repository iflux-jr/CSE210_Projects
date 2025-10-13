using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        int choice = 0;

        while (choice != 7)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Goal Event");
            Console.WriteLine("4. Show Score & Stats");
            Console.WriteLine("5. Save Progress");
            Console.WriteLine("6. Load Progress");
            Console.WriteLine("7. Quit");
            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\nSelect Goal Type:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("Select a choice from the menu: ");
                    int type = int.Parse(Console.ReadLine());

                    Console.Write("Enter goal name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    string desc = Console.ReadLine();
                    Console.Write("Enter point value: ");
                    int points = int.Parse(Console.ReadLine());

                    if (type == 1)
                        manager.AddGoal(new SimpleGoal(name, desc, points));
                    else if (type == 2)
                        manager.AddGoal(new EternalGoal(name, desc, points));
                    else if (type == 3)
                    {
                        Console.Write("Enter target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, desc, points, target, bonus));
                    }
                    break;

                case 2:
                    manager.DisplayGoals();
                    break;

                case 3:
                    manager.DisplayGoals();
                    Console.Write("\nSelect goal number to record: ");
                    int goalIndex = int.Parse(Console.ReadLine()) - 1;
                    manager.RecordEvent(goalIndex);
                    break;

                case 4:
                    manager.DisplayStats();
                    break;

                case 5:
                    manager.SaveProgress();
                    break;

                case 6:
                    manager.LoadProgress();
                    break;

                case 7:
                    Console.WriteLine("Goodbye, Adventurer!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}

/*
=============================
    EXCEEDED REQUIREMENTS
=============================
1. Added Leveling System — players gain a new level every 1000 points.
2. Added Achievement Badges — special awards unlocked at score milestones 
   (Steadfast – 2000 pts, Determined – 5000 pts, Eternal Legend – 10000 pts).
3. Added Rank Titles — motivational titles that evolve with progress 
   (Beginner → Achiever → Heroic Seeker → Eternal Champion).
4. Enhanced Load Summary — after loading, the program displays a clean, 
   stylized summary with player stats and a “Welcome Back” message.
=============================
*/
