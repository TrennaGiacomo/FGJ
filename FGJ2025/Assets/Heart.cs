using UnityEngine;
using DG.Tweening;

public class Heart : MonoBehaviour
{
    private float originalScale;
    public float maxScale = 0.14f;
    public float beatDuration = 0.2f;
    public float pauseDuration = 0.5f;

    private Sequence heartbeatSequence;

    void Start()
    {
        originalScale = transform.localScale.x;

        heartbeatSequence = DOTween.Sequence()
            .Append(transform.DOScale(maxScale, beatDuration).SetEase(Ease.OutQuad))
            .Append(transform.DOScale(originalScale, beatDuration).SetEase(Ease.InQuad))
            .AppendInterval(pauseDuration)
            .SetLoops(-1, LoopType.Restart);
    }
}
