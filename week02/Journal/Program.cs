using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        int choice = 0;
        while (choice != 5)
        {
            Console.WriteLine("Journal Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");

            if (!int.TryParse(Console.ReadLine(), out choice))
                choice = 0;

            switch (choice)
            {
                case 1:
                    string prompt = promptGen.GetRandomPrompt();
                    Console.WriteLine($"\n{prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToShortDateString();
                    journal.AddEntry(new Entry(date, prompt, response));
                    break;

                case 2:
                    journal.DisplayEntries();
                    break;

                case 3:
                    Console.Write("Enter filename to save: ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                    break;

                case 4:
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                    break;

                case 5:
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid choice, try again.\n");
                    break;
            }
        }
    }
}
