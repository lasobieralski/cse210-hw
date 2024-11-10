using System;
class Listing : Activity
{
    public Listing() : base("Welcome to the Listing Activity!", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        //WelcomeMessage = "Welcome to the Listing Activity!";
        //Description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";

    }
    public override void StartActivity()
    {
        string[] themes = {
            "Who are people that you appreciate?",
            "What kinds of things bring you joy.",
            "What are some personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        //After the starting message, select a random prompt to show the user such as:
        Random random = new Random();
        int themeIndex = random.Next(themes.Length);
        Console.WriteLine(themes[themeIndex]);
        int responseCount = 0;
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            //Console.WriteLine("Start listing your thoughts related to the prompt above:");
            string userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput))
            {
                responseCount++;
            }
            ShowSpinner(1);
            if (DateTime.Now >= endTime)
            {
                break;
            }
        }

        // Display the number of responses the user provided
        Console.WriteLine($"\nYou have listed {responseCount} items.");
        
    
    //After displaying the prompt, the program should give them a countdown of several seconds to begin thinking about the prompt. Then, it should prompt them to keep listing items.
    //The user lists as many items as they can until they they reach the duration specified by the user at the beginning.

        DisplayCompletionMessage("Listing");
    }
}
