using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

class Journal
{
    private List<Entry> _entries;
    private PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator();
    }

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine(prompt);
        Console.Write("> ");
        string entryText = Console.ReadLine();

        Console.Write("Optional mood tag (happy, stressed etc): ");
        string mood = Console.ReadLine();

        Entry newEntry = new Entry
        {
            _entryText = entryText,
            _promptText = prompt,
            _date = DateTime.Now.ToShortDateString(),
            _time = DateTime.Now.ToShortTimeString(),
            _moodTag = mood
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
            entry.Display();
        }
    }


    // midle

    public void SaveToCsv(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Time,Prompt,Entry,Mood");
            foreach (Entry entry in _entries)
            {
                string cleanEntry = $"{entry._date},{entry._time},{EscapeCsv(entry._promptText)},{EscapeCsv(entry._entryText)},{EscapeCsv(entry._moodTag)}";
                outputFile.WriteLine(cleanEntry);
            }
        }
        Console.WriteLine("Entries saved successfully in CSV format.");
    }

    public void SaveToJson(string file)
    {
        string jsonString = JsonSerializer.Serialize(_entries);
        File.WriteAllText(file, jsonString);
        Console.WriteLine("Entries saved successfully in JSON format.");
    }

    public void LoadFromCsv(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found...");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines.Skip(1))
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 5)
            {
                Entry entry = new Entry
                {
                    _date = parts[0].Trim(),
                    _time = parts[1].Trim(),
                    _promptText = UnescapeCsv(parts[2].Trim()),
                    _entryText = UnescapeCsv(parts[3].Trim()),
                    _moodTag = UnescapeCsv(parts[4].Trim())
                };
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Entries loaded successfully from CSV!");
    }
    // if not found> > > 
    public void LoadFromJson(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found...");
            return;
        }

        string jsonString = File.ReadAllText(filename);
        _entries = JsonSerializer.Deserialize<List<Entry>>(jsonString);
        Console.WriteLine("Entries loaded successfully from JSON!");
    }

    private string EscapeCsv(string input)
    {
        if (input.Contains(",") || input.Contains("\""))
        {
            return $"\"{input.Replace("\"", "\"\"")}\"";
        }
        return input;
    }

    private string UnescapeCsv(string input)
    {
        if (input.StartsWith("\"") && input.EndsWith("\""))
        {
            return input.Substring(1, input.Length - 2).Replace("\"\"", "\"");
        }
        return input;
    }

    public void SearchByKeyword(string keyword)
    {
        var matches = _entries.Where(e => e._entryText.Contains(keyword, StringComparison.OrdinalIgnoreCase) || e._promptText.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        foreach (var entry in matches)
        {
            entry.Display();
        }
    }
}
