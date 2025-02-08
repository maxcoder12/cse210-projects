using System.Threading;
using System;

public class BreathingActivity : Activity
{

    public BreathingActivity() : base("Breathing", "This activity helps you relax by focusing on your breath. You will inhale and exhale at a steady pace."){}

    public void Run(){
        DisplayStartingMessage();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime){
            Console.WriteLine("Breathe in...");
            ShowCountDown(5);
            Console.WriteLine("Breathe out...");
            ShowCountDown(5);
        }

        DisplayEndingMessage();

    }
}