using System;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            //Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program");
            Console.WriteLine("Activity Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Mindful Eating Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Please choose an activity (1-5): ");
            string choice = Console.ReadLine();
        
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new Breathing();
                    break;
                case "2":
                    activity = new Reflection();
                    break;
                case "3":
                    activity = new Listing();
                    break;
                case "4":
                    activity = new Eating();
                    break;
                case "5":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1-5: ");
                    continue;
            }
            if (activity != null)
            {
                activity.StartCommonActivityLogic();
            }
        }
    }
}