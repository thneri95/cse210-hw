using System;
using System.Collections.Generic;

class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "Who inspired me the most today, and why?",
        "What moment made me smile or laugh today?",
        "When did I feel most challenged or uncomfortable today?",
        "What is one thing I take for granted that I appreciated more today?",
        "What insight or realization did I gain today?",
        "What decision or action today made me feel proud?",
        "What would I do differently if I could relive today?",
        "Which part of the day triggered strong emotions, and how did I respond?",
        "In what ways did I show integrity, kindness, or patience today?"
    };

    private List<string> _shuffledPrompts;
    private int _currentIndex = 0;

    public PromptGenerator()
    {
        ShufflePrompts();
    }

    private void ShufflePrompts()
    {
        _shuffledPrompts = new List<string>(_prompts);
        Random rng = new Random();
        int n = _shuffledPrompts.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = _shuffledPrompts[k];
            _shuffledPrompts[k] = _shuffledPrompts[n];
            _shuffledPrompts[n] = value;
        }

        _currentIndex = 0;
    }

    public string GetNextPrompt()
    {
        if (_currentIndex >= _shuffledPrompts.Count)
        {
            ShufflePrompts();
        }

        return _shuffledPrompts[_currentIndex++];
    }
}
