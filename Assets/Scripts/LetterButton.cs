using TMPro;
using UnityEngine;

public class LetterButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private bool _isRight = false;

    public void SetText(char letter)
    {
        _text.text = letter.ToString();
    }

    public void SetRight()
    {
        _isRight = true;
    }
}
