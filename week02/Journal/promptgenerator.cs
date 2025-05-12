using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts;
    private int _currentIndex;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {

            // Pertinent questions: 

            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What insight or realization did I gain today?",
            "Which part of the day triggered strong emotions, and how did I respond?",
            "When did I feel most challenged or uncomfortable today?",
            "What is one thing I take for granted that I appreciated more today?",
            "Who inspired me the most today, and why?"
        };
        _currentIndex = 0;
    }

    public string GetRandomPrompt()
    {
        string prompt = _prompts[_currentIndex];
        _currentIndex = (_currentIndex + 1) % _prompts.Count;
        return prompt;
    }
}

// I believe that for journaling purposes, if the questions followed a fixed order instead of being randomly generated, the end result would be better.

// During testing, I noticed that the random prompts (called by GetRandomPrompt) repeated frequently, which can frustrate users...
// I believe that a sequential approach (using GetNextPrompt) provides a better journaling experience, ensuring continuity... 

// As requested, I made it Random, but here's a note.
