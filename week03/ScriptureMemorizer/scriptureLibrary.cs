using System;
using System.Collections.Generic;
using System.IO;


// libray brain

public class ScriptureLibrary
{
    private List<Scripture> _scriptures;

    public ScriptureLibrary(string filePath)
    {
        _scriptures = new List<Scripture>();
        LoadScriptures(filePath);
    }

    private void LoadScriptures(string path)
    {
        foreach (var line in File.ReadAllLines(path))
        {
            var parts = line.Split('|');
            if (parts.Length == 5)
            {
                string book = parts[0];
                int chapter = int.Parse(parts[1]);
                int startVerse = int.Parse(parts[2]);
                int endVerse = int.Parse(parts[3]);
                string text = parts[4];

                Reference reference = new Reference(book, chapter, startVerse, endVerse);
                _scriptures.Add(new Scripture(reference, text));
            }
        }
    }

    public Scripture GetRandomScripture()
    {
        if (_scriptures.Count == 0)
        {
            throw new InvalidOperationException("No scriptures loaded from file.");
        }

        Random rand = new Random();
        int index = rand.Next(_scriptures.Count);
        return _scriptures[index];
    }

    public void AddScripture(Reference reference, string text)
    {
        _scriptures.Add(new Scripture(reference, text));
    }
}
