using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _thoughtBubble;

    public UnityEvent<ProblemChoice> OnChoiceMade = new();

    private int _animIdIsWalking;

    private void Start()
    {
        _animIdIsWalking = Animator.StringToHash("IsWalking");
    }

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
        _animator.SetBool(_animIdIsWalking, true);
    }

    public void StopWalking()
    {
        _animator.SetBool(_animIdIsWalking, false);
    }
}
