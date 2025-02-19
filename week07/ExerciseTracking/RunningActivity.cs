using System;

public class RunningActivity : Activity{
    private double _distance;

    public RunningActivity(DateTime date, int duration, bool isMile, double distance) : base(date, duration, isMile){
        _distance = distance;
    }

    public override double GetDistance(){
        return _distance;
    }

    public override double GetSpeed(){
        return (GetDistance()/_activityDuration) * 60;
    }

    public override double GetPace(){
        return _activityDuration / GetDistance();
    }

    public override string GetSummary(){
        return $"{_date},Running,{_activityDuration},{GetDistance()},{GetSpeed()},{GetPace()},{IsMile()}";
    }
}