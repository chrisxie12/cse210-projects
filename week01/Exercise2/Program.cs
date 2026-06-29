using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        // Determine letter grade
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine sign (+ or -)
        string sign = "";
        int lastDigit = grade % 10;

        if (grade >= 60 && grade < 90)
        {
            // B, C, D can have + or -
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (grade >= 90 && grade < 100)
        {
            // A can only have -, never +
            if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        // F grades get no sign at all

        // Print final grade
        Console.WriteLine($"Your grade is: {letter}{sign}");

        // Determine if passed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the course!");
        }
        else
        {
            Console.WriteLine("Keep working hard! You'll get it next time.");
        }
    }
}