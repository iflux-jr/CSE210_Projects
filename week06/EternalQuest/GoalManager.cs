using System;
using System.Collections.Generic;
using System.IO;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private List<string> _badges = new List<string>();
    private int _score = 0;

    public int Level => (_score / 1000) + 1;

    public string Rank
    {
        get
        {
            if (_score < 1000) return "Beginner";
            else if (_score < 5000) return "Achiever";
            else if (_score < 10000) return "Heroic Seeker";
            else return "Eternal Champion";
        }
    }

    public void AddGoal(Goal goal) => _goals.Add(goal);

    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals created yet.");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetails()}");
        }
    }

    public void DisplayStats()
    {
        Console.WriteLine($"\nTotal Score: {_score}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Rank: {Rank}");
        Console.WriteLine("Badges: " + (_badges.Count > 0 ? string.Join(", ", _badges) : "None yet"));
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            int points = goal.RecordEvent();
            _score += points;

            Console.WriteLine($"\nYou earned {points} points!");
            Console.WriteLine($"Total Score: {_score}");

            CheckLevelUp();
            CheckAchievements();
        }
        else
        {
            Console.WriteLine("\nInvalid goal selection.");
        }
    }

    private void CheckLevelUp()
    {
        Console.WriteLine($"You are now Level {Level} - {Rank}!");
    }

    private void CheckAchievements()
    {
        if (_score >= 2000 && !_badges.Contains("Steadfast"))
        {
            _badges.Add("Steadfast");
            Console.WriteLine("Badge Unlocked: Steadfast (2000 points!)");
        }

        if (_score >= 5000 && !_badges.Contains("Determined"))
        {
            _badges.Add("Determined");
            Console.WriteLine("Badge Unlocked: Determined (5000 points!)");
        }

        if (_score >= 10000 && !_badges.Contains("Eternal Legend"))
        {
            _badges.Add("Eternal Legend");
            Console.WriteLine("Ultimate Badge Unlocked: Eternal Legend!");
        }
    }

    // ✅ Save all data (Goals, Score, Level, Rank, Badges)
    public void SaveProgress()
    {
        Console.Write("Enter the filename to save progress (e.g., Goals.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "EternalQuestData.txt"; // default fallback
            Console.WriteLine($"No filename entered. Saving to default: {filename}");
        }

        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);                      // line 1: total score
                writer.WriteLine(Level);                       // line 2: level
                writer.WriteLine(Rank);                        // line 3: rank
                writer.WriteLine(string.Join(",", _badges));    // line 4: badges

                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }

            // ✅ Clean display after saving
            Console.WriteLine($"\nProgress successfully saved to '{filename}'!");
            Console.WriteLine("\n──────────────────────────────");
            Console.WriteLine(" Player Profile Summary");
            Console.WriteLine("──────────────────────────────");
            Console.WriteLine($"Level: {Level}");
            Console.WriteLine($"Rank: {Rank}");
            Console.WriteLine($"Total Score: {_score}");
            Console.WriteLine($"Badges: {(_badges.Count > 0 ? string.Join(", ", _badges) : "None yet")}");
            Console.WriteLine("──────────────────────────────");
            Console.WriteLine($"Total Goals Saved: {_goals.Count}");
            Console.WriteLine("──────────────────────────────");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving file: {ex.Message}");
        }
    }

    // ✅ Load all data (Goals, Score, Level, Rank, Badges)
        public void LoadProgress()
    {
        Console.Write("Enter the filename to load progress from (e.g., Goals.txt): ");
        string filename = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "EternalQuestData.txt"; // default fallback
            Console.WriteLine($"No filename entered. Loading from default: {filename}");
        }

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nFile '{filename}' does not exist. Please check the name and try again.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            _score = int.Parse(lines[0]);
            int savedLevel = int.Parse(lines[1]);
            string savedRank = lines[2];
            _badges = new List<string>(lines[3].Split(',', StringSplitOptions.RemoveEmptyEntries));
            _goals.Clear();

            for (int i = 4; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                string type = parts[0];

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                        break;
                    case "EternalGoal":
                        _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]),
                                                    int.Parse(parts[4]), int.Parse(parts[5]),
                                                    int.Parse(parts[6]), bool.Parse(parts[7])));
                        break;
                }
            }

            Console.WriteLine($"\nProgress successfully loaded from '{filename}'!");
            Console.WriteLine($"Welcome back, {savedRank}! Ready to continue your Eternal Quest?");
            Console.WriteLine("──────────────────────────────");
            Console.WriteLine(" Player Profile Restored");
            Console.WriteLine("──────────────────────────────");
            Console.WriteLine($"Level: {savedLevel}");
            Console.WriteLine($"Rank: {savedRank}");
            Console.WriteLine($"Total Score: {_score}");
            Console.WriteLine($"Badges: {(_badges.Count > 0 ? string.Join(", ", _badges) : "None yet")}");
            Console.WriteLine($"Goals Loaded: {_goals.Count}");
            Console.WriteLine("──────────────────────────────");
            
            CheckAchievements(); // reapply any badge logic after load
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading file: {ex.Message}");
        }
    }
}
