using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LetterSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text _text;

    private char _letter;
    private LetterButton _sourceButton;
    private System.Action<LetterSlot> _onClick;

    public bool IsEmpty => _sourceButton == null;

    public void Initialize(System.Action<LetterSlot> onClick)
    {
        _onClick = onClick;
        ClearVisual();
    }

    public void SetLetter(char letter, LetterButton sourceButton)
    {
        _letter = letter;
        _sourceButton = sourceButton;
        _text.text = char.ToUpper(letter).ToString();
        _text.enabled = true;
    }

    public void ReturnLetter()
    {
        if (_sourceButton != null)
            _sourceButton.SetInteractable(true);

        _sourceButton = null;
        _letter = '\0';
        ClearVisual();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _onClick?.Invoke(this);
    }

    private void ClearVisual()
    {
        _text.text = string.Empty;
        _text.enabled = false;
    }
}