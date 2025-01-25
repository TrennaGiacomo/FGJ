using UnityEngine;
using DG.Tweening;
using System;

public class ScreenLayouter : MonoBehaviour
{
    public float ScreenWidth { get; set; }
    public Transform Root => ScreenRoot;
    
    [SerializeField] protected Transform ScreenRoot;
    [SerializeField] protected float ScrollDuration = 1f;

    public void UpdateLayout()
    {
        var screens = ScreenRoot.GetComponentsInChildren<ScreenRoot>();
        for (int i = 0; i < screens.Length; i++)
        {
            var screen = screens[i];
            var screenPos = screen.transform.position;
            var offset = ScreenWidth * i;

            screens[i].transform.localPosition = new Vector3(offset, screenPos.y, screenPos.z);
        }
    }

    public virtual void Scroll(float amount, float duration, Action callback = null)
    {
        var nextRootPos = ScreenRoot.transform.position.x + amount;

        ScreenRoot.transform.DOKill();
        ScreenRoot.transform.DOMoveX(endValue: nextRootPos, 
            duration: duration).SetEase(Ease.Linear)
            .OnComplete(() => { callback?.Invoke(); });
    }
}
