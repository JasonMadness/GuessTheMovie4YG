using System.Collections.Generic;
using UnityEngine;

public class AnswerFiller : MonoBehaviour
{
    [SerializeField] private LetterButton _answerButtonPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private AnswerBoard _answerBoard;

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

    private List<LetterButton> GetRightButtons(char[] letters) => GenerateButtons(letters);
    private List<LetterButton> GetWrongButtons(char[] letters) => GenerateButtons(letters);

    private void OnLetterClicked(char letter, LetterButton button)
    {
        _answerBoard.TryPlaceLetter(letter, button);
    }

    private List<LetterButton> GenerateButtons(char[] letters)
    {
        List<LetterButton> result = new();

        for (int i = 0; i < letters.Length; i++)
        {
            var answerButton = Instantiate(_answerButtonPrefab, _container);
            answerButton.Initialize(letters[i], OnLetterClicked);
            result.Add(answerButton);
        }

        return result;
    }
}
