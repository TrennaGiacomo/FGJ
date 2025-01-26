using UnityEngine;

public class ComparingSelfToOthersLogic : ScreenLogic
{
    public string[] badComparisons;

    public string[] badComparisonsSentence;

    private GoodThought winningThought;

    private Character character;

    public override void CleanUp()
    {
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        if (!choiceCreator)
            choiceCreator = GetComponent<ChoiceCreator>();

        character = FindFirstObjectByType<Character>();
            
        choiceCreator.CreateChoices();

        winningThought = FindAnyObjectByType<GoodThought>();
    }

    protected override void OnBadThoughtTriggered(BadThought badThought)
    {
        Debug.Log(badThought, badThought);
        character.SaySomething($"{badComparisons[Random.Range(0, badComparisons.Length)]} {badComparisonsSentence[Random.Range(0, badComparisonsSentence.Length)]}");
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        if (goodThought == winningThought)
        {
            OnComplete.Invoke();
            CleanUp();
        }
    }
}