using System.Collections.Generic;
using UnityEngine;

public class ChoiceCreator : MonoBehaviour
{
    public GameObject[] choicePrefabs;

    public Transform creationCenter;

    private List<GameObject> _choices = new();

    public void CreateChoices()
    {   
        const float randOffset = 1.5f;
        foreach (GameObject choicePrefab in choicePrefabs)
        {
            Vector3 randomPosition = creationCenter.position 
                + new Vector3(Random.Range(-randOffset, randOffset), 
                    Random.Range(-randOffset, randOffset));

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
