using System;

public class ActivityManager{
    private List<Activity> _activities = new List<Activity>();
    private string filename;

    ActivityManager(string filename){
        _filename = filename;
    }

    public void Start(){
        while(true){
            Console.WriteLine("Welcome to the Exercise Tracking Program!");
            Console.WriteLine("\nMenu Options");
            Console.WriteLine("\t1. Track Activity");
            Console.WriteLine("\t2. List Activities");
            Console.WriteLine("\t3. Save Activities");
            Console.WriteLine("\t4. Load Activities");
            Console.WriteLine("\t5. Delete Activity");
            Console.WriteLine("\t6. Quit");

            string option = Console.ReadLine();


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
                default:
                    Console.WriteLine("Invalid option");
                    continue;
            }
        }
    }
}