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

    public void CreateChoices()
    {
        const float randOffset = 1.5f;
        Vector3 randomPosition;
        foreach (var thought in badThoughts)
        {
            randomPosition = GetRandomPosition(randOffset);
            var badThought = Instantiate(badThoughtPrefab, randomPosition, creationCenter.rotation);
            thoughts.Add(badThought);

            badThought.GetComponent<BadThought>().SetText(thought);
        }

        randomPosition = GetRandomPosition(randOffset);
        var goodThought = Instantiate(goodThoughtPrefab, randomPosition, creationCenter.rotation);
        thoughts.Add(goodThought);

        goodThought.GetComponent<GoodThought>().SetText(goodThoughtText);

        OnChoicesCreated.Invoke();
    }

    private Vector3 GetRandomPosition(float randOffset)
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
