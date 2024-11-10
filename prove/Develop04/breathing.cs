using System;
using System.Threading;
 class Breathing : Activity
{
    
    public Breathing() : base("Welcome to the Breathing Activity!", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") 
    {
        //welcomeMessage = "Welcome to the Breathing Activity!";
        //Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }
    
    public override void StartActivity()
    {
        int timeSpent = 0;
        while (timeSpent < _duration)
        {
            if (timeSpent + 3 <= _duration)
            {
                Console.WriteLine("breathe in...");
                ShowCountDown(3);
                timeSpent += 3;
            }
            if (timeSpent + 2 <= _duration)
            {
                Console.WriteLine("hold...");
                ShowCountDown(2);
                timeSpent += 2;
            }
            if (timeSpent + 4 <= _duration)
            {
                Console.WriteLine("breathe out slowly...");
                ShowCountDown(4);
                timeSpent += 4;
            }
        }
       
    DisplayCompletionMessage("Breathing");
    }
} 
    
    // public void ShowCountDown(int seconds)
    // {
    //      for (int i = seconds; i>0; i--)//this is for the countdown timer
    //      {
    //          Console.Write(i);//line 17 and 18 can be used for a pause when used by itself
    //          Thread.Sleep(1000);//when used together and you want to countdown overlapping 
    //          Console.Write("\b \b");//include line 19 which is backspace plus space and backspace this is for single digit count down
    //      }
    
    //Console.WriteLine();
   
    
    
