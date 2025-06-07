using System;

public class SimpleGoal : Goal
{
    // Encapsulated member variable:
    private bool _isComplete;

    // Constructor:
    public SimpleGoal(string name, string description, int points) : base(name, description, points)
    {
        // Simple goals are not complete when first created, 1st:
        _isComplete = false;
    }

    // Constructor for loading from file (includes _isComplete state): 
    public SimpleGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    // Overrides the abstract RecordEvent method from the base class: 
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            // Mark as complete (x):
            _isComplete = true;
            Console.WriteLine($"Congratulations! You have completed '{_shortName}' and gained {_points} points!");
            // Return points for this event:
            return _points;
        }
        else
        {
            Console.WriteLine($"Goal '{_shortName}' is already complete.");
            // No points if already complete:
            return 0;
        }
    }

    // Overrides the virtual GetDetailsString method to show completion status:
    public override string GetDetailsString()
    {
        string status = _isComplete ? "[X]" : "[ ]";
        // Calls base implementation and adds status:
        return $"{status} {base.GetDetailsString()}";
    }

    // Overrides the abstract GetStringRepresentation for saving: (Fixed)
    public override string GetStringRepresentation()
    {
        // Format: Type:Name,Description,Points,IsComplete...
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}