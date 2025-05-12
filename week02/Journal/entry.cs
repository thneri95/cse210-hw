class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date       : {_date}");
        Console.WriteLine($"Question   : {_promptText}");
        Console.WriteLine($"My entry   : {_entryText}");
        Console.WriteLine("------------------------------");
    }
}
