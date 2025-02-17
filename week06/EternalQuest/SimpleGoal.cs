using System;

public class SimpleGoal : Goal {
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points) : base(name, description, points){
        _IsComplete = false;
    } 

    public override void RecordEvent(){
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
        return (_isComplete ? "[X]" : "[ ]") + "Simple Goal " + _name + " - " + _description;
    }
}