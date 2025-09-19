using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();
    

        var splitWords = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        _words = new List<Word>();

        foreach (var wordText in splitWords)
        {
            _words.Add(new Word(wordText));
        }
    }
    public void HideRandomWords(int numberToHide)
    {
        List<int> visibleWordIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {

            if (!_words[i].IsHidden)
            {
                visibleWordIndexes.Add(i);
            }
        }

        for (int i = visibleWordIndexes.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            int temp = visibleWordIndexes[i];
            visibleWordIndexes[i] = visibleWordIndexes[j];
            visibleWordIndexes[j] = temp;
        }

        for (int i = 0; i < Math.Min(numberToHide, visibleWordIndexes.Count); i++)
        {
            _words[visibleWordIndexes[i]].Hide();
        }
    }

    public bool isCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden)
            {
                return false;
            }
        }
        return true;
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.ConvertAll(w => w.GetDisplayText()));
        return $"{referenceText} {wordsText}";
    }
}