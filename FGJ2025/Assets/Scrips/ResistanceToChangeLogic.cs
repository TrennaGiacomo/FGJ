using UnityEngine;
using UnityEngine.Events;

public class ResistanceToChangeLogic : ScreenLogic
{
    public UnityEvent OnChangeAccepted;

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
        if (!choiceCreator)
            choiceCreator = GetComponent<ChoiceCreator>();

        choiceCreator.CreateChoices();
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        OnChangeAccepted.Invoke();
    }
}
