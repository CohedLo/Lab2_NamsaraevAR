using System;
using System.Collections.Generic;
using Serilog;

class TriangleCalculator
{
    static void Main()
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        while (true)
        {
            Console.WriteLine("Введите длины сторон треугольника (через запятую):");
            string[] sides = Console.ReadLine().Split(',');

            if (sides.Length != 3)
            {
                Log.Error("Некорректный ввод. Введите длины трех сторон через запятую.");
                continue;
            }

            CalculateTriangle(sides[0], sides[1], sides[2]);
        }
    }

    static void CalculateTriangle(string sideA, string sideB, string sideC)
    {
        try
        {
            float a = float.Parse(sideA);
            float b = float.Parse(sideB);
            float c = float.Parse(sideC);

            string triangleType = GetTriangleType(a, b, c);
            List<(int, int)> vertices = GetScaledVertices(a, b, c);

            Log.Information($"Треугольник: {triangleType}");
            Log.Information($"Координаты вершин: {vertices[0]}, {vertices[1]}, {vertices[2]}");
        }
        catch (Exception ex)
        {
            Log.Error($"Ошибка: {ex.Message}");
            Log.Error($"Стек вызовов: {ex.StackTrace}");
        }
    }

    static string GetTriangleType(float a, float b, float c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return "не треугольник";

        if (a == b && b == c)
            return "равносторонний";

        if (a == b || b == c || a == c)
            return "равнобедренный";

        return "разносторонний";
    }

    static List<(int, int)> GetScaledVertices(float a, float b, float c)
    {
        if (a <= 0 || b <= 0 || c <= 0)
            return new List<(int, int)> { (-1, -1), (-1, -1), (-1, -1) };

        int scale = 100;
        int maxX = scale - 1;
        int maxY = scale - 1;

        int xA = 0;
        int yA = maxY;

        int xB = (int)(b * scale);
        int yB = maxY;

        int xC = (int)(c * scale / 2);
        int yC = 0;

        return new List<(int, int)> { (xA, yA), (xB, yB), (xC, yC) };
    }
}
