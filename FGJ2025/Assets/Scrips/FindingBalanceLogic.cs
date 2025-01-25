using UnityEngine;

public class FindingBalanceLogic : ScreenLogic
{
    public string[] othersAttributes;

    public string selfAttribute;

    private GoodThought correctThought;

    public override void CleanUp()
    {
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        var numThoughts = othersAttributes.Length;

        for (int i = 0; i < numThoughts; i++)
        {
            choiceCreator.CreateGoodThought(othersAttributes[i]);
        }

        correctThought = choiceCreator.CreateGoodThought(selfAttribute);
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        if (goodThought == correctThought)
        {
            OnComplete.Invoke();
        }
        else
        {
            FindFirstObjectByType<Character>()
                .SaySomething($"{goodThought.text.text} doesn't quite feel like me");
        }
    }
}
