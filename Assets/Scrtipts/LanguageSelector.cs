using UnityEngine;

public class LanguageSelector : MonoBehaviour
{
    private string _current;
    private string _russian = "rus";
    private string _english = "eng";

    private void Start()
    {
        SetLanguage();
    }

    public void SetLanguage()
    {
        // заглушка для выбора языка, по умолчанию русский
        _current = _russian;
    }

    public string GetCurrentLanguage()
    {
        return _current;
    }
}
