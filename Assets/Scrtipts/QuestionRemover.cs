using UnityEngine;
using UnityEngine.UI;

public class QuestionRemover : MonoBehaviour
{
    [SerializeField] private Image _sprite;
    [SerializeField] private AnswerFiller _answerFiller;

    public void Clear()
    {
        _sprite.sprite = null;
        _answerFiller.Clear();
    }
}
