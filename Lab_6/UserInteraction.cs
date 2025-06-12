using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;

/// <summary>
/// Provides functionality for reading shapes from a file,
/// displaying them, and calculating specific metrics.
/// </summary>
class UserInteraction
{
    const int numberForPerimetrTriangle = 3;
    /// <summary>
    /// Reads shape data from a text file and creates corresponding shape objects.
    /// </summary>
    /// <param name="path">The file path containing the shape data.</param>
    /// <returns>A list of <see cref="Shape"/> objects created from the file data.</returns>
    public List<Shape> ReadShapesFromFile(string path)
    {
        List<Shape> shapes = new List<Shape>();
        string[] lines = File.ReadAllLines(path);

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) continue;

            string shapeType = parts[0].ToLower();
            try
            {
                switch (shapeType)
                {
                    case "circle":
                        double centerX = double.Parse(parts[1]);
                        double centerY = double.Parse(parts[2]);
                        double radius = double.Parse(parts[3]);
                        string circleColor = parts[4];
                        shapes.Add(new Circle(centerX, centerY, radius) { Color = circleColor });
                        break;
                    case "rectangle":
                        int a = int.Parse(parts[1]);
                        int b = int.Parse(parts[2]);
                        string rectColor = parts[3];
                        shapes.Add(new Rectangle(a, b) { Color = rectColor });
                        break;
                    case "triangle":
                        int baseLength = int.Parse(parts[1]);
                        int heightLength = int.Parse(parts[2]);
                        string triColor = parts[3];
                        shapes.Add(new Triangle(baseLength, heightLength) { Color = triColor });
                        break;
                    default:
                        Console.WriteLine($"Unknown shape type: {shapeType}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing line: {line}. {ex.Message}");
            }
        }
        return shapes;
    }

    /// <summary>
    /// Displays the list of shapes in the console, sorted by their area.
    /// </summary>
    /// <param name="shapes">The list of shapes to be displayed.</param>
    public void DisplayShapes(List<Shape> shapes)
    {
        shapes = shapes
    .OrderBy(s => s.CalculateSquare())
    .ToList();
        int index = 1;
        foreach (var shape in shapes)
        {
            Console.ForegroundColor = Enum.TryParse<ConsoleColor>(shape.Color, true, out var color) ? color : ConsoleColor.White;
            double shapeSquare = shape.CalculateSquare();
            Console.WriteLine($"{index} {shape.Type} {shapeSquare:F2} {shape.Color}");
            index++;
        }
        Console.ResetColor();
    }

    /// <summary>
    /// Calculates and displays the perimeter of equilateral triangles,
    /// assuming they are located in the second quadrant.
    /// </summary>
    /// <param name="shapes">The list of shapes to check for equilateral triangles.</param>
    public void CalculatePerimetersInSecondQuadrant(List<Shape> shapes)
    {
        foreach (var shape in shapes)
        {
            if (shape is Triangle triangle && triangle.BaseLength == triangle.HeightLength)
            {
                // Assumes that the triangle is equilateral and lies in the second quadrant
                Console.WriteLine($"Equilateral Triangle Perimeter: {triangle.BaseLength * numberForPerimetrTriangle}");
            }
        }
    }
}