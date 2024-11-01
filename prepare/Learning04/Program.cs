using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment student1 = new Assignment("Amy Nagel", "Drawings");
        Console.WriteLine(student1.GetSummary());

        MathAssignment mathAssignment1 = new MathAssignment("Mary Smith", "Fractions", "Section 7.2", "3-10, 15-26");
        Console.WriteLine(mathAssignment1.GetHomeworkList());

        WritingAssignment writingAssignment1 = new WritingAssignment("Mary Waters", "White Water Rafting", "In Colorado");
        Console.WriteLine(writingAssignment1.GetWritingInformation());
    }   
}
