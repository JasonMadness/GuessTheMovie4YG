using UnityEngine;

public abstract class Question
{
    [SerializeField] private string _russianAnswer;
    [SerializeField] private string _englishAnswer;
    private string _defaultAnswer = "Default";

    public char[] GetAnswerLetters(string language)
    {
        if (language.ToLower() == "rus")
            return _russianAnswer.ToCharArray();
        else if (language.ToLower() == "eng")
            return _englishAnswer.ToCharArray();
        else
            return _defaultAnswer.ToCharArray();
    }
}
