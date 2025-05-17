using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        // Part 1 -  Load scriptures from the text file! 
        ScriptureLibrary library = new ScriptureLibrary("scriptures.txt");
        Scripture scripture = library.GetRandomScripture();

        // Part 2 - Ask the user how many words to hide per round 
        Console.WriteLine("Welcome to Scripture Memorizer Program!");
        Console.Write("How many words do you want to hide per round? ");
        int wordsPerRound = int.TryParse(Console.ReadLine(), out int n) ? n : 3;

        // Prepare If etc ..

        Console.WriteLine("\nPress [ENTER] to start memorizing. Type 'quit' to exit.");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nThe entire scripture has been hidden. Program ending.");
                break;
            }

            Console.Write("\nPress ENTER to continue or type 'quit' to exit: ");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit") break;

            scripture.HideRandomWords(wordsPerRound);

            Console.WriteLine("Please wait 1 second...");
            Thread.Sleep(1000); // Optional delay to help with memorization >D
        }
    }
}

// This program helps users memorize scriptures by hiding random words from a passage each round


// Extra Features Add:

// I mixed the Bible + BOM 
//- User chooses how many words to hide per round
//- Timer delay added to aid memorization
//- Loads multiple scriptures from an external file (scriptures.txt)
//- Random scripture selection
//- Uses encapsulation with multiple classes (Reference, Word, Scripture, ScriptureLibrary)