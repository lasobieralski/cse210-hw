using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        string letterGrade = "";

        if (percent >= 90)
        {
            letterGrade = "A";
        }

        else if (percent >= 80)
        {
            letterGrade = "B";
        }

        else if (percent >= 70)
        {
            letterGrade = "C";
        }

        else if (percent >= 60)
        {
            letterGrade = "D";
        }

        else
        {
            letterGrade = "F";
        } 

        Console.WriteLine($"Your grade is: {letterGrade}");

        if (percent >= 70)
        {
            Console.WriteLine("Congratulations you passed!");
        }   

        else
        {
            Console.WriteLine("Thanks for all the hard work, try again next semester.");
        }
    }
}