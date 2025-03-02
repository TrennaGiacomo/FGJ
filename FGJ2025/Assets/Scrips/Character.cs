using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public DraggableDetector detector;

    [SerializeField] private Animator _animator;

    private int _animIdIsWalking;

    [SerializeField] private GameObject _speechBubble;

    private Coroutine speakingCoroutine;

    private bool isTalking = false;

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

    public void SaySomething(string something, Action onFinish = null)
    {
        if (speakingCoroutine != null)
        {
            isTalking = false;
            StopCoroutine(speakingCoroutine);
        }

        isTalking = true;
        speakingCoroutine = StartCoroutine(SaySomethingCoroutine(something, onFinish));
    }

    private IEnumerator SaySomethingCoroutine(string something, Action onFinish = null)
    {
        _speechBubble.SetActive(true);
        var text = _speechBubble.GetComponentInChildren<TMP_Text>();
        string output = "";
        while (output.Length < something.Length)
        {
            if (!isTalking)
            {
                _speechBubble.SetActive(false);
                yield break;
            }

            output += something[output.Length];
            text.text = output;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSecondsRealtime(3.0f);
        _speechBubble.SetActive(false);

        if (onFinish != null)
        {
            onFinish.Invoke();
        }
    }
}
