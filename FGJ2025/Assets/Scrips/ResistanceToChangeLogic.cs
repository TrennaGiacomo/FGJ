using UnityEngine;

public class ResistanceToChangeLogic : ScreenLogic
{
    public override void CleanUp()
    {
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        // Final, "ending" logic
    }
}
