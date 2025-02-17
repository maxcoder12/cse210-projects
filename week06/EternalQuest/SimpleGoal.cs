using System;

public class SimpleGoal : Goal {

    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points, isComplete){}

    public override int RecordEvent(){
        if (!_isComplete) {
            _isComplete = true;
            Console.WriteLine($"Goal completed! Earning {_points} points.");
            return _points;
        }
        return 0;
    }

    public override bool IsComplete(){
        return _isComplete;
    }

    public override string GetStringRepresentation(){
        string type = "Simple Goal";
        string _goalInfo = $"{type},{_name},{_description},{_points},{IsComplete()}";

        return _goalInfo;
    }
}