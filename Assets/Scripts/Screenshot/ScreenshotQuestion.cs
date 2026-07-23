using UnityEngine;

[System.Serializable]
public class ScreenshotQuestion : Question
{
    [SerializeField] private Sprite _screenshot;

    public Sprite GetScreenShot()
    {
        return _screenshot;
    }
}
