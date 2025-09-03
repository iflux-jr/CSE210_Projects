using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        String gradeInput = Console.ReadLine();
        int gradePercentage = int.Parse(gradeInput);

        string letter = "";
        string sign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Adding + or - to the letter grade

        if (gradePercentage % 10 >= 7)
        {
            sign = "+";
        }
        else if (gradePercentage % 10 < 3 && letter != "F")
        {
            sign = "-";
        }

        // Stretch Challenge: A's cannot have a + and F's cannot have a sign

        if (letter == "A" && sign == "+" || gradePercentage == 100)
        {
            sign = "";
        }
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass. Better luck next time!");
        }
    }
}