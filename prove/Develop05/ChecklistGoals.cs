public class ChecklistGoals : Goals
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoals(string goalName, string description, int points, int bonusPoints, int targetCount)
        : base(goalName, description, points)
    {
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _currentCount = 0;
    }

    public override string Serialize()
    {
        return $"ChecklistGoals|{_goalName}|{_description}|{_points}|{_bonusPoints}|{_targetCount}|{_currentCount}";
    }

    public static new ChecklistGoals Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string name = parts[1];
        string description = parts[2];
        int points = int.Parse(parts[3]);
        int bonusPoints = int.Parse(parts[4]);
        int targetCount = int.Parse(parts[5]);
        int currentCount = int.Parse(parts[6]);

        var goal = new ChecklistGoals(name, description, points, bonusPoints, targetCount);
        goal._currentCount = currentCount;
        return goal;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Console.WriteLine($"Progressed {_goalName}. You earned {_points} points.");
            if (_currentCount == _targetCount)
            {
                Console.WriteLine($"Completed {_goalName}! You earned a bonus of {_bonusPoints} points.");
            }
        }
        else
        {
            Console.WriteLine($"{_goalName} is already completed.");
        }
    }

    public override void DisplayGoal()
    {
        string status = _currentCount >= _targetCount ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {_goalName} - {_description} ({_points} points per completion, {_bonusPoints} bonus) - Completed {_currentCount}/{_targetCount}");
    }
}
