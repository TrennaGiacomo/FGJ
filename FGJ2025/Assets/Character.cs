using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private GameObject _thoughtBubble;

    public UnityEvent<ProblemChoice> OnChoiceMade = new();

    public void GetChoiceFromDraggable(GameObject draggable)
    {
        if (!draggable.TryGetComponent<ProblemChoice>(out var choice))
        {
            Debug.LogWarning("dragable not have a de broblemchoic");
            return;
        }
        
        OnChoiceMade.Invoke(choice);
    }

    public void StartThinking()
    {
        _thoughtBubble.SetActive(true);
    }

    public void StopThinking()
    {
        _thoughtBubble.SetActive(false);
    }

    public void StartWalking()
    {

    }

    public void StopWalking()
    {

    }
}
