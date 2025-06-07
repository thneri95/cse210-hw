using System;

//  main entry :

public class Program
{
    public static void Main(string[] args)
    {
        // Create an instance of GoalManager ( I´ll focus on it):
        GoalManager goalManager = new GoalManager();

        // Start the main menu loop


        goalManager.Start();

        /*
        * Exceeding Requirements:
        * 1. Added robust error handling for file saving/loading, including checking for file existence and parsing errors...
        * 2. Improved user experience with more detailed console feedback for actions (e.g., goal creation, event recording messages)
        * 3. Implemented a simple score display update after loading goals
        */
    }
}