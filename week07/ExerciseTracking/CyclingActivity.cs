using System;

public class CyclingActivity : Activity{
    private double _speed;

    public CyclingActivity(DateTime date, int duration, bool isMile, double speed) : base(date, duration, isMile){
        _speed = speed;
    }


    public override double GetSpeed(){
        return _speed;
    }

    public override double GetDistance(){
        return (_speed * _activityDuration) / 60;
    }

    public override double GetPace(){
        return 60 / GetSpeed();
    }

    public override string GetSummary(){
        return $"{date},Cycling,{_activityDuration},{GetDistance()},{GetSpeed()},{GetPace()},{IsMile()}";
    }
    
}