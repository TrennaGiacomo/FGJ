using TMPro;
using UnityEngine;

public class DebugCanvas : MonoBehaviour
{
    public TMP_Text debugText;
    public void DebugScreen(ScreenRoot screen)
    {
        debugText.text = $"Problem: {screen.problem.problemType}";
    }
}
