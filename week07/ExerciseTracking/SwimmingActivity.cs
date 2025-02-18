using System;

public class SwimmingActivity : Activity{
    private int _lapsNumber;

    public SwimmingActivity(DateTime date, int duration, bool isMile, int laps) : base(date, duration, isMile){
        _lapsNumber = laps;
    }

    public override double GetDistance(){
        if(_isMile){
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

    public override string GetSummary(){
        if (_isMile){
            return $"{date} Swimming ({_activityDuration} min) - Distance: {GetDistance()} miles | Speed: {GetSpeed()} mph | Pace: {GetPace()} min per mile.";
        }
        return $"{date} Swimming ({_activityDuration} min) - Distance: {GetDistance()} km | Speed: {GetSpeed()} kph | Pace: {GetPace()} min per km.";
    }
}