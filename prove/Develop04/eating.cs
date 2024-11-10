//focus on the smell of the food, it's 
//texture, it's taste, chewing, and swallowing
using System.Runtime.CompilerServices;

class Eating : Activity
{
    public Eating() : base("Welcome to the Eating Activity!", "Learning how to mindfully eat food by focusing on taste, texture, chewing, and swallowing.") 
    {
        //WelcomeMessage = "Welcome to the Eating Activity!";
        //Description = "Teaching you how to mindfully eat by focusing on taste, texture, chewing, and swallowing.";
    }
    public override void StartActivity()
    {
        bool stillHungry = true;

        while (stillHungry)
        {
            Console.WriteLine("Take a bite of food...");
            //Thread.Sleep(3000);
            ShowCountDown(3);
            Console.WriteLine("Think of what it taste like...");
            ShowCountDown(5);
            Console.WriteLine("How does the texture feel...");
            ShowCountDown(5);
            Console.WriteLine("Start to chew your bite... do not swallow.");
            ShowCountDown(5);
            Console.WriteLine("Start to swallow follow the food down your throat into the stomach. How do you feel?");
            ShowCountDown(3);

            Console.WriteLine("\nAre you still hungry? (yes or no or exit)");
            string response = Console.ReadLine().ToLower();

            if (response == "no")
            {
                Console.WriteLine("Awesome Job!!");
                stillHungry = false;
            }
            else if (response == "yes")
            {
                Console.WriteLine(" okay, let's take another bite");
            }
            else if (response == "exit")
            {
                Console.WriteLine("Ending the activity. Good Job!");
                stillHungry = false;
            }
            else
            {
                  Console.WriteLine("Please enter yes or no or exit.");
            }
        
            DisplayCompletionMessage("Eating");
        }
    }
}



