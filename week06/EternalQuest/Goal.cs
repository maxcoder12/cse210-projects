using System;

public abstract class Goal{
    private string _name;
    private string _description;
    private int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    };
    public abstract void RecordEvent(){};
    public abstract bool IsComplete(){};
    public abstract string GetStringRepresentation(){};
}