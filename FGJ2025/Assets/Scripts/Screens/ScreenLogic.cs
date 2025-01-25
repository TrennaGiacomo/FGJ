using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ChoiceCreator))]
/// <summary>
/// The GAMEPLAY functionality of a screen
/// </summary>
public abstract class ScreenLogic : MonoBehaviour
{
    public UnityEvent OnComplete { get; } = new();

    protected ChoiceCreator choiceCreator;

    public bool isActive { get; set; }

    private void Start()
    {
        choiceCreator = GetComponent<ChoiceCreator>();

        FindFirstObjectByType<Character>()
            .detector.OnDraggableTriggered
            .AddListener(OnDraggableTriggered);
    }

    protected void OnDraggableTriggered(GameObject draggable)
    {
        if (!isActive)
            return;

        if (draggable.TryGetComponent<GoodThought>(out var goodThought))
        {
            OnGoodThoughtTriggered(goodThought);
        }
        
        else if (draggable.TryGetComponent<BadThought>(out var badThought))
        {
            OnBadThoughtTriggered(badThought);
        }
    }

    protected virtual void OnGoodThoughtTriggered(GoodThought goodThought)
    {
        Debug.Log("Good thought!");
    }

    protected virtual void OnBadThoughtTriggered(BadThought badThought)
    {
        Debug.Log("Bad thought!");
    }

    public abstract void PlayLogic();

    public abstract void CleanUp();
}
