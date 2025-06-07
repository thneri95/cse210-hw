using System;

public class EternalGoal : Goal
{
    // Constructor
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        // No additional member variables needed for EternalGoal beyond base.
    }

    // Overrides the abstract RecordEvent method from the base class
    public override int RecordEvent()
    {
        Console.WriteLine($"You have recorded '{_shortName}' and gained {_points} points!");
        return _points; // Always return points for an eternal goal
    }

    // Uses the default GetDetailsString from the base Goal class, as it doesn't need [X]
    // or any additional progress indicators.

    // Overrides the abstract GetStringRepresentation for saving
    public override string GetStringRepresentation()
    {
        // Format: Type:Name,Description,Points
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}