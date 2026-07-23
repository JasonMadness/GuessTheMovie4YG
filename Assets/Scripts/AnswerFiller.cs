using System.Collections.Generic;
using UnityEngine;

public class AnswerFiller : MonoBehaviour
{
    [SerializeField] private LetterButton _answerButtonPrefab;
    [SerializeField] private Transform _container;

    private char[] _englishAlphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private char[] _russianAlphabet = "абвгдежзиклмнопрстуфхцчшщъыьэюя".ToCharArray();

    public void Fill(char[] letters)
    {
        List<LetterButton> allButtons = new();
        allButtons.AddRange(GetRightButtons(letters));
        char[] randomLetters = GetRandomLetters(letters); 
        allButtons.AddRange(GetWrongButtons(randomLetters));

        for (int i = 0; i < allButtons.Count;)
        {
            int random = Random.Range(0, allButtons.Count);
            var currentButton = allButtons[random];
            currentButton.transform.SetParent(_container);
            currentButton.transform.localScale = Vector3.one;
            allButtons.Remove(currentButton);
        }
    }

    public void Clear()
    {
        foreach (Transform child in _container)
        {
            Destroy(child.gameObject);
        }
    }

    private char[] GetRandomLetters(char[] letters)
    {
        char[] alphabet = _russianAlphabet;
        int randomLettersCount = letters.Length <= 10 ? 20 - letters.Length : 30 - letters.Length;
        char[] result = new char[randomLettersCount];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = alphabet[Random.Range(0, alphabet.Length)];
        }

        return result;
    }

    private List<LetterButton> GetRightButtons(char[] letters)
    {
        return GenerateButtons(letters, true);
    }

    private List<LetterButton> GetWrongButtons(char[] letters)
    {
        return GenerateButtons(letters, false);
    }

    private List<LetterButton> GenerateButtons(char[] letters, bool rightLetter)
    {
        List<LetterButton> result = new();

        for (int i = 0; i < letters.Length; i++)
        {
            var answerButton = Instantiate(_answerButtonPrefab);
            answerButton.SetText(char.ToUpper(letters[i]));

            if (rightLetter)
            {
                answerButton.SetRight();
                answerButton.name = "RightButton";
            }
            else
            {
                answerButton.name = "WrongButton";
            }

            result.Add(answerButton);
        }

        return result;
    }
}
