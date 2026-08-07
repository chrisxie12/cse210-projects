/// <summary>
/// Manages the list of goals and the player's score, handling the menu actions,
/// creation, recording, display, saving, and loading.
/// </summary>
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private const int LevelUpInterval = 1000;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\nYou have " + _score + " points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Display Score");
            Console.WriteLine("  5. Save Goals");
            Console.WriteLine("  6. Load Goals");
            Console.WriteLine("  7. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    RecordEvent();
                    break;
                case "4":
                    Console.WriteLine("You have " + _score + " points.");
                    break;
                case "5":
                    SaveGoals();
                    break;
                case "6":
                    LoadGoals();
                    break;
                case "7":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.WriteLine("  4. Negative Goal (bonus)");
        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is it worth? ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points, false));
                break;
            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
                break;
            case "4":
                _goals.Add(new NegativeGoal(name, description, points));
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                break;
        }
    }

    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record yet.");
            return;
        }

        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        Goal selected = _goals[choice - 1];
        int earned = selected.RecordEvent();

        int previousLevel = _score / LevelUpInterval;
        _score += earned;
        int newLevel = _score / LevelUpInterval;

        if (earned > 0)
        {
            Console.WriteLine($"You earned {earned} points!");
        }

        if (newLevel > previousLevel)
        {
            Console.WriteLine($"Level up! You reached level {newLevel + 1}!");
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals = new List<Goal>();
        _score = 0;

        if (!File.Exists(filename))
        {
            Console.WriteLine("No saved file found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        if (lines.Length == 0)
        {
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            if (lines[i].Length == 0)
            {
                continue;
            }

            string[] parts = lines[i].Split(':', 2);
            string type = parts[0];
            string[] fields = parts[1].Split(',');

            Goal goal = null;

            switch (type)
            {
                case "SimpleGoal":
                    goal = new SimpleGoal(fields[0], fields[1], int.Parse(fields[2]), bool.Parse(fields[3]));
                    break;
                case "EternalGoal":
                    goal = new EternalGoal(fields[0], fields[1], int.Parse(fields[2]));
                    break;
                case "ChecklistGoal":
                    goal = new ChecklistGoal(fields[0], fields[1], int.Parse(fields[2]), int.Parse(fields[3]), int.Parse(fields[4]));
                    ((ChecklistGoal)goal).SetAmountCompleted(int.Parse(fields[5]));
                    break;
                case "NegativeGoal":
                    goal = new NegativeGoal(fields[0], fields[1], int.Parse(fields[2]));
                    break;
            }

            if (goal != null)
            {
                _goals.Add(goal);
            }
        }
    }

    private void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        SaveGoals(filename);
    }

    private void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();
        LoadGoals(filename);
    }
}