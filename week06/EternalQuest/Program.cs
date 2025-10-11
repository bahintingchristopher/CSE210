using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");

        Console.WriteLine();
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}