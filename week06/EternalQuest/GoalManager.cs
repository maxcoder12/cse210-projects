using System.Collections.Generic;
using System.IO;
using System;

public class GoalManager{
    private List<Goal> _goals = new List<Goal>();
    private int _score;

    public GoalManager(){
        _score = 0;
    }



    public void Start(){
        DisplayPlayerInfo(); 
        while (true) {
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
            Console.WriteLine("\nYour goals:");
            foreach(Goal goal in _goals){
                int i = 0;
                Console.WriteLine($"{i+1}. {goal.GetStringRepresentation()}");
            }
        }
    }

    public void CreateGoal(){
        Console.Write("\nEnter your goal's name: ");
        string name = Console.ReadLine();
        Console.Write("\Write a description for you goal: ");
        string description = Console.ReadLine();
        Console.Write("\nEnter the points associated with this goal: ");
        int points = int.Parse(Console.ReadLine());

        Console.WriteLine("\n Select the type of goal: \n\t1)Simple Goal.\n\tEternal Goal.\n\tChecklist Goal.");
        string goalType = Console.ReadLine();

        switch(goalType){
            case "1":
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);
                break;
            case "2":
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);
                break;
            case "3":
                Console.WriteLine("\nHow many times do you want to make this task?");
                int target = int.Parse(Console.ReadLine());
                Console.WriteLine("\nWhat is the bonus for acomplishing this task?");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("\nInvalid option");
                return;
        }
        Console.WriteLine("Goal created successfully!!!");
    }

    public void RecordEvent(){
        ListGoalDetails();
        Console.WriteLine("What goal did you accomplish?")
        int i = int.Parse(Console.ReadLine()) - 1;
        if (i >= 0 && i < _goals.Count){
            _score += _goals[i].RecordEvent();
            Console.WriteLine("Congratulations!!");
        } else {
            Console.WriteLine("Invalid option!");
        }
    }

    public void SaveGoals(filename){
        using (StreamWriter file = new StreamWriter(filename)){
            file.WriteLine(_score);
            foreach (Goal goal in _goals){
                file.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Saved successfully");
    }

    public void LoadGoals(filename){
        if(!File.Exists(filename)){
            Console.WriteLine("\nThat file doesn't exist");
            return;
        } else {
            _goals.Clear();
            string[] lines = System.IO.File.ReadAllLines(filename);

            _score = lines[0];

            for (int i = 1; i < lines.Count; i++){
                string line = [i];
                string[] parts = line.Split(",");

                string typeGoal = parts[0];

                switch(typeGoal){
                    case "SimpleGoal":
                        string name = parts[1];
                        string description = parts[2];
                        int points = parts[3];
                        SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                        _goals.Add(simpleGoal);
                        break;
                    case "EternalGoal":
                        string name = parts[1];
                        string description = parts[2];
                        int points = parts[3];
                        EternalGoal eternalGoal = new EternalGoal(name, description, points);
                        _goals.Add(eternalGoal);
                        break;
                    case "ChecklistGoal":
                        string name = parts[1];
                        string description = parts[2];
                        int points = parts[3];
                        int target = parts[4];
                        int bonus = parts[5];
                        ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                        _goals.Add(checklistGoal);
                        break;
                };
            }
        };

        Console.WriteLine("Goals loaded succesfully");

    }
}