/// <summary>
/// An abstract base class that represents a generic goal in the EternalQuest game.
/// Holds common state and defines the contract every goal type must implement.
/// </summary>
public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string shortName, string description, int points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string ShortName => _shortName;

    public string Description => _description;

    public int Points => _points;

    /// <summary>
    /// Records an event for this goal and returns the number of points earned.
    /// </summary>
    public abstract int RecordEvent();

    /// <summary>
    /// Indicates whether this goal has been completed.
    /// </summary>
    public abstract bool IsComplete();

    /// <summary>
    /// Builds the display text shown in the goal list.
    /// </summary>
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    /// <summary>
    /// Builds a file-friendly representation using a type prefix and field data.
    /// Format: "TypeName:shortName,description,points,extra fields..."
    /// </summary>
    public abstract string GetStringRepresentation();
}