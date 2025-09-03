using System;

class Program
{
    static void Main(string[] args)
    {
        String playAgain;

        do
        {
            // Console.WriteLine("What is the magic number? ");
            // String magicInput = Console.ReadLine();
            // int magicNumber = int.Parse(magicInput);

            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;
            String guessInput;

            Console.WriteLine("I have picked a number between 1 and 100.");
            Console.WriteLine("Can you guess the magic number?");

            do
            {
                Console.Write("What is your guess? ");
                guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);

                // Guess count
                guessCount++;

                // Loop
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            } while (guess != magicNumber);

            // Ask user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing! Goodbye.");

    }
}