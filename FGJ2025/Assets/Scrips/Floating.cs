using UnityEngine;
using DG.Tweening;

public class Floating : MonoBehaviour
{
    float animationOffset = 1f;
    float duration = 1.5f;
    DraggableBubble draggableBubble;
    Tween floatingTween;
    Vector3 startingPos;

    private void Start()
    {
        startingPos = transform.position;
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

    public void StartFloating()
    {
        floatingTween = transform.DOMove(new Vector3(transform.position.x, transform.position.y + animationOffset, transform.position.z), duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    public void ResetPos()
    {
        transform.position = startingPos;
    }
}