using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ScrollableGraphic : MonoBehaviour
{
    [SerializeField] private Renderer _scrollableRenderer;

    [SerializeField] private float _scrollFactor = 1;

    public void Scroll(float amount, float duration)
    {
        if (!_scrollableRenderer || !_scrollableRenderer.material)
            return;

        _scrollableRenderer.material.DOKill();

        var texScale = _scrollableRenderer.material.mainTextureScale;
        var currentOffset = _scrollableRenderer.material.mainTextureOffset;

        var normalizedOffset = _scrollFactor * amount / texScale.x;

        var targetOffset = currentOffset + new Vector2(normalizedOffset, 0);

        _scrollableRenderer.material
            .DOOffset(endValue: targetOffset, duration)
            .SetEase(Ease.Linear);
    }
}
