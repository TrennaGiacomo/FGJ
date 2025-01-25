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
    }

    public abstract void PlayLogic();

    public abstract void CleanUp();
}
