using System.Collections.Generic;
using UnityEngine;

public class ChoiceCreator : MonoBehaviour
{
    public GameObject[] choicePrefabs;

    public Transform creationCenter;

    private List<GameObject> _choices = new();

    public void CreateChoices()
    {
        foreach (GameObject choicePrefab in choicePrefabs)
        {
            Vector3 randomPosition = creationCenter.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
            _choices.Add(Instantiate(choicePrefab, randomPosition, creationCenter.rotation));
        }
    }

    public void ClearChoices()
    {
        foreach(var choice in _choices)
        {
            Destroy(choice);
        }

        _choices.Clear();
    }
}
