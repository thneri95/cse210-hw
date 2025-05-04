using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcomeMessage();

        string userName = PromptUserName();
        int userNumber = PromptUserNumber();

        int squaredNumber = SquareNumber(userNumber);

        DisplayResult(userName, userNumber, squaredNumber);

        if (userNumber >= 0)
        {
            double squareRoot = Math.Sqrt(userNumber);
            Console.WriteLine($"{userName}, the square root of your number is {squareRoot:F2}");
        }
        else
        {
            Console.WriteLine("Cannot calculate the square root of a negative number.");
        }

        Console.WriteLine("Thank you for using the program!");
    }

    // Greets + current data/time
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
        Console.WriteLine($"Today's date is {DateTime.Now.ToShortDateString()} and the current time is {DateTime.Now.ToShortTimeString()}.\n");
    }

    // Prompts the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Ask the user for their favorite number
    static int PromptUserNumber()
    {
        int number;
        bool isValid = false;

        do
        {
            Console.Write("Please enter your favorite number: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out number))
            {
                isValid = true;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        } while (!isValid);

        return number;
    }

    // Returns the square of f. number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Displays the final result
    static void DisplayResult(string name, int number, int square)
    {
        Console.WriteLine($"\n{name}, your number is {number} and its square is {square}");
    }
}


// Thank you for the opportunity to complete and review these 5 exercises
// It was a valuable learning experience that helped reinforce my understanding of C# and programming fundamentals in general
// I’m grateful for the chance to practice, improve and move closer to becoming a more capable and professional developer.

// May Heavenly Father bless you with wisdom, patience and joy in  all areas of your life!