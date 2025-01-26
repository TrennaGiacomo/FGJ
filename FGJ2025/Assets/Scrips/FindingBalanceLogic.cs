using UnityEngine;

public class FindingBalanceLogic : ScreenLogic
{
    public string[] othersAttributes;

    private GoodThought correctThought;

    public override void CleanUp()
    {
        choiceCreator.ClearChoices();
    }

    public override void PlayLogic()
    {
        choiceCreator.CreateChoices();

        correctThought = FindAnyObjectByType<GoodThought>();
    }

    protected override void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        if (goodThought == correctThought)
        {
            OnComplete.Invoke();
            CleanUp();
        }
        else
        {
            FindFirstObjectByType<Character>()
                .SaySomething($"But what about {othersAttributes[Random.Range(0, othersAttributes.Length)]}?");
        }
    }
}