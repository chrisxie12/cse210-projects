/*
 * EternalQuest
 *
 * This program goes beyond the core requirements in the following ways:
 *
 * 1. Bonus goal type: NegativeGoal. Instead of awarding points, recording an
 *    event on a NegativeGoal subtracts points from the player's score. This is
 *    meant to model bad habits that cost points, adding a new way to use the
 *    goal system beyond the three required types.
 *
 * 2. Leveling system: every 1000 total points earned moves the player up a
 *    level. Whenever a recorded event pushes the score across a 1000-point
 *    boundary, a "Level up!" message is printed to the console.
 */

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}