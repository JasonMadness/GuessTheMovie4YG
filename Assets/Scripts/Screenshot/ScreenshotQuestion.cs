using UnityEngine;

public class ScreenshotQuestion : Question
{
    [SerializeField] private Sprite _screenshot;

    public Sprite GetScreenShot() => _screenshot;
}