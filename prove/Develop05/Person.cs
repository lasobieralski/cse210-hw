public class Person
{
    private string _firstName;
    private string _lastName;
    private int _totalPoints;

    public Person(string firstName, string lastName)
    {
        _firstName = firstName;
        _lastName = lastName;
        _totalPoints = 0;
    }

    public string GetFullName() => $"{_firstName} {_lastName}";

    public string GetFileName() => $"{_firstName.ToLower()}.{_lastName.ToLower()}.txt";

    public int GetTotalPoints() => _totalPoints;

    public void AddPoints(int points) => _totalPoints += points;

    public void SaveData(List<Goals> goals)
    {
        string fileName = GetFileName();
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            writer.WriteLine($"Person: {GetFullName()}");
            writer.WriteLine($"Total Points: {_totalPoints}");
            foreach (Goals goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }
        Console.WriteLine($"Data successfully saved to {fileName}.");
    }

    public void LoadData(List<Goals> goals)
    {
        string fileName = GetFileName();
        if (!File.Exists(fileName))
        {
            Console.WriteLine($"No save file found for {GetFullName()}.");
            return;
        }

        using (StreamReader reader = new StreamReader(fileName))
        {
            reader.ReadLine(); // Skip user line
            string pointsLine = reader.ReadLine();
            _totalPoints = int.Parse(pointsLine.Replace("Total Points: ", ""));

            goals.Clear();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string type = line.Split('|')[0];
                Goals goal = type switch
                {
                    "SimpleGoals" => SimpleGoals.Deserialize(line),
                    "EternalGoals" => EternalGoals.Deserialize(line),
                    "ChecklistGoals" => ChecklistGoals.Deserialize(line),
                    _ => null
                };

                if (goal != null) goals.Add(goal);
            }
        }
        Console.WriteLine($"Data successfully loaded from {fileName}.");
    }
}