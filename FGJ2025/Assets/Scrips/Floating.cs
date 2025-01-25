using UnityEngine;
using DG.Tweening;

public class Floating : MonoBehaviour
{
    float animationOffset = 1f;
    float duration = 1.5f;
    DraggableBubble draggableBubble;
    Tween floatingTween;

    private void Start()
    {
        draggableBubble = GetComponent<DraggableBubble>();
        StartFloating();
    }

    private void Update()
    {
        if (draggableBubble.isDragging && floatingTween.IsPlaying())
        {
            floatingTween.Pause();
            floatingTween.Kill();
        }
        else
            if (floatingTween == null || !floatingTween.IsPlaying())
            StartFloating();
    }

    private void StartFloating()
    {
        floatingTween = transform.DOMove(new Vector3(transform.position.x, transform.position.y + animationOffset, transform.position.z), duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }
}