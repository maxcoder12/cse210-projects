using System;

public class EternalGoal : Goal{

    public EternalGoal(string name, string description, int points, bool isComplete) : base(name, description, points, isComplete){}
    

    public override int RecordEvent(){
        Console.WriteLine($"Goal completed! Earning {_points} points.");
        return _points;
    }

    public override bool IsComplete(){
        return false;
    }

    public override string GetStringRepresentation(){
        string type = "Eternal Goal";
        string _goalInfo = $"{type},{_name},{_description},{_points},{IsComplete()}";

        return _goalInfo;
    }
}