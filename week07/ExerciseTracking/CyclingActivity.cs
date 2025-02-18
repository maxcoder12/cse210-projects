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
        if (_isMile){
            return $"{date} Cycling ({_activityDuration} min) - Distance: {GetDistance()} miles | Speed: {GetSpeed()} mph | Pace: {GetPace()} min per mile.";
        }
        return $"{date} Cycling ({_activityDuration} min) - Distance: {GetDistance()} km | Speed: {GetSpeed()} kph | Pace: {GetPace()} min per km.";
    }
    
}