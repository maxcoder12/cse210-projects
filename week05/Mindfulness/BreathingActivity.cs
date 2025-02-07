using System;

public class BreathingActivity : Activity
{

    public BreathingActivity() : base(){}
    
    public void Run(){
        Console.WriteLine(DisplayStartingMessage());

        
        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(_duration);

        while (currentTime < futureTime){
            Console.WriteLine("Breathe in...");
            ShowCountDown(_duration/5);
            Console.WriteLine("Breathe out...");
            ShowCountDown(_duration/5);
            currentTime = DateTime.Now;
        }

        DisplayEndingMessage();

    }
}