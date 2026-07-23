using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AllScreenshotQuestions : MonoBehaviour
{
    [SerializeField] private List<ScreenshotQuestion> _questions;

    public List<Question> GetAllQuestions()
    {
        return _questions.Select(q => (Question)q).ToList();
    }
}
