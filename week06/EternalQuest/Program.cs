using System;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("What file do you want to use to save and load your goals?");
        string file = Console.ReadLine();
        GoalManager manager = new GoalManager(file);
        manager.Start();
    }
}