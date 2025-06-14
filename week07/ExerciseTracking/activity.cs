using System;
using System.Collections.Generic;

public enum UnitSystem
{
    Miles,
    Kilometers
}

public abstract class Activity
{
    private DateTime _date;
    private int _minutes;
    protected UnitSystem _unitSystem;

    protected const double MilesPerKilometer = 0.621371;
    protected const double KilometersPerMile = 1.60934;
    protected const double MetersPerLap = 50.0;
    protected const double MetersPerKilometer = 1000.0;

    public Activity(DateTime date, int minutes, UnitSystem unitSystem)
    {
        if (minutes <= 0)
        {
            throw new ArgumentException("Minutes Always must be a positive value for an activity", nameof(minutes));
        }

        _date = date;
        _minutes = minutes;
        _unitSystem = unitSystem;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public abstract string ActivityTypeName { get; }

    public virtual string GetSummary()
    {
        string formattedDate = _date.ToString("MMM dd yyyy");

        string distanceUnit = (_unitSystem == UnitSystem.Miles) ? "miles" : "km";
        string speedUnit = (_unitSystem == UnitSystem.Miles) ? "mph" : "kph";
        string paceUnit = (_unitSystem == UnitSystem.Miles) ? "min per mile" : "min per km";

        double distance = GetDistance();
        double speed = GetSpeed();
        double pace = GetPace();

        string distanceStr = double.IsNaN(distance) || double.IsInfinity(distance) ? "N/A" : $"{distance:F1} {distanceUnit}";
        string speedStr = double.IsNaN(speed) || double.IsInfinity(speed) ? "N/A" : $"{speed:F1} {speedUnit}";
        string paceStr = double.IsNaN(pace) || double.IsInfinity(pace) ? "N/A" : $"{pace:F1} {paceUnit}";

        return $"{formattedDate} {ActivityTypeName} ({_minutes} min): Distance {distanceStr}, Speed {speedStr}, Pace: {paceStr}";
    }
}

public class Running : Activity
{
    private double _recordedDistanceMiles;

    public Running(DateTime date, int minutes, double recordedDistanceMiles, UnitSystem unitSystem)
        : base(date, minutes, unitSystem)
    {
        if (recordedDistanceMiles < 0)
        {
            throw new ArgumentException("Distance cannot be negative.", nameof(recordedDistanceMiles));
        }
        _recordedDistanceMiles = recordedDistanceMiles;
    }

    public override string ActivityTypeName => "Running";

    public override double GetDistance()
    {
        return (_unitSystem == UnitSystem.Miles) ? _recordedDistanceMiles : _recordedDistanceMiles * KilometersPerMile;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (distance == 0) return 0.0;
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0.0;
        return Minutes / distance;
    }
}

public class Cycling : Activity
{
    private double _recordedSpeedMph;

    public Cycling(DateTime date, int minutes, double recordedSpeedMph, UnitSystem unitSystem)
        : base(date, minutes, unitSystem)
    {
        if (recordedSpeedMph < 0)
        {
            throw new ArgumentException("Speed cannot be negative", nameof(recordedSpeedMph));
        }
        _recordedSpeedMph = recordedSpeedMph;
    }

    public override string ActivityTypeName => "Cycling";

    public override double GetDistance()
    {
        double currentSpeed = (_unitSystem == UnitSystem.Miles) ? _recordedSpeedMph : _recordedSpeedMph * KilometersPerMile;
        return (currentSpeed * Minutes) / 60;
    }

    public override double GetSpeed()
    {
        return (_unitSystem == UnitSystem.Miles) ? _recordedSpeedMph : _recordedSpeedMph * KilometersPerMile;
    }

    public override double GetPace()
    {
        double currentSpeed = GetSpeed();
        if (currentSpeed == 0) return 0.0;
        return 60 / currentSpeed;
    }
}

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps, UnitSystem unitSystem)
        : base(date, minutes, unitSystem)
    {
        if (laps < 0)
        {
            throw new ArgumentException("Number of laps cannot be negative", nameof(laps));
        }
        _laps = laps;
    }

    public override string ActivityTypeName => "Swimming";

    public override double GetDistance()
    {
        double distanceKm = _laps * MetersPerLap / MetersPerKilometer;
        return (_unitSystem == UnitSystem.Miles) ? distanceKm * MilesPerKilometer : distanceKm;
    }

    public override double GetSpeed()
    {
        double distance = GetDistance();
        if (Minutes == 0 || distance == 0) return 0.0;
        return (distance / Minutes) * 60;
    }

    public override double GetPace()
    {
        double distance = GetDistance();
        if (distance == 0) return 0.0;
        return Minutes / distance;
    }
}
