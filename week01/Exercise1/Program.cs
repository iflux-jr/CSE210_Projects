using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        String firstName = Console.ReadLine();

        Console.Write("What is your last name? ");
        String lastName = Console.ReadLine();

        Console.WriteLine($"Your Name is {lastName}, {firstName} {lastName}.");


        // Adding a fun element
        String name = $"{firstName} {lastName}";

        Console.WriteLine($"Welcome, {name}!");

        Console.Write("Password? ");
        String password = Console.ReadLine();
        
        if (password == "BOND007")
        {
            Console.WriteLine("Access Granted");
        }
        else
        {
            Console.WriteLine("Access Denied");
        }
    }
}