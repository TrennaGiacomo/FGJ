using UnityEngine;

public class ResistanceToChangeLogic : ScreenLogic
{
    private HealedCharacter healedCharacter;

    public void Start()
    {
        healedCharacter = FindFirstObjectByType<HealedCharacter>();
    }

    public override void CleanUp()
    {
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        choiceCreator.CreateChoices();
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        //Do whatever
    }
}
