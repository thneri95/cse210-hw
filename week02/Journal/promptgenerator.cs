using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts;
    private int _currentIndex;

    public PromptGenerator()
    {
        _prompts = new List<string>
        {
            "What was the highlight of your day?",
            "What insight or realization did I gain today?",
            "Which part of the day triggered strong emotions, and how did I respond?",
            "When did I feel most challenged or uncomfortable today?",
            "What is one thing I take for granted that I appreciated more today?",
            "Who inspired me the most today, and why?",
            "What progress did I make toward my goals today?"
        };

        _currentIndex = 0;
    }

    public string GetNextPrompt()
    {
        if (_currentIndex >= _prompts.Count)
        {
            _currentIndex = 0;
        }

        return _prompts[_currentIndex++];
    }
}
