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

    private void Start()
    {
        choiceCreator = GetComponent<ChoiceCreator>();

        FindFirstObjectByType<Character>()
            .detector.OnDraggableTriggered
            .AddListener(OnDraggableTriggered);
    }

    private void OnDraggableTriggered(GameObject draggable)
    {
        GoodThought goodThought = null;
        BadThought badThought = null;

        if (!(draggable.TryGetComponent<GoodThought>(out goodThought)
            || draggable.TryGetComponent<BadThought>(out badThought)))
        {
            return;
        }

        if (goodThought)
        {
            OnGoodThoughtTriggered(goodThought);
        }
        else if (badThought)
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
