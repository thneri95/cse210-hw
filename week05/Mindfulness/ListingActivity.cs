public class ListingActivity : Activity
{
    // List of prompts for listing
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    // Constructor calls the base class constructor
    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    // Runs the listing activity logic
    public void Run()
    {
        DisplayStartingMessage(); // Call common starting message

        // Get a random prompt
        Random random = new Random();
        string prompt = _prompts[random.Next(_prompts.Count)];
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountdown(5); // Countdown before user starts listing

        Console.WriteLine();
        Console.WriteLine("Start listing items:");

        // Calculate the end time for the activity
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);
        int itemCount = 0;

        // Loop to collect user input until duration is met
        while (DateTime.Now < endTime)
        {

            Console.Write($"> ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item)) // Only count non-empty items
            {
                itemCount++;
            }
        }

        Console.WriteLine($"You listed {itemCount} items.");
        Console.WriteLine();

        DisplayEndingMessage(); // Call common ending message
    }
}