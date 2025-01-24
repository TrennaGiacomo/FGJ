using UnityEngine;
using DG.Tweening;

public class ScrollableGraphic : MonoBehaviour
{
    [SerializeField] private Renderer _scrollableRenderer;

    [SerializeField] private float _scrollFactor = 1;

    private float _offset;

    public void Scroll(float amount, float duration)
    {
        if (!_scrollableRenderer || !_scrollableRenderer.material)
            return;

        _offset += amount;
        
        var texScale = _scrollableRenderer.material.mainTextureScale;
        var texOffset = _scrollableRenderer.material.mainTextureOffset;
        var targetOffset = texOffset + _scrollFactor * _offset * Vector2.right;
        targetOffset.x /= texScale.x;
        Debug.Log(targetOffset);
        _scrollableRenderer.material
            .DOOffset(endValue: targetOffset, duration)
            .SetEase(Ease.Linear);
    }
}
