// Scripture Memorizer Program
// 
// EXCEEDING CORE REQUIREMENTS:
// - Added a library of 3 scriptures and randomly selects one each time the program runs
// - Only hides words that are not already hidden (more efficient than random selection with duplicates)

using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = GetRandomScripture();
        
        string input = "";
        
        while (input != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");
            input = Console.ReadLine();
            
            if (input != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
        
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine();
        Console.WriteLine("Program ended.");
    }
    
    static Scripture GetRandomScripture()
    {
        Random random = new Random();
        
        Reference ref1 = new Reference("John", 3, 16);
        Scripture s1 = new Scripture(ref1, "For God so loved the world that he gave his only begotten Son");
        
        Reference ref2 = new Reference("Proverbs", 3, 5, 6);
        Scripture s2 = new Scripture(ref2, "Trust in the Lord with all thine heart and lean not unto thine own understanding");
        
        Reference ref3 = new Reference("Psalm", 23, 1);
        Scripture s3 = new Scripture(ref3, "The Lord is my shepherd I shall not want");
        
        Scripture[] library = { s1, s2, s3 };
        return library[random.Next(library.Length)];
    }
}
