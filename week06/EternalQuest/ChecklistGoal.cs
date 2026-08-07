/// <summary>
/// A goal that must be recorded a set number of times, awarding a bonus on the final one.
/// </summary>
public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _targetCount;
    private int _bonus;

    public ChecklistGoal(string shortName, string description, int points, int targetCount, int bonus)
        : base(shortName, description, points)
    {
        _amountCompleted = 0;
        _targetCount = targetCount;
        _bonus = bonus;
    }

    public void SetAmountCompleted(int amountCompleted)
    {
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        int earned = Points;

        if (_amountCompleted >= _targetCount)
        {
            earned += _bonus;
        }

        return earned;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _targetCount;
    }

    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{ShortName},{Description},{Points},{_bonus},{_targetCount},{_amountCompleted}";
    }
}