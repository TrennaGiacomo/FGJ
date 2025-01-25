using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChoiceCreator : MonoBehaviour
{
    public UnityEvent OnChoicesCreated = new();
    public GameObject goodThoughtPrefab;
    public GameObject badThoughtPrefab;

    public Transform creationCenter;

    private List<GameObject> thoughts = new();

    public string goodThoughtText;
    public string[] badThoughts;
    const float randOffset = 1.5f;

    public void CreateChoices()
    {
        Vector3 randomPosition;
        foreach (var thought in badThoughts)
        {
            thoughts.Add(CreateBadThought(thought).gameObject);
        }

        randomPosition = GetRandomPosition();
        thoughts.Add(CreateGoodThought(goodThoughtText).gameObject);

        OnChoicesCreated.Invoke();
    }

    public GoodThought CreateGoodThought(string text)
    {
        var randomPosition = GetRandomPosition();
        var goodThought = Instantiate(goodThoughtPrefab, randomPosition, creationCenter.rotation);

        var component = goodThought.GetComponent<GoodThought>();
        component.SetText(goodThoughtText);

        return component;
    }

    public BadThought CreateBadThought(string thought)
    {
        var randomPosition = GetRandomPosition();
        var badThought = Instantiate(badThoughtPrefab, randomPosition, creationCenter.rotation);

        var component = badThought.GetComponent<BadThought>();
        component.SetText(thought);
        return component;
    }

    private Vector3 GetRandomPosition()
    {
        return creationCenter.position
            + new Vector3(Random.Range(-randOffset, randOffset),
                Random.Range(-randOffset, randOffset));
    }

    public void ClearChoices()
    {
        foreach (var choice in thoughts)
        {
            Destroy(choice);
        }

        thoughts.Clear();
    }
}
