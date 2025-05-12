using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class Journal
{
    private List<Entry> _entries;
    private PromptGenerator _promptGenerator;

    public Journal()
    {
        _entries = new List<Entry>();
        _promptGenerator = new PromptGenerator(); // To follow an order of prompts
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
            Console.WriteLine($"Question   : {entry._promptText}");
            Console.WriteLine($"My entry   : {entry._entryText}");
            Console.WriteLine("------------------------------");
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            outputFile.WriteLine("Date,Prompt,Entry");

            foreach (Entry entry in _entries)
            {
                string cleanEntry = $"{entry._date},{EscapeCsv(entry._promptText)},{EscapeCsv(entry._entryText)}";
                outputFile.WriteLine(cleanEntry);
            }
        }

        Console.WriteLine("Entries saved successfully in CSV format.");
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

        foreach (string line in lines.Skip(1)) // Skip header...
        {
            string[] parts = SplitCsvLine(line);

            if (parts.Length == 3)
            {
                Entry entry = new Entry
                {
                    _date = parts[0].Trim(),
                    _promptText = UnescapeCsv(parts[1].Trim()),
                    _entryText = UnescapeCsv(parts[2].Trim())
                };
                _entries.Add(entry);
            }
        }

        Console.WriteLine("Entries loaded successfully from CSV!");
    }

    // Helper to escape commas and quotes!
    private string EscapeCsv(string input)
    {
        if (input.Contains(",") || input.Contains("\""))
        {
            return $"\"{input.Replace("\"", "\"\"")}\"";
        }
        return input;
    }

    // Helper to unescape CSV!
    private string UnescapeCsv(string input)
    {
        if (input.StartsWith("\"") && input.EndsWith("\""))
        {
            return input.Substring(1, input.Length - 2).Replace("\"\"", "\"");
        }
        return input;
    }


    private string[] SplitCsvLine(string line)
    {
        var result = new List<string>();
        bool insideQuotes = false;
        string current = "";

        foreach (char c in line)
        {
            if (c == ',' && !insideQuotes)
            {
                result.Add(current);
                current = "";
            }
            else if (c == '\"')
            {
                insideQuotes = !insideQuotes;
                current += c;
            }
            else
            {
                current += c;
            }
        }

        result.Add(current);
        return result.ToArray();
    }
}
