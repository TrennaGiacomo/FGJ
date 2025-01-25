using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _animIdIsWalking;

    private void Start()
    {
        _animIdIsWalking = Animator.StringToHash("IsWalking");
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
