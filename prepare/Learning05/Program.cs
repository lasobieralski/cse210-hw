using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning05 World!");
    
        List<Shape> shapes = new List<Shape>();

        Circle s1 = new Circle("Purple", 4);
        shapes.Add(s1);

        Square s2 = new Square("Blue", 8);
        shapes.Add(s2);

        Rectangle s3 = new Rectangle("Yellow", 5,10);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}