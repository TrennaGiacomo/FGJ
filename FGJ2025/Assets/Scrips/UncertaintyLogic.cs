using UnityEngine;

public class UncertaintyLogic : ScreenLogic
{
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
        OnComplete.Invoke();
    }
}
