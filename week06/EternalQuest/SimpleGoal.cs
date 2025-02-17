using System;

public class SimpleGoal : Goal {
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points){
        _isComplete = false;
    } 

    public override int RecordEvent(){
        if (!_isComplete) {
            _isComplete = true;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete(){
        return _isComplete;
    }

    public override string GetStringRepresentation(){
        string type = "Simple Goal";
        string _goalInfo = $"{type},{_name},{_description},{_points}";

        return _goalInfo;
    }
}