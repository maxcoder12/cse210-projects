using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class ActivityManager{
    private List<Activity> _activities = new List<Activity>();
    private string _filename;

    ActivityManager(string filename){
        _filename = filename;
    }

    bool continueWhile = true;

    public void Start(){
        while(continueWhile){
            Console.WriteLine("\nMenu Options");
            Console.WriteLine("\t1. Track Activity");
            Console.WriteLine("\t2. List Activities");
            Console.WriteLine("\t3. Save Activities");
            Console.WriteLine("\t4. Load Activities");
            Console.WriteLine("\t5. Delete Activity");
            Console.WriteLine("\t6. Quit");

            string option = Console.ReadLine();

            private string ListTracks(){
                Console.WriteLine("Your tracks:");
                int i = 1;
                private string tracks;
                foreach (Activity activity in _activities)
                {   
                    string summary = activity.GetSummary();

                    string[] parts = summary.Split(",");

                    bool isMile = bool.Parse(parts[6]);

                    if (isMile){
                        tracks += $"{i}. {parts[0]} : {parts[1]} ({parts[2]} min) - Distance: {parts[3]} miles | Speed: {parts[4]} mph | Pace: {parts[5]} min per mile.";
                    } else {
                        tracks += $"{i}. {parts[0]} : {parts[1]} ({parts[2]} min) - Distance: {parts[3]} km | Speed: {parts[4]} kph | Pace: {parts[5]} min per km.";
                    }

                    // return $"{date},Cycling,{_activityDuration},{GetDistance()},{GetSpeed()},{GetPace()},{IsMile()}";
                }
                return tracks;     
            }


            switch (option){
                case "1":
                    bool isMile;

                    Console.WriteLine("What unit do you want to use?");
                    Console.WriteLine("1. Miles");
                    Console.WriteLine("2. Kilometers");
                    string unit = Console.ReadLine();
                    unit = unit.Trim();

                    if(unit == "1"){
                        isMile = true;
                    } else if ( unit == ""){
                        isMile = false;
                    }

                    Console.WriteLine("What type of exercise do you want to track?");
                    Console.WriteLine("1. Running");
                    Console.WriteLine("2. Cycling");
                    Console.WriteLine("3. Swimming");        
                    string exercise = Console.ReadLine();


                    DateTime today = Date.Now;

                    Console.WriteLine("How many minutes did it last?");
                    int duration = int.Parse(Console.ReadLine());

                    switch (exercise){
                        case "1":
                            Console.WriteLine("What was the distance run?");
                            double distance = double.Parse(Console.ReadLine());
                            RunningActivity _running = new RunningActivity(today, duration, isMile, distance);
                            _activities.Add(_running);
                        case "2":
                            Console.WriteLine("What was your speed?");
                            double speed = double.Parse(Console.ReadLine());
                            CyclingActivity _cycling = new CyclingActivity(today, duration, isMile, speed);
                            _activities.Add(_cycling);
                        case "3":
                            Console.WriteLine("How many laps swun?");
                            double laps = double.Parse(Console.ReadLine());
                            SwimmingActivity _swimming = new SwimmingActivity(today, duration, isMile, laps);
                            _activities.Add(_swimming);
                    }
                    break;
                case "2":
                    Console.ReadLine(ListTracks());
                    break;
                case "3":
                    using (StreamWriter file = new StreamWriter(_filename)){
                        foreach (Activity activity in _activities){
                            Console.WriteLine(activity.GetSummary());
                        }
                    }
                    break;
                case "4":
                    if(!File.Exists(_filename)){
                        Console.WriteLine("That file doesn't exists");
                        break;
                    } else {
                        _activities.Clear();
                        string[] lines = System.IO.File.ReadAllLines(_filename);

                        for (int i = 0; i < lines.Length; i++){
                            string line = lines[i];

                            string[] parts = line.Split(",");

                            bool isMile = bool.Parse(parts[6]);

                            Datetime date = DateTime.ToString(parts[0]);
                            string name = parts[1];
                            int duration = int.Parse(parts[2]);
                            double distance = double.Parse(parts[3]);
                            double speed = double.Parse(parts[4]);
                            double pace = double.Parse(parts[5]);

                            switch (name){
                                case "Cycling":
                                    CyclingActivity cycling = new CyclingActivity(date, duration, isMile, distance);
                                    _activities.Add(cycling);
                                    break;
                                case "Running":
                                    RunningActivity running = new RunningActivity(date, duration, isMile, speed);
                                    _activities.Add(running);
                                    break;
                                case "Swimming":
                                    int laps = parts[7];
                                    SwimmingActivity swimming = new SwimmingActivity(date, duration, isMile, laps)
                                    _activities.Add(swimming);
                                    break:
                                default:
                                    break;
                            }   
                        }
                    }
                    break;
                case "5":
                    Console.WriteLine(ListTracks());
                    Console.WriteLine("What track do you want to delete?");
                    int lineDeleted = int.Parse(Console.ReadLine());

                    if(!File.Exists(_filename)){
                        Console.WriteLine("There was an error with the file...")
                        break;
                    } else{
                        string [] lines = System.IO.File.ReadAllLines(_filename);

                        if (lineDeleted > 0 && lineDeleted < lines.Length){
                            lines.RemoveAt(lineDeleted-1);
                            File.WriteAllLines(_filename, lines);
                            Console.WriteLine("The track was deleted!");
                            break;
                        } else{
                            Console.WriteLine("Invalid track number...")
                            break;
                        }
                    }
                case "6":
                    Console.WriteLine("Thank you! Goodbye!");
                    continueWhile = false;
                    break;
                default:
                    Console.WriteLine("Select a valid option...");
                    continue;
            }
        }
    }
}