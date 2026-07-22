using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private AllScreenshotQuestions _allScreenshotQuestions;

    [SerializeField] private QuestionFiller _questionFiller;

    private List<Question> _currentQuestions;

    private void Start()
    {
        _currentQuestions = _allScreenshotQuestions.GetAllQuestions();
        Question randomQuestion = _currentQuestions[Random.Range(0, _currentQuestions.Count)];
        _questionFiller.Fill(randomQuestion);
    }
}
