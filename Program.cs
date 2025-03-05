using System;

class Program
{
    static bool isGameRunning = true;

    static void Main(string[] args)
    {
        int width = 30;
        int height = 10;
        int grandmaX = width / 2;
        int grandmaY = height - 1;
        int level = 1;
        Random random = new Random();
        while (isGameRunning)
        {
            Console.Clear();
            Console.WriteLine($"Level: {level}");
            Console.WriteLine(new string('=', width));
            char[,] roads = GenerateRoads(width, height, level, random);
            bool levelCompleted = false;
            while (!levelCompleted && isGameRunning)
            {
                DrawGameField(roads, width, height, grandmaX, grandmaY);
                Console.WriteLine("Use W/A/S/D to move, Q to quit:");
                string input = Console.ReadLine()?.ToLower();
                switch (input)
                {
                    case "w": if (grandmaY > 0) grandmaY--; break;
                    case "a": if (grandmaX > 0) grandmaX--; break;
                    case "s": if (grandmaY < height - 1) grandmaY++; break;
                    case "d": if (grandmaX < width - 1) grandmaX++; break;
                    case "q": isGameRunning = false; break;
                }
                if (grandmaY < height - 1 && roads[grandmaY, grandmaX] != ' ')
                {
                    Console.Clear();
                    Console.WriteLine("Game Over! Grandma got hit by a car.");
                    isGameRunning = false;
                }
                if (grandmaY == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Grandma successfully crossed the road!");
                    level++;
                    levelCompleted = true;
                }
            }
        }
        Console.WriteLine("Thanks for playing!");
    }
    static char[,] GenerateRoads(int width, int height, int level, Random random)
    {
        char[,] roads = new char[height, width];
        for (int y = 0; y < height - 1; y++)
        {
            for (int x = 0; x < width; x++)
            {
                roads[y, x] = random.Next(10) < level ? (random.Next(2) == 0 ? '>' : '<') : ' ';
            }
        }
        return roads;
    }
    static void DrawGameField(char[,] roads, int width, int height, int grandmaX, int grandmaY)
    {
        Console.Clear();
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (x == grandmaX && y == grandmaY)
                {
                    Console.Write("G");
                }
                else
                {
                    Console.Write(roads[y, x]);
                }
            }
            Console.WriteLine();
        }
    }
}