using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = ScriptureLoader.LoadFromFile("scriptures.txt");

        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        Console.WriteLine("Choose difficulty (easy = 1 word, medium = 3 words, hard = 5 words):");
        string difficulty = Console.ReadLine().ToLower();

        int hideCount = difficulty switch
        {
            "easy" => 1,
            "medium" => 3,
            "hard" => 5,
            _ => 3
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words, type 'hint' for a hint, or 'quit' to exit:");
            string input = Console.ReadLine().ToLower();

            if (input == "quit")
                break;
            else if (input == "hint")
                scripture.RevealRandomWord();
            else
                scripture.HideRandomWords(hideCount);

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden. Program ending.");
                break;
            }
        }
    }
}