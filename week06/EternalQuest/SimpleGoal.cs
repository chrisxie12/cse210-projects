/// <summary>
/// A goal that is either completed or not. Recording the event once marks it complete.
/// </summary>
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string shortName, string description, int points, bool isComplete)
        : base(shortName, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _isComplete = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{ShortName},{Description},{Points},{_isComplete}";
    }
}