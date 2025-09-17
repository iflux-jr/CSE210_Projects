using System;
using System.Collections.Generic;
using System.IO;

public static class ScriptureLoader
{
    public static List<Scripture> LoadFromFile(string filename)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("Scripture file not found. Using default scripture.");
            scriptures.Add(new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding."));
            return scriptures;
        }

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            // Format: Book|Chapter|Verse[-EndVerse]|Text
            string[] parts = line.Split('|');
            string book = parts[0];
            int chapter = int.Parse(parts[1]);

            string versePart = parts[2];
            Reference reference;
            if (versePart.Contains("-"))
            {
                string[] range = versePart.Split('-');
                reference = new Reference(book, chapter, int.Parse(range[0]), int.Parse(range[1]));
            }
            else
            {
                reference = new Reference(book, chapter, int.Parse(versePart));
            }

            string text = parts[3];
            scriptures.Add(new Scripture(reference, text));
        }

        return scriptures;
    }
}