using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LetterButton : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private Button _button;
    private char _letter;
    private System.Action<char, LetterButton> _onClick;

    public char Letter => _letter;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleClick);
    }

    public void Initialize(char letter, System.Action<char, LetterButton> onClick)
    {
        _letter = letter;
        _text.text = char.ToUpper(letter).ToString();
        _onClick = onClick;
    }

    public void SetInteractable(bool value)
    {
        _button.interactable = value;
    }

    private void HandleClick()
    {
        _onClick?.Invoke(_letter, this);
    }
}