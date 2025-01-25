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
        choiceCreator.CreateChoices();

        //var numThoughts = othersAttributes.Length;

        // (int i = 0; i < numThoughts; i++)
        //{
        //    choiceCreator.CreateBadThought(othersAttributes[i], i);
        //}

        correctThought = choiceCreator.CreateGoodThought(selfAttribute);
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
