using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        int choice = 0;
        // Let´s do it! 
        // Start - part 01 -  Menu Lines


        Console.WriteLine("Welcome to the Journal Program!");

        while (choice != 6)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to CSV");
            Console.WriteLine("4. Save entries to JSON");
            Console.WriteLine("5. Load entries from file");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option (1 ~ 6): ");

            // Brain -  Logical code - part 02

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    journal.AddEntry();
                    break;
                case 2:
                    journal.DisplayAll();
                    break;
                case 3:
                    Console.Write("Enter filename to save as (.csv): ");
                    string csvFile = Console.ReadLine();
                    journal.SaveToCsv(csvFile);
                    break;
                case 4:
                    Console.Write("Enter filename to save as (.json): ");
                    string jsonFile = Console.ReadLine();
                    journal.SaveToJson(jsonFile);
                    break;
                case 5:
                    Console.Write("Enter filename to load: ");
                    string loadFile = Console.ReadLine();
                    if (loadFile.EndsWith(".json"))
                        journal.LoadFromJson(loadFile);
                    else
                        journal.LoadFromCsv(loadFile);
                    break;
                case 6:
                    Console.WriteLine(" Exiting the program... Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again");
                    break;
            }   
        }
    }
}

// Project Conclusion >>>

// Project: W02 Journal Program
// Author: Tiago Borges | BYU- Idaho | BSc Software Development - CSE210 Course Programming with Classes



//  Core Functionalities Implemented:

// - Write a new entry using rotating prompts;
// - Display all journal entries in a clean format;
// - Save & Load journal entries to a file (CSV);
// - Menu-driven navigation between features;

//  Extra Credit – Enhancements Added:

// - Proper CSV save/load with quote/comma handling (EscapeCsv & UnescapeCsv);
// - JSON format support for saving/loading (readable & structured data);
// - Enhanced display formatting with labels (Date, Prompt, My Entry);
// - Time-stamped entries (not just date);
// - Modularized with OOP design: Journal, Entry, PromptGenerator, Program;
// - Robust error handling (file existence check, empty list detection);
// - Clean code with comments and abstractions for clarity;

// Thanks to check my code and support me! 