using System;

public class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base (name, description, points){
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent(){
        _amountCompleted++;
        return (_amountCompleted == _target) ? _points + _bonus : _points;
    }

    public override bool IsComplete(){
        return _amountCompleted >= _target;
    }

    public override string GetStringRepresentation(){
        string type = "Checklist Goal";
        string _goalInfo = $"{type},{_name},{_description},{_points},{_target},{_amountCompleted}";

        return _goalInfo;
    }
}