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
        return (CalculateDistance()/_activityDuration) * 60;
    }

    public override double GetPace(){
        return _activityDuration / CalculateDistance();
    }

    public override string GetSummary(){
        return $"{date},Cycling,{_activityDuration},{GetDistance()},{GetSpeed()},{GetPace()},{IsMile()}";
    }
}