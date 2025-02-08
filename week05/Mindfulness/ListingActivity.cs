using System.Threading;
using System.Collections.Generic;
using System;

public class ListingActivity : Activity{
    private int _count;
    private List<string> _prompts = new List<string>(){
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity():base("Listing", "In this activity, you will list as many items as you can in response to a random prompt."){}

    public void Run(){
        DisplayStartingMessage();
        
        Console.WriteLine("Get ready...");
        ShowSpinner(4);


        Console.WriteLine("List as many responses you can to the following prompt:");

        Console.WriteLine($"—— {GetRandomPrompt()} ——");

        Console.Write("You may begin in: ");
        ShowCountDown(3);

        List<string> list = GetListFromUser();

        Console.WriteLine($"You listed {list.Count} items!");

        DisplayEndingMessage();

    }

    public string GetRandomPrompt(){
        Random random = new Random();
        int randomPrompt = random.Next(0, _prompts.Count);
        return _prompts[randomPrompt];
    }

    public List<string> GetListFromUser(){

        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(_duration);

        List<string> userList = new List<string>();

        while (currentTime < futureTime){
            string item = Console.ReadLine();
            userList.Add(item);
            currentTime = DateTime.Now;
        }

        return userList;
    }
} 