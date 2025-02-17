using System;

public class EternalGoal : Goal{

    public EternalGoal(string name, string description, int points) : base(name, description, points){};

    public override int RecordEvent(){
        return _points;
    }

    public override bool IsComplete(){
        return false;
    }

    public override string GetStringRepresentation(){
        string type = "Simple Goal";
        string _goalInfo = $"{type},{_name},{_description},{_points}";

        return _goalInfo;
    }
}