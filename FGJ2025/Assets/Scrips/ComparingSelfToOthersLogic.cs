using UnityEngine;

public class ComparingSelfToOthersLogic : ScreenLogic
{
    public string[] badComparisons;

    private GoodThought winningThought;

    private Character character;

    public void Start()
    {
        character = FindFirstObjectByType<Character>();
        Debug.Log(character);
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

        winningThought = FindAnyObjectByType<GoodThought>();
    }

    protected override void OnBadThoughtTriggered(BadThought badThought)
    {
        Debug.Log(badThought, badThought);
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        if (goodThought == winningThought)
        {
            OnComplete.Invoke();
            CleanUp();
        }
        else
        {
            character.SaySomething($"{Random.Range(0, badComparisons.Length)} would be better at this");
        }
    }
}