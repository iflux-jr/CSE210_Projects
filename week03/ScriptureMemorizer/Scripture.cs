using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        foreach (string word in text.Split(' '))
            _words.Add(new Word(word));
    }

    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        int hiddenCount = 0;

        while (hiddenCount < numberToHide)
        {
            int index = rand.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public void RevealRandomWord()
    {
        Random rand = new Random();
        bool revealed = false;

        while (!revealed)
        {
            int index = rand.Next(_words.Count);
            if (_words[index].IsHidden())
            {
                _words[index].Reveal();
                revealed = true;
            }
        }
    }

    public string GetDisplayText()
    {
        List<string> displayedWords = new List<string>();
        foreach (Word w in _words)
            displayedWords.Add(w.GetDisplayText());

        return $"{_reference.GetDisplayText()} - {string.Join(" ", displayedWords)}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
            if (!w.IsHidden()) return false;
        return true;
    }
}
