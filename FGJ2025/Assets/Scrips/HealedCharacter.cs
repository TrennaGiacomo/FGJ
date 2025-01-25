using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HealedCharacter : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private int _animIdIsWalking;

    private float startPosX;

    private void Start()
    {
        _animIdIsWalking = Animator.StringToHash("IsWalking");
        startPosX = transform.position.x;
    }

    public void StartWalking()
    {
        _animator.SetBool(_animIdIsWalking, true);
    }

    public void StopWalking()
    {
        _animator.SetBool(_animIdIsWalking, false);
    }

    public void RunOffAndOnScreen(float duration)
    {
        StartWalking();

        var halfDuration = duration / 2f;
        DOTween.Sequence()
            .Append(transform.DOMoveX(startPosX + 7, halfDuration))
            .AppendInterval(1f)
            .Append(transform.DOMoveX(startPosX, halfDuration - 0.1f))
            .SetEase(Ease.Linear);

        StartCoroutine(WaitToStopWalking());
    }

    private IEnumerator WaitToStopWalking()
    {
        yield return new WaitForSeconds(1f);
        StopWalking();
    }
}
