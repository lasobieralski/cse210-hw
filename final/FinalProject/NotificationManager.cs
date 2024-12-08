public class NotificationManager
{
    private List<string> _reminders;

    public NotificationManager()
    {
        _reminders = new List<string>();
    }

    public void AddReminder(string reminder)
    {
        if (!_reminders.Contains(reminder))
        {
            _reminders.Add(reminder);
        }
        else
        {
            Console.WriteLine($"Reminder '{reminder}' already exists.");
        }
    
    }

    public void RemoveReminder(string reminder)
    {
        if (_reminders.Contains(reminder))
        {
            _reminders.Remove(reminder);
            Console.WriteLine($"Reminder '{reminder}' removed.");
        }
        else
        {
            Console.WriteLine($"Reminder '{reminder}' not found.");
        }
    }

    public void ClearReminders()
    {
        _reminders.Clear();
        Console.WriteLine("All reminders cleared.");
    }

    public void SendReminders()
    {
        if (_reminders.Count == 0)
        {
            Console.WriteLine("No reminders to send.");
            return;
        }

        Console.WriteLine("Reminders:");
        foreach (var reminder in _reminders)
        {
            Console.WriteLine($"- {reminder}");
        }
    }
}
