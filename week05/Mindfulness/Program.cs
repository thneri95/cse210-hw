
using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        // Variable:
        string choice = "";

        // Loop:
        while (choice != "5")
        {
            // Clear + Menu: 
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Start gratitude journaling activity"); // New activity implemented
            Console.WriteLine("  5. Quit");
            Console.Write("Select a choice from the menu: ");

            // Read user's input:
            choice = Console.ReadLine();

            // Use a switch statement to handle different choices >>
            switch (choice)
            {
                case "1":
                    BreathingActivity breathingActivity = new BreathingActivity();
                    breathingActivity.Run();
                    break;
                case "2":
                    ReflectionActivity reflectionActivity = new ReflectionActivity();
                    reflectionActivity.Run();
                    break;
                case "3":
                    ListingActivity listingActivity = new ListingActivity();
                    listingActivity.Run();
                    break;
                case "4":
                    GratitudeActivity gratitudeActivity = new GratitudeActivity();
                    gratitudeActivity.Run();
                    break;
                case "5":
                    // Exit MSG: 
                    Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
                    break;
                default:
                    // For invalid inputs:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    // Pause to allow user to read the message :D

                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}

/*
 * Exceeding Requirements:
 * 1- Added a new "Gratitude Journaling Activity" that prompts the user to list gratitude items
 * 2- The Gratitude Journaling Activity saves the user's entries to a text file named "gratitude_log.txt"
 * 3- Enhanced countdown in Activity.ShowCountdown to clear previous numbers more effectively
 * 4- Used Console.Clear() for a cleaner user experience at the start of activities and before displaying questions/prompts
 */