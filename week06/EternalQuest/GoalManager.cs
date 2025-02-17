using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

public class GoalManager{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    private string _filename;

    public GoalManager(string filename){
        _score = 0;
        _filename = filename;
    }



    public void Start(){
        while (true) {
            DisplayPlayerInfo(); 
            Console.WriteLine("\nMenu Options");
            Console.WriteLine("\t1. Create New Goal");
            Console.WriteLine("\t2. List Goals");
            Console.WriteLine("\t3. Save Goals");
            Console.WriteLine("\t4. Load Goals");
            Console.WriteLine("\t5. Record Event");
            Console.WriteLine("\t6. Quit");
            Console.Write("Select an option from the menu: ");

            string choice = Console.ReadLine();
            switch (choice) {
                case "1": 
                    CreateGoal();  
                    break;
                case "2": 
                    ListGoalDetails(); 
                    break;
                case "3": 
                    SaveGoals(); 
                    break;
                case "4": 
                    LoadGoals();
                    break;
                case "5": 
                    RecordEvent(); 
                    break;
                case "6": 
                    return;
                default: 
                    Console.WriteLine("Invalid choice..."); 
                    break;
            }
        }
    }

    public void DisplayPlayerInfo(){
        Console.WriteLine($"\nCurrent Score: {_score}\n");
    }

    public void ListGoalDetails(){
        if (_goals.Count == 0){
            Console.WriteLine("\nNo goals available");
            return;
        } else{
            List<Goal> sortedGoals = _goals.OrderByDescending(goal => goal.IsComplete()).ToList();

            Console.WriteLine("\nYour goals:");
            int i = 0;

            foreach(Goal goal in sortedGoals){
                string[] goalInfo = goal.GetStringRepresentation().Split(",");


                string type = goalInfo[0];
                string name = goalInfo[1];
                string description = goalInfo[2];
                int target;
                int amountCompleted;

                string stringRepresentation;

                if (type == "Eternal Goal" && goalInfo.Length == 5){

                    stringRepresentation = $"[∞]. {name} - {description}";
                    Console.WriteLine($"{i+1}. {stringRepresentation}");

                } else if (goalInfo.Length == 5){

                    stringRepresentation = (goal.IsComplete() ? "[X]." : "[ ].") + $"{name} - {description}";
                    Console.WriteLine($"{i+1}. {stringRepresentation}");

                } else if (goalInfo.Length == 8){

                    target = int.Parse(goalInfo[4]);
                    amountCompleted = int.Parse(goalInfo[5]);

                    stringRepresentation = (goal.IsComplete() ? "[X]." : "[ ].")+ $"[{amountCompleted}/{target}] {name} - {description}";
                    Console.WriteLine($"{i+1}. {stringRepresentation}");

                } else if (goalInfo.Length < 4){
                    Console.WriteLine($"There is an error in the line format at the line {i+1} in the file {_filename}");
                }
                i++;
            }
        }
    }

    public void CreateGoal(){
        Console.Write("\nEnter your goal's name: ");
        string name = Console.ReadLine();
        Console.Write("\nWrite a description for you goal: ");
        string description = Console.ReadLine();
        Console.Write("\nEnter the points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("\n Select the type of goal: \n\t1)Simple Goal.\n\t2)Eternal Goal.\n\t3)Checklist Goal.");
        string goalType = Console.ReadLine();

        switch(goalType){
            case "1":
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points, false);
                _goals.Add(simpleGoal);
                break;
            case "2":
                EternalGoal eternalGoal = new EternalGoal(name, description, points, false);
                _goals.Add(eternalGoal);
                break;
            case "3":
                Console.WriteLine("\nHow many times do you want to make this task?");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("\nWhat is the bonus for acomplishing this task?");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, 0, bonus, false);
                _goals.Add(checklistGoal);
                break;
            default:
                Console.WriteLine("\nInvalid option");
                return;
        }
        Console.WriteLine("Goal created successfully!!!");
    }

    public void RecordEvent(){
        ListGoalDetails();
        Console.WriteLine("What goal did you accomplish?");

        int i = int.Parse(Console.ReadLine()) - 1;
        string[] goalInfo = _goals[i].GetStringRepresentation().Split(",");
        string type = goalInfo[0];
        if (!_goals[i].IsComplete() || type == "Eternal Goal"){
            _score += _goals[i].RecordEvent();
            Console.WriteLine("Congratulations!!");
        } else if (_goals[i].IsComplete()) {
            Console.WriteLine("Goal already Completed!");
        } else{
            Console.WriteLine("Invalid option");
        }
    }

    public void SaveGoals(){
        using (StreamWriter file = new StreamWriter(_filename)){
            file.WriteLine(_score);
            foreach (Goal goal in _goals){
                file.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saved successfully");
    }

    public void LoadGoals(){
        if(!File.Exists(_filename)){
            Console.WriteLine("\nThat file doesn't exist");
            return;

        } else {
            _goals.Clear();
            string[] lines = System.IO.File.ReadAllLines(_filename);

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                List<string> parts = new List<string>(line.Split(","));

                if(parts.Count < 4){
                    Console.WriteLine($"Invalide line format at the line {i+1} : {line}");
                    continue;
                }

                string typeGoal = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = false;

                switch(typeGoal){
                    case "Simple Goal":

                        if (parts.Count >= 5) {
                            isComplete = bool.Parse(parts[4]);
                        }
                    
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points, isComplete);
                        _goals.Add(simpleGoal);
                        break;
                    case "Eternal Goal":
                        if (parts.Count >= 5) {
                            isComplete = bool.Parse(parts[4]);
                        }
                        EternalGoal eternalGoal = new EternalGoal(name, description, points, isComplete);
                        _goals.Add(eternalGoal);
                        break;
                    case "Checklist Goal":
                        if (parts.Count == 8) {
                            int target = int.Parse(parts[4]);
                            int amountCompleted = int.Parse(parts[5]);
                            int bonus = int.Parse(parts[6]);
                            isComplete = bool.Parse(parts[7]); // isComplete is in the last part
    
                            ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, amountCompleted, bonus, isComplete);
                            _goals.Add(checklistGoal);
                        } else {
                            Console.WriteLine($"Invalid Checklist Goal format at line {i+1}: {line}");
                        }
                        break;
                };
            }
        };

        Console.WriteLine("Goals loaded succesfully");

    }
}
}