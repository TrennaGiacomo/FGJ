using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TextManager : MonoBehaviour
{
    [SerializeField] private List<string> screenNames = new();
    public TextMeshProUGUI screenNameText;
    private int i = 1;

    public void UpdateScreenName()
    {
        screenNameText.text = screenNames[i];
        i++;

        if (i >= screenNames.Count)
        {
            i = screenNames.Count - 1;
        }
    }

    public void SetStringToEmpty()
    {
       screenNameText.text = "";
    }
}
