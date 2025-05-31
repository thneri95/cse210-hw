public class BreathingActivity : Activity
{
    // Constructor calls the base class constructor:
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Runs the breathing activity logic:
    public void Run()
    {
        DisplayStartingMessage(); // Call common starting message 

        // Calculate the end time for the activity:
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        // Loop until the duration is met:
        while (DateTime.Now < endTime)
        {
            Console.Write("Breathe in...");
            ShowCountdown(5); // Breathe in 
            Console.WriteLine(); // Move to next line

            Console.Write("Breathe out...");
            ShowCountdown(5); // Breathe out 
            Console.WriteLine(); // Move to next line
            Console.WriteLine(); // Add an extra line for spacing
        }

        DisplayEndingMessage(); // Call common ending message
    }
}