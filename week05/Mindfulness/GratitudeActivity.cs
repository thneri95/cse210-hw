public class GratitudeActivity : Activity
{
    private const string LogFilePath = "gratitude_log.txt"; // File to store gratitude entries

    // Constructor calls the base class constructor
    public GratitudeActivity() : base("Gratitude Journaling Activity", "This activity will help you cultivate gratitude by listing things you are thankful for each day. Your entries will be saved.")
    {
    }

    // Gratitute Brain:
    public void Run()
    {
        DisplayStartingMessage(); // Call common starting message

        Console.WriteLine();
        Console.Write("How many gratitude items would you like to list? (e.g., 3-5): ");
        int numberOfEntries;
        // Ensure valid positive integer input for number of entries:
        while (!int.TryParse(Console.ReadLine(), out numberOfEntries) || numberOfEntries <= 0)
        {
            Console.Write("Invalid input. Please enter a positive whole number: ");
        }

        Console.WriteLine();
        Console.WriteLine("Start listing your gratitude items:");
        Console.WriteLine("(Press Enter after each item. You have " + _duration + " seconds in total.)");

        List<string> gratitudeItems = new List<string>();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        // Loop to collect gratitude entries within the specified duration
        // and up to the requested number of entries
        for (int i = 0; i < numberOfEntries && DateTime.Now < endTime; i++)
        {
            Console.Write($"> Item {i + 1}: ");
            string item = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(item))
            {
                gratitudeItems.Add(item);
            }
            else
            {
                Console.WriteLine("Item cannot be empty. Please try again.");
                i--; // Decrement i to re-prompt for the same item
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {gratitudeItems.Count} gratitude items.");

        // Save the gratitude entries to a file:
        SaveGratitudeEntries(gratitudeItems);

        DisplayEndingMessage(); // Call common ending message
    }

    // Saves the list of gratitude entries to a text file:
    private void SaveGratitudeEntries(List<string> entries)
    {
        try
        {
            // Use 'true' to append to the file if it exists, otherwise create it
            using (StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.WriteLine($"--- Gratitude entries for {DateTime.Now:yyyy-MM-dd HH:mm:ss} ---");
                foreach (string entry in entries)
                {
                    writer.WriteLine($"- {entry}");
                }
                writer.WriteLine(); // Add a blank line for separation:
            }
            Console.WriteLine($"Your gratitude entries have been saved to {LogFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving entries: {ex.Message}");
        }
    }
}