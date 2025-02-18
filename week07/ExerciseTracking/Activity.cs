using System;
using System.Collection.Generic;

public abstract class Activity{
    protected DateTime _date;
    protected int _activityDuration;

    protected bool _isMile;

    public Activity(DateTime date, int duration, bool isMile){
        _date = date;
        _activityDuration = duration;
        _isMile =  isMile;
    }

    abstract double GetDistance();
    abstract double GetDpeed();
    abstract double GetDace();

    abstract string GetSummary();

}