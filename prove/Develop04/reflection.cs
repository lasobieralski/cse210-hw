using System;
class Reflection : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless"
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflection() : base("Welcome to the Reflection Activity!", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") 
    {
        //WelcomeMessage = "Welcome to the Reflection Activity!";
        //Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void StartActivity()
    {
        //Console.Write("Enter the duration for Reflection Activity (in seconds): ");
        //Duration = int.Parse(Console.ReadLine());
        int timeSpent = 0;
        Console.WriteLine("Starting Reflection Activity...");
        Random random = new Random();
        int promptIndex = random.Next(prompts.Length);
        Console.WriteLine(prompts[promptIndex]);
        
        //Console.Write("Enter the duration for Reflection Activity (in seconds): ");
        //_duration = int.Parse(Console.ReadLine());
        Console.WriteLine("\nPlease take a moment to think about the scenario above. Press Enter when you are ready to continue.");
        Console.ReadLine();  // This waits until the user presses Enter
        timeSpent += 0;
        // Once the user is ready, start the timer for the questions
        //Console.WriteLine("\nNow, let's reflect with some questions:");

        //int timePerQuestion = _duration / questions.Length;
        foreach (var question in questions)
        {
           if (timeSpent >= _duration)
            {
                break; // Stop if the total time spent exceeds or matches the duration
            }

            // Display the question
            Console.WriteLine(question);

            // Wait for 5 seconds (pause for thinking)
            int timeForPause = 5;
            if (timeSpent + timeForPause <= _duration)  // Only add time for the pause if we have enough time left
            {
                Thread.Sleep(timeForPause * 1000);  // Pause for 5 seconds
                timeSpent += timeForPause;  // Update the time spent
            }

            // If there's remaining time after the pause, you can optionally add a spinner for user interaction
            if (timeSpent < _duration)
            {
                ShowSpinner(3);  // Optionally, show a spinner for 1 second as a "thinking" indicator
            } 
        }
        DisplayCompletionMessage("Reflection");
    }
}

//After each question the program should pause for several seconds before continuing to the next one. While the program is paused it should display a kind of spinner.
//It should continue showing random questions until it has reached the number of seconds the user specified for the duration.
