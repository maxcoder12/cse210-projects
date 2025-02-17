using System;

public class ChecklistGoal : Goal {
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int amountCompleted, int bonus, bool isComplete) : base (name, description, points, isComplete){
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }
    
    public override int RecordEvent(){
        _amountCompleted++;

        if (_amountCompleted >= _target) {_isComplete = true;}
        
        string award = (_amountCompleted == _target) ? $"Goal completed! Earning {_points} points and {_bonus} of bonus" : $"Goal completed! Earning {_points} points.";
        Console.WriteLine(award);
        return (_amountCompleted == _target) ? _points += _bonus : _points;
    }

    public override bool IsComplete(){
        return _isComplete;
    }

    public override string GetStringRepresentation(){
        string type = "Checklist Goal";
        string _goalInfo = $"{type},{_name},{_description},{_points},{_target},{_amountCompleted},{_bonus},{IsComplete()}";

        return _goalInfo;
    }
}