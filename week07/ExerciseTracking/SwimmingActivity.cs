using System;

public class SwimmingActivity : Activity{
    private int _lapsNumber;

    public SwimmingActivity(DateTime date, int duration, bool isMile, int laps) : base(date, duration, isMile){
        _lapsNumber = laps;
    }

    public override double GetDistance(){
        if(IsMile()){
            return (_lapsNumber * 50) / 1609.34;
        }
        return _lapsNumber * 50 / 1000;
    }

    public override double GetSpeed(){
        return (GetDistance() / _activityDuration) * 60 ;
    }

    public override double GetPace(){
        return _activityDuration / GetDistance();
    }

    public int GetLaps(){
        return _lapsNumber;
    }

    public override string GetSummary(){
        return $"{_date},Swimming,{_activityDuration},{GetDistance()},{GetSpeed()},{GetPace()},{IsMile()},{GetLaps()}";
    }
}