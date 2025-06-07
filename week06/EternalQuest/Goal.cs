using System;

// Base class for all types of goals:
public abstract class Goal
{
    // 1 - Protected members are accessible within the class and by derived classes
    // 2 - Private members are only accessible within the defining class
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Constructor for the base Goal class:
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract method: Derived classes MUST implement this
    // This demonstrates polymorphism, as each goal type records an event differently
    public abstract int RecordEvent();

    // Virtual method: Derived classes CAN override this if their display differs:
    // This also demonstrates polymorphism:
    public virtual string GetDetailsString()
    {
        // Default details string includes name and description:
        return $"{_shortName} ({_description})";
    }

    // Abstract method: Derived classes MUST implement this for saving data
    // This is part of the serialization process ( i tried to turning object to string)
    public abstract string GetStringRepresentation();

    // Public getter for points, useful for GoalManager to sum scores:
    public int GetPoints()
    {
        return _points;
    }

    // Public getter for name (useful for selection menus etc)
    public string GetShortName()
    {
        return _shortName;
    }
}