public class SimpleGoals : Goals
{
    private bool _completed;

    public SimpleGoals(string goalName, string description, int points)
        : base(goalName, description, points)
    {
        _completed = false;
    }

    public override string Serialize()
    {
        return $"SimpleGoals|{_goalName}|{_description}|{_points}|{_completed}";
    }

    public static new SimpleGoals Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        bool completed = bool.Parse(parts[4]);

        var goal = new SimpleGoals(name, description, points);
        if (completed) goal.RecordEvent();
        return goal;
    }

    public override void RecordEvent()
    {
        if (!_completed)
        {
            _completed = true;
            Console.WriteLine($"Goal '{_goalName}' completed! You earned {_points} points.");
        }
        else
        {
            Console.WriteLine($"Goal '{_goalName}' is already completed.");
        }
    }

    public override void DisplayGoal()
    {
        string status = _completed ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_goalName} - {_description} ({_points} points)");
    }
}
