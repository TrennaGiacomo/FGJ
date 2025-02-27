using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class Heart : MonoBehaviour
{
    private float originalScale;
    public float maxScale = 0.14f;
    public float beatDuration = 0.2f;
    public float pauseDuration = 0.5f;

    [SerializeField] private List<Sprite> heartSprites = new();

    private Sequence heartbeatSequence;
    private int heartIndex = 0;

    void Start()
    {
        SetHeartSprite();
        originalScale = transform.localScale.x;

        heartbeatSequence = DOTween.Sequence()
            .Append(transform.DOScale(maxScale, beatDuration).SetEase(Ease.OutQuad))
            .Append(transform.DOScale(originalScale, beatDuration).SetEase(Ease.InQuad))
            .AppendInterval(pauseDuration)
            .SetLoops(-1, LoopType.Restart);
    }

    public void SetHeartSprite()
    {
        GetComponent<SpriteRenderer>().sprite = heartSprites[heartIndex];
        heartIndex++;

        if(heartIndex >= heartSprites.Count)
        {
            heartIndex = heartSprites.Count - 1;
        }
    }
}
