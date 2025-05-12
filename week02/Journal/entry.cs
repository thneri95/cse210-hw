
public class Entry
{
    public string _date;
    public string _time;
    public string _promptText;
    public string _entryText;
    public string _moodTag;

    public void Display()
    {
        Console.WriteLine($"Date      : {_date} {_time}");
        Console.WriteLine($"Question    : {_promptText}");
        Console.WriteLine($"My Entry     : {_entryText}");
        Console.WriteLine($"Mood Tag  : {_moodTag}");
        Console.WriteLine(new string('-', 40));
    }
}
