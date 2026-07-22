using System;
using UnityEngine;
using UnityEngine.UI;

public class QuestionFiller : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private Char[] _answer;
    [SerializeField] private LanguageSelector _languageSelector;
    [SerializeField] private AnswerFiller _answerFiller;

    public void Fill(Question question)
    {
        if (question is ScreenshotQuestion screenshotQuestion)
        {
            _sprite.sprite = screenshotQuestion.GetScreenShot();
        }

        string language = _languageSelector.GetCurrentLanguage();
        _answer = question.GetAnswerLetters(language);

        _answerFiller.Fill(_answer);
    }
}
