public abstract class Goals
{
    protected string _goalName;
    protected string _description;
    protected int _points;

    public Goals(string goalName, string description, int points)
    {
        _goalName = goalName;
        _description = description;
        _points = points;
    }

    public abstract string Serialize(); // Serialize the object into a string

    // Factory method for deserialization
    public static Goals Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];

        return type switch
        {
            "SimpleGoals" => SimpleGoals.Deserialize(data),
            "EternalGoals" => EternalGoals.Deserialize(data),
            "ChecklistGoals" => ChecklistGoals.Deserialize(data),
            _ => throw new InvalidOperationException($"Unknown goal type: {type}")
        };
    }

    public abstract void RecordEvent();
    public abstract void DisplayGoal();
    public string GetGoalName() => _goalName;
    public int GetLastRecordedPoints() => _points; // Example: Return base points (adjust for checklist or other goals)
}
