using System;
using System.Collections.Generic;
using System.IO;

//  This is my Principal C# File, However I´ll  Run at Program.cs 

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Displays the current player information (score) : 
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\nYou currently have {_score} points.");
    }

    // Main menu loop:
    public void Start()
    {
        // Greating welcome message : 
        Console.WriteLine("█████████████████████████████████████████████████████████████");
        Console.WriteLine("██          Welcome to the Eternal Quest Program!          ██");
        Console.WriteLine("██   Embark on your journey to self-improvement and growth ██");
        Console.WriteLine("█████████████████████████████████████████████████████████████");

        int choice = 0;
        while (choice != 6)
        {
            // Always show score at the top of the menu:
            DisplayPlayerInfo();

            Console.WriteLine("\n--- Menu Options ---");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select an option from the menu: ");

            // Input validation for menu choice:
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("\nThank you for using the Eternal Quest Program. Keep striving!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 6.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a valid number for your menu selection.");
            }
            Console.WriteLine("\nPress any key to continue...");
            // Pause to allow user to read messages:
            Console.ReadKey();
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n--- Create New Goal ---");
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal (one-time completion)");
        Console.WriteLine("  2. Eternal Goal (ongoing, never completes)");
        Console.WriteLine("  3. Checklist Goal (multiple steps to completion, with a bonus)");
        Console.Write("Which type of goal would you like to create? ");
        string goalTypeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points) || points < 0)
        {
            Console.Write("Invalid points value. Please enter a positive whole number: ");
        }

        Goal newGoal = null;
        switch (goalTypeChoice)
        {
            case "1":
                newGoal = new SimpleGoal(name, description, points);
                break;
            case "2":
                newGoal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target;
                while (!int.TryParse(Console.ReadLine(), out target) || target <= 0)
                {
                    Console.Write("Invalid target. Please enter a positive whole number: ");
                }
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonusPoints;
                while (!int.TryParse(Console.ReadLine(), out bonusPoints) || bonusPoints < 0)
                {
                    Console.Write("Invalid bonus points. Please enter a positive whole number: ");
                }
                newGoal = new ChecklistGoal(name, description, points, target, bonusPoints);
                break;
            default:
                // Exit method if invalid type:
                Console.WriteLine("\nThat's not a valid goal type. Please choose 1, 2, or 3");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine($"\nSuccess! Goal '{name}' created.");
    }

    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to display yet. Let's create some!");
            return;
        }

        Console.WriteLine("\n--- Your Goals ---");
        for (int i = 0; i < _goals.Count; i++)
        {
            // Polymorphism: Calls the appropriate GetDetailsString for each goal type:
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\nNo goals to record an event for. Create some goals first!");
            return;
        }

        Console.WriteLine("\n--- Record Event ---");
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames(); // Show only names for selection xD

        Console.Write("Enter the number of the goal: ");
        int goalIndex;
        // Input validation for goal selection:
        if (int.TryParse(Console.ReadLine(), out goalIndex) && goalIndex > 0 && goalIndex <= _goals.Count)
        {
            // Polymorphism in action!
            int pointsEarned = _goals[goalIndex - 1].RecordEvent();
            _score += pointsEarned;
            Console.WriteLine($"You gained {pointsEarned} points. You now have {_score} points in total!");
        }
        else
        {
            Console.WriteLine("Invalid goal number. Please choose a number from the list.");
        }
    }

    private void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename to save your goals to? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                // To Save the current score:
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    // Polymorphism: Calls the appropriate GetStringRepresentation for each goal type!
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"\nGoals saved to '{filename}' successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError saving goals: {ex.Message}. Please try again.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename to load your goals from? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"\nError: File '{filename}' not found. Please check the name and try again.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("\nThe file is empty. No goals to load.");
                return;
            }

            _score = int.Parse(lines[0]); // Load score from the first line
            _goals.Clear(); // Clear existing goals before loading new ones

            for (int i = 1; i < lines.Length; i++) // Loop through goal lines
            {
                string[] parts = lines[i].Split(':'); // Split by type separator (e.g., "SimpleGoal:...")
                string goalType = parts[0];
                string[] goalData = parts[1].Split(','); // Split data part by comma

                Goal loadedGoal = null;
                switch (goalType)
                {
                    case "SimpleGoal":
                        loadedGoal = new SimpleGoal(
                            goalData[0], // name
                            goalData[1], // description
                            int.Parse(goalData[2]), // points
                            bool.Parse(goalData[3]) // isComplete
                        );
                        break;
                    case "EternalGoal":
                        loadedGoal = new EternalGoal(
                            goalData[0], // name
                            goalData[1], // description
                            int.Parse(goalData[2]) // points
                        );
                        break;
                    case "ChecklistGoal":
                        loadedGoal = new ChecklistGoal(
                            goalData[0], // name
                            goalData[1], // description
                            int.Parse(goalData[2]), // points
                            int.Parse(goalData[3]), // amountCompleted
                            int.Parse(goalData[4]), // target
                            int.Parse(goalData[5]) // bonusPoints
                        );
                        break;
                    default:
                        Console.WriteLine($"\nWarning: Unknown goal type '{goalType}' found in file. Skipping this goal.");
                        continue;
                }
                _goals.Add(loadedGoal); // Add the newly created goal to the list
            }
            Console.WriteLine($"\nGoals loaded from '{filename}' successfully!");
            DisplayPlayerInfo(); // Immediately show the loaded score
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError loading goals: {ex.Message}. The file might be corrupted or in an incorrect format.");
            _goals.Clear(); // Clear any partially loaded data on error to prevent inconsistent state
            _score = 0;     // Reset score on error
        }
    }
}