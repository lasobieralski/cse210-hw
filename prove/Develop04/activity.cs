using System;
using System.Threading;

 abstract class Activity
{
    //each child class will have unique welcome Message, description, and be asked how long they want to spend on the activity.
    private string _welcomeMessage;
    private string _description; 
    protected int _duration; 

    // Constructor to initialize common properties
    public Activity(string welcomeMessage, string description)
    {
        _welcomeMessage = welcomeMessage;
        _description = description;
        
    }
    public abstract void StartActivity();
    public void StartCommonActivityLogic()
    {
        // Common logic: display welcome message, description, and ask for duration
        Console.WriteLine(_welcomeMessage);
        Console.WriteLine(_description);
        Console.Write("How long would you like to spend on this activity in seconds? ");
        _duration = Convert.ToInt32(Console.ReadLine());

        // Common "get ready" message and pause
        Console.WriteLine("Get ready...");
        ShowSpinner(3); // Simulate preparation time (3 seconds)

        // Call the child class' specific activity logic (this will be implemented by each child class)
        StartActivity();
    }
    
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i> 0; i--)//this is for the countdown timer
        {
            //Console.Clear();
            Console.Write(i);//line 17 and 18 can be used for a pause when used by itself
            Thread.Sleep(1000);//when used together and you want to countdown overlapping 
            Console.Write("\b \b");//include line 19 which is backspace plus space and backspace this is for single digit count down
            //DateTime startTime = DateTime.Now;
            //DateTime endTime = startTime.AddSeconds(seconds);
            //Console.WriteLine();        
        }
    }

    public void ShowSpinner(int seconds)
    {    
        List<string> animationStrings = new List<string>();
        {
            animationStrings.Add("|");
            animationStrings.Add("*");
            animationStrings.Add("/");
            animationStrings.Add("-");
            animationStrings.Add("*");     
            animationStrings.Add("\\");
        };

                
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now <= endTime)
        {
            string s = animationStrings[i];
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");

            i++;

            if (i >= animationStrings.Count)
            {
                i = 0;
            }
        }
        //Console.WriteLine();
    }
    public void DisplayCompletionMessage(string activityName)
    {
        Console.WriteLine("Well done!"); 
        ShowSpinner(3);

        Console.WriteLine($"You have completed another {_duration} seconds of the {activityName} activity. I hope that helps you to relax!");
        ShowSpinner(3);

    }
}