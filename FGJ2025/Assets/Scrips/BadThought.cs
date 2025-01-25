using TMPro;
using UnityEngine;

public class BadThought : MonoBehaviour
{
    public TMP_Text text;
    public void SetText(string text)
    {
        this.text.text = text;
    }
}
