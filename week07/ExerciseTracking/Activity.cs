using System;
using System.Collections.Generic;

public abstract class Activity{
    protected DateTime _date;
    protected int _activityDuration;

    protected bool _isMile;

    public Activity(DateTime date, int duration, bool isMile){
        _date = date;
        _activityDuration = duration;
        _isMile =  isMile;
    }

    public bool IsMile(){
        return _isMile;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public abstract string GetSummary();

}