using UnityEngine;

[System.Serializable]
public abstract class Question
{
    [SerializeField] protected string _russianAnswer;
    [SerializeField] protected string _englishAnswer;
    private string _defaultAnswer = "Default";

    public char[] GetAnswerLetters(string language)
    {
        if (language.ToLower() == "rus")
            return _russianAnswer.ToCharArray();
        if (language.ToLower() == "eng")
            return _englishAnswer.ToCharArray();
        return _defaultAnswer.ToCharArray();
    }
}