using UnityEngine;

public class ComparingSelfToOthersLogic : ScreenLogic
{
    public string[] badComparisons;

    public string[] fakeGoodThoughts;

    public string realGoodThought;

    private GoodThought winningThought;

    public override void CleanUp()
    {
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        var numThoughts = fakeGoodThoughts.Length;

        for (int i = 0; i < numThoughts; i++)
        {
            choiceCreator.CreateGoodThought(fakeGoodThoughts[i]);
        }

        winningThought = choiceCreator.CreateGoodThought(realGoodThought);
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        if (goodThought == winningThought)
        {
            OnComplete.Invoke();
        }
        else
        {
            var randComparison = badComparisons[Random.Range(0, badComparisons.Length)];
            FindFirstObjectByType<Character>().SaySomething(randComparison);
        }
    }
}
