using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted; // Current count of completions
    private int _target;          // Required number of completions
    private int _bonusPoints;     // Bonus awarded upon reaching target

    // Constructor starts:
    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints) : base(name, description, points)
    {
        _amountCompleted = 0; // Starts at 0 completions;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    // Constructor for loading from file (includes _amountCompleted, _target, _bonusPoints) : Below
    public ChecklistGoal(string name, string description, int points, int amountCompleted, int target, int bonusPoints) : base(name, description, points)
    {
        _amountCompleted = amountCompleted;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    // Overrides the abstract RecordEvent method from the base class: 
    public override int RecordEvent()
    {
        _amountCompleted++; // How to Increment completion count ? (Fixed)
        int earnedPoints = _points; // Points earned for this single event (Fixed)

        Console.WriteLine($"You have recorded '{_shortName}' and gained {_points} points!");

        if (_amountCompleted == _target)
        {
            earnedPoints += _bonusPoints; // Try to Add bonus if target reached (ok) 
            Console.WriteLine($"Congratulations! You have completed '{_shortName}' {_target} times and earned a bonus of {_bonusPoints} points!");
        }
        else if (_amountCompleted > _target) // <--- Handle case where it's recorded after completion
        {
            Console.WriteLine($"Goal '{_shortName}' was already completed. You gain standard points.");
        }
        // Return total points for this event: Below and fixed
        return earnedPoints;
    }

    // Overrides the virtual GetDetailsString method to show progress and completion status: 
    public override string GetDetailsString()
    {
        string status = _amountCompleted >= _target ? "[X]" : "[ ]";
        return $"{status} {base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }

    // Overrides the abstract GetStringRepresentation for saving
    public override string GetStringRepresentation()
    {
        // My Format: Type:Name,Description,Points,AmountCompleted,Target,BonusPoints
        // Fixed and tested:
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_amountCompleted},{_target},{_bonusPoints}";
    }
}