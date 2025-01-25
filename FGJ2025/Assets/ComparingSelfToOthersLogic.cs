using UnityEngine;

public class ComparingSelfToOthersLogic : ScreenLogic
{
    public string[] badComparisons;

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

    protected override void OnBadThoughtTriggered(BadThought badThought)
    {
        var randComparison = badComparisons[Random.Range(0, badComparisons.Length)];
        FindFirstObjectByType<Character>().SaySomething(randComparison);
    }
}
