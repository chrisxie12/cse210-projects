/// <summary>
/// A bonus goal type that deducts points instead of awarding them,
/// used to discourage bad habits.
/// </summary>
public class NegativeGoal : Goal
{
    public NegativeGoal(string shortName, string description, int points)
        : base(shortName, description, points)
    {
    }

    public override int RecordEvent()
    {
        return -Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{ShortName},{Description},{Points}";
    }
}