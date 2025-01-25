using UnityEngine;

public class UncertaintyLogic : ScreenLogic
{
    public float uncertainSensitivity = 0.1f;
    private float initialSensitivity;
    private CustomCursor cursor;

    public override void CleanUp()
    {
        cursor.sensitivity = initialSensitivity;
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        cursor = FindFirstObjectByType<CustomCursor>();
        initialSensitivity = cursor.sensitivity;
        cursor.sensitivity = uncertainSensitivity;

        choiceCreator.CreateChoices();
    }
}
