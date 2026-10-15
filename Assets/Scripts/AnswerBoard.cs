using System.Collections.Generic;
using UnityEngine;

public class AnswerBoard : MonoBehaviour
{
    [SerializeField] private LetterSlot _slotPrefab;
    [SerializeField] private Transform _slotsContainer;

    private readonly List<LetterSlot> _slots = new();
    private char[] _targetAnswer;

    public void Build(char[] answer)
    {
        Clear();
        _targetAnswer = answer;

        for (int i = 0; i < answer.Length; i++)
        {
            var slot = Instantiate(_slotPrefab, _slotsContainer);
            slot.Initialize(OnSlotClicked);
            _slots.Add(slot);
        }
    }

    public void TryPlaceLetter(char letter, LetterButton button)
    {
        foreach (var slot in _slots)
        {
            if (slot.IsEmpty)
            {
                slot.SetLetter(letter, button);
                button.SetInteractable(false);
                CheckIfFull();
                return;
            }
        }
    }

    private void OnSlotClicked(LetterSlot slot)
    {
        if (slot.IsEmpty) return;

        slot.ReturnLetter();
        CheckIfFull();
    }

    private void CheckIfFull()
    {
        foreach (var slot in _slots)
            if (slot.IsEmpty) return;
    }

    private void Clear()
    {
        foreach (var slot in _slots)
            Destroy(slot.gameObject);
        _slots.Clear();
    }
}