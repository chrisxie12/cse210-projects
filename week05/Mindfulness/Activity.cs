using System;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
        Console.Clear();
    }

    public void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinnerChars[i]);
            Thread.Sleep(200);
            Console.Write("\b \b");
            i = (i + 1) % spinnerChars.Count;
        }
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void ShowGrowShrinkAnimation(int seconds, bool growing)
    {
        int totalTicks = 8;
        int sleepPerTick = (seconds * 1000) / totalTicks;
        char dot = '\u00B7';

        if (growing)
        {
            for (int i = 1; i <= totalTicks; i++)
            {
                string dots = new string(dot, i);
                Console.Write(dots);
                Thread.Sleep(sleepPerTick);
                for (int j = 0; j < i; j++)
                    Console.Write("\b \b");
            }
        }
        else
        {
            string fullDots = new string(dot, totalTicks);
            Console.Write(fullDots);
            Thread.Sleep(sleepPerTick);
            for (int i = totalTicks - 1; i > 0; i--)
            {
                Console.Write("\b \b");
                Thread.Sleep(sleepPerTick);
            }
            Console.Write("\b \b");
        }
    }

    public int GetDuration()
    {
        return _duration;
    }

    public string GetName()
    {
        return _name;
    }
}
