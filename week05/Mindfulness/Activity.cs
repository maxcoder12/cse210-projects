using System;

public class Activity{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description){
        _name = name;
        _description = description;
    }

    public void SetDuration(int seconds){
        _duration = seconds;
    }

    public void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {_name} Activity!");

        Console.WriteLine(_description);
        
        Console.Write("How long, in seconds, would you like for your session?");
        SetDuration(int.Parse(Console.ReadLine()));
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("Well done!");
        ShowSpinner(4);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity!");
        ShowSpinner(4);
    }

    public void ShowSpinner(int seconds){
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        DateTime currentTime = DateTime.Now;

        while (currentTime < futureTime){
            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("——");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write(" \ ").Trim();
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("——");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write(" \ ").Trim();
            Thread.Sleep(200);
            Console.Write("\b \b");
        }
    }

    public void ShowCountDown(int seconds){
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(seconds);
        DateTime currentTime = DateTime.Now;

        int second = seconds;

        while (currentTime < futureTime){
            Console.WriteLine(second);
            Thread.Sleep(1000);
            second--;
        }
    }
}