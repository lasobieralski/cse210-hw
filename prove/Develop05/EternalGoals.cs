public class EternalGoals : Goals
{
    public EternalGoals(string goalName, string description, int points)
        : base(goalName, description, points)
    {
    }

    public override string Serialize()
    {
        return $"EternalGoals|{_goalName}|{_description}|{_points}";
    }

    public static new EternalGoals Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);

        return new EternalGoals(name, description, points);
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded: {_goalName}. You earned {_points} points.");
    }

    public override void DisplayGoal()
    {
        Console.WriteLine($"[∞] {_goalName}: {_description} ({_points} points per completion)");
    }
}
