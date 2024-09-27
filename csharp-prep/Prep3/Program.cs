using System;
using System.Net;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,101);

        int guess = -1;
        bool playAgain = true;

        while (playAgain)
        {
            while (guess != magicNumber)
            {
                //Console.Write("What is the magic number? ");
                //guess = int.Parse(Console.ReadLine());
                //int magicNumber = int.Parse(Console.ReadLine());
                //string response = "yes";
                //while (response == "yes")

                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());

                if (guess < magicNumber)
                {
                    Console.WriteLine("higher");
                
                }

                else if (guess > magicNumber)
                {
                    Console.WriteLine("lower");
                }

                else
                {
                    Console.WriteLine("Congratulations you guessed correctly!");
                }
            }
        Console.Write("Do you want to continue? (yes/no): ");
        string response = Console.ReadLine();
        if (response != "yes")
        {
            playAgain = false;
        }
        }    
    Console.WriteLine("Thank you for playing! Come back Soon!"); 
    }     
}