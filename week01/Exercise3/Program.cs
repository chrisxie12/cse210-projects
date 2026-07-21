using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 3: Random number 1-100
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess = -1;

        // Core Requirement 2: Loop until guess matches
        while (guess != magicNumber)
        {
            // Core Requirement 1: Ask for guess
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            // Core Requirement 1: Higher, Lower, or Correct
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
                Console.WriteLine("You guessed it!");
            }
        }
    }
}