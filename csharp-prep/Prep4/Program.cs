using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers both positive and negative, type 0 when finished.");

        int userNumber = -1;
        while (userNumber !=0)

        {
            
            Console.Write("Enter number: ");

            string enterNumber = Console.ReadLine();
            userNumber = int.Parse(enterNumber);

            if (userNumber !=0)
            {
                numbers.Add(userNumber);
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        int min = numbers[0];
        foreach (int number in numbers)
        {
            if (number > 0)
            {
                min = number;
            }

        }
        Console.WriteLine($"The largest number is: {max}");
        Console.WriteLine($"The smallest positive number is: {min}");

        numbers.Sort(); 
        Console.WriteLine($"The sorted list is: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number + " ");
        }


    }   
        

       
}