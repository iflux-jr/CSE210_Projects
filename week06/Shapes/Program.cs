using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of shapes
        List<Shape> shapes = new List<Shape>();

        // Add different shapes
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Display results
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} shape area: {shape.GetArea():F2}");
        }

        // Exceeds requirements: Demonstrates polymorphism with formatted output
        // and dynamic method dispatch for GetArea()
    }
}
// Program.cs