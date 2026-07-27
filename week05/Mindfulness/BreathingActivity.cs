using System;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
               "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowGrowShrinkAnimation(4, growing: true);
            Console.WriteLine();

            if (DateTime.Now >= endTime)
                break;

            Console.Write("Breathe out...");
            ShowGrowShrinkAnimation(6, growing: false);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }
}
