using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterBag : MonoBehaviour
{
    [SerializeField] private GameController _gameController;
    public List<Letter> _letters = new List<Letter>();
    public int numberOfLetters = 0;

    public void TakeLetters(List<Letter> outerLetters)
    {
        _letters = outerLetters;
        numberOfLetters = _letters.Count;
    }

    public void RemoveLetter()
    {
        _letters.Remove(_letters[0]);
        numberOfLetters--;
        if (numberOfLetters == 0)
        {
            _gameController.EndDay();
        }
    }
}
