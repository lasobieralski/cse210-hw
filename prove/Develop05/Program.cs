// I added on getting a user's full name to be used in a greeting.
// I also use the user's name to save their work to a .txt file.
// I added an automatic save feature incase the user left without 
// saving their work.(I have a habit of doing that.)
// I added on a recognize a return user when they enter their name so 
// that they could pick up where they left off. 
// I created extra class to handle the person's name.

public class Program
{
    static Person currentPerson;
    static List<Goals> goalsList = new List<Goals>(); // Store all goals

    static void Main(string[] args)
    {
        Console.Write("Please enter your full name (e.g., John Doe): ");
        string fullName = Console.ReadLine();
        string[] nameParts = fullName.Split(' ');

        if (nameParts.Length < 2)
        {
            Console.WriteLine("Invalid name format. Please use 'First Last'.");
            return;
        }

        currentPerson = new Person(nameParts[0], nameParts[1]);
        string fileName = currentPerson.GetFileName();
        if (File.Exists(fileName))
        {
            Console.WriteLine("Loading your progress...");
            currentPerson.LoadData(goalsList);
            ListGoals();
            Console.WriteLine($"\nWelcome back! You have {currentPerson.GetTotalPoints()} points.");
        }
        else
        {
            Console.WriteLine($"\nWelcome {currentPerson.GetFullName()}!");
            //Console.WriteLine($"Your data will be saved to: {currentPerson.GetFileName()}");
            Console.WriteLine("You are about to begin Your Eternal Quest Journey");
            Console.WriteLine($"\nYou have {currentPerson.GetTotalPoints()} points.");
        }
        bool running = true;
        try
        {
            while (running)
            {
                //Console.WriteLine("\nHello Develop05 World!");

                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Exit Program");
                Console.Write("Select a choice from the menu (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        Console.WriteLine("Thank you for using Eternal Quest. Goodbye.");
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1-6.");
                        break;
                }
            }
        }
        finally
        {
            Console.WriteLine("Saving your progress...");
            SaveGoals(); // Automatically save progress before exiting
            //Console.WriteLine("Progress saved successfully!");
        }
    }
    
    static void CreateNewGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        Goals newGoal = choice switch
        {
            "1" => CreateSimpleGoal(),
            "2" => CreateEternalGoal(),
            "3" => CreateChecklistGoal(),
            _ => null
        };

        if (newGoal != null)
        {
            goalsList.Add(newGoal);
            Console.WriteLine("\nGoal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid choice. Returning to the main menu.");
        }
    }

    static Goals CreateSimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        return new SimpleGoals(name, description, points);
    }

    static Goals CreateEternalGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        return new EternalGoals(name, description, points);
    }

    static Goals CreateChecklistGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("What is the total number of times this goal must be completed? ");
        int totalCount = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for completing the goal? ");
        int bonusPoints = int.Parse(Console.ReadLine());

        return new ChecklistGoals(name, description, points, bonusPoints, totalCount);
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        if (goalsList.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
        }
        else
        {
            int index = 1;
            foreach (Goals goal in goalsList)
            {
                Console.Write($"{index}. ");
                goal.DisplayGoal();
                index++;
            }
        }
    }
    
    static void SaveGoals()
    {
        currentPerson.SaveData(goalsList);
        Console.WriteLine("\nGoals saved successfully!");

        // Display the saved file content
        string fileName = currentPerson.GetFileName();
        if (File.Exists(fileName))
        {
            Console.WriteLine("\nFile Content:");
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
        else
        {
            Console.WriteLine("Error: The save file could not be found.");
        }
    }

    static void LoadGoals()
    {
        currentPerson.LoadData(goalsList);
        ListGoals();
    }

    static void RecordEvent()
    {
        if (goalsList.Count == 0)
        {
            Console.WriteLine("No goals available to record.");
            return;
        }

        Console.WriteLine("Which goal would you like to record progress on?");
        for (int i = 0; i < goalsList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goalsList[i].GetGoalName()}");
        }

        Console.Write("Enter the goal number: ");
        int choice = int.Parse(Console.ReadLine());

        if (choice < 1 || choice > goalsList.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goals selectedGoal = goalsList[choice - 1];
        selectedGoal.RecordEvent();
        currentPerson.AddPoints(selectedGoal.GetLastRecordedPoints());
    }
    
}







//I had help from chatGPT, website generator, and Gemini.