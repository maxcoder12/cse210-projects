using System.Collections.Generic;
using System.Threading;
using System;

public class ReflectingActivity : Activity{
    private List<string> _relatedQuestions = new List<string>(){
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"

    };

    private List<string> _prompts = new List<string>(){
        "Think of a time when you stood up for someone else",
        "Think of a time when you did something really difficult",
        "Think of a time when you helped someone in need",
        "Think of a time when you did something truly selfless"
    };

    public ReflectingActivity():base("Reflecting", "In this activity, you will reflect on a personal experience with some thought-provoking questions."){}

    public void Run(){
        DisplayStartingMessage();
        
        Console.WriteLine("Get ready...");
        ShowSpinner(4);


        Console.WriteLine("Consider the following Prompt: ");
        DisplayPrompt();

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        DisplayQuestions();

        DisplayEndingMessage();

    }

    public string GetRandomPrompt(){
        Random random = new Random();
        int randomPrompt = random.Next(0, _prompts.Count);
        return _prompts[randomPrompt];
    }

    public string GetRandomQuestion(List<string> availableQuestions){
        Random random = new Random();
        int randomQuestion = random.Next(0, availableQuestions.Count);
        return availableQuestions[randomQuestion];
    }

    public void DisplayPrompt(){
        Console.WriteLine($"—— {GetRandomPrompt()} ——\n");
    }

    public void DisplayQuestions(){
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(_duration);

        List<string> availableQuestions = new List<string>(_relatedQuestions);
    

        while (currentTime < futureTime){
            string question = GetRandomQuestion(availableQuestions);
            Console.Write(question + "\n");

            availableQuestions.Remove(question);
            ShowSpinner(_duration/5);
            currentTime = DateTime.Now;
        }
    }
} 