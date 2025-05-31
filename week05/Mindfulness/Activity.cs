public class Activity
{
    // Protected members to be accessible by derived classes
    protected string _name;
    protected string _description;
    protected int _duration;  // Duration of the activity in seconds

    // Constructor initializes name and description:
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Default constructor for derived classes that set their own name/description:
    public Activity()
    {
        _name = "Generic Activity";
        _description = "This is a generic mindfulness activity.";
    }

    // Displays the common starting message for an activity:
    public void DisplayStartingMessage()
    {
        Console.Clear(); // Clear console for a fresh start
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();

        // Prompt user for duration and ensure it's a valid integer:
        Console.Write("How long, in seconds, would you like for your session? ");
        while (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.Write("Invalid input. Please enter a positive whole number for the duration: ");
        }

        Console.Clear(); // Clear console before starting the activity
        Console.WriteLine("Get ready...");
        ShowSpinner(3); // Pause with a spinner for 3 seconds
    }

    // Displays the common ending message for an activity
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3); // Pause with a spinner for 3 seconds
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(5); // Pause with a spinner for 5 seconds
    }

    // Displays a spinner animation for a given number of seconds:
    public void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;

        // Loop until the specified time has passed:
        while (DateTime.Now < endTime)
        {
            string s = spinnerChars[i];
            Console.Write(s);
            Thread.Sleep(250); // Pause for a quarter second
            Console.Write("\b \b"); // Erase the character by backspacing, writing a space, and backspacing again
            i++;
            if (i >= spinnerChars.Count)
            {
                i = 0; // Reset spinner index xD
            }
        }
    }

    // Displays a countdown animation for a given number of seconds:
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            // Calculate number of digits to clear for multi-digit numbers
            int numDigits = i.ToString().Length;
            Console.Write(i);
            Thread.Sleep(1000); // Pause for 1 second
            // Erase the number by backspacing and writing spaces
            for (int j = 0; j < numDigits; j++)
            {
                Console.Write("\b \b");
            }
        }
    }
}