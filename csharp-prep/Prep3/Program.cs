using System;
using System.Net;

class Program
{
    static void Main(string[] args)

    {
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        if (magicNumber < guess)
        {
            Console.WriteLine("lower");
            
        }

        else if (magicNumber > guess)
        {
            Console.WriteLine("higher");
        }

        else
        {
            Console.WriteLine("Congratulations you guessed correctly!");
        }
    }
}