using System.Threading;
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
        Console.WriteLine($"Welcome to the {_name} Activity!\n");

        Console.WriteLine(_description);

        Console.Write("\nHow long, in seconds, would you like for your session?");
        SetDuration(int.Parse(Console.ReadLine()));
    }

    public void DisplayEndingMessage(){
        Console.WriteLine("Well done!");
        ShowSpinner(4);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name} Activity!");
    }

    public void ShowSpinner(int seconds){
        DateTime endTime = DateTime.Now.AddSeconds(seconds);;

        while (DateTime.Now < endTime){
            Console.Write("|");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write("—");
            Thread.Sleep(200);
            Console.Write("\b \b");
            Console.Write(@"\");
            Thread.Sleep(200);
            Console.Write("\b \b");
        }

        Console.Write("\b \b");
    }

    public void ShowCountDown(int seconds){
        for (int i = seconds; i > 0; i--){
            Console.WriteLine(i);
            Console.Write("\b \b");
            Thread.Sleep(1000);            
        }
    }
}