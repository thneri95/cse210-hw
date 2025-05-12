using System;
using System.IO;
using System.Collections.Generic;

class Journal
{
    private List<Entry> _entries;
    private PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator(); // To follow an order of prompts! 
    }

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetNextPrompt();

        Console.WriteLine(prompt);
        Console.Write("> ");
        string entryText = Console.ReadLine();

        Entry newEntry = new Entry
        {
            _entryText = entryText,
            _promptText = prompt,
            _date = DateTime.Now.ToShortDateString()
        };

        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries found...");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---\n");

        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"Date       : {entry._date}");
            Console.WriteLine($"Question     : {entry._promptText}");
            Console.WriteLine($"My entry : {entry._entryText}");
            Console.WriteLine("------------------------------");
        }
    }


    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                // Use | as a clear and safe delimiter
                string cleanEntry = $"{entry._date}|{entry._promptText}|{entry._entryText}";
                outputFile.WriteLine(cleanEntry);
            }
        }
        Console.WriteLine("Entries saved successfully.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found...");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0].Trim(),
                    _promptText = parts[1].Trim(),
                    _entryText = parts[2].Trim()
                };
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Entries loaded successfully!");
    }
}
