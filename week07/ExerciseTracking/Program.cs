using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Exercise Tracking Program!");
        Console.WriteLine("What file do you want to use for savign and loading your tracks?");
        string file = Console.ReadLine();
        ActivityManager manager = new ActivityManager(file); 

        manager.Start(); 
    }
}