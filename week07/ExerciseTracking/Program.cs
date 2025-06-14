using System;
using System.Collections.Generic;



public class Program
{
    public static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running(new DateTime(2024, 11, 3), 30, 3.0, UnitSystem.Miles));
        activities.Add(new Cycling(new DateTime(2024, 11, 4), 45, 15.0, UnitSystem.Miles));
        activities.Add(new Swimming(new DateTime(2024, 11, 5), 20, 40, UnitSystem.Miles));

        activities.Add(new Running(new DateTime(2024, 11, 6), 60, 4.66, UnitSystem.Kilometers));
        activities.Add(new Cycling(new DateTime(2024, 11, 7), 50, 18.64, UnitSystem.Kilometers));
        activities.Add(new Swimming(new DateTime(2024, 11, 8), 30, 60, UnitSystem.Kilometers));

        try
        {
            activities.Add(new Running(new DateTime(2024, 11, 9), 0, 1.0, UnitSystem.Miles));
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\nMessage: {ex.Message}");
        }

        Console.WriteLine("\n--- Welcome to Exercise Activity Summaries ---");
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
