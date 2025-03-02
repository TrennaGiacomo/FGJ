using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ScreenManager : MonoBehaviour
{
    public UnityEvent<ScreenRoot> OnScreenAppeared = new();
    public UnityEvent OnBeginScroll;
    public UnityEvent OnEndScroll;
    public UnityEvent OnAllScreensDone = new();

    public HealedCharacter healedBro;

    [SerializeField] private GameObject _initialNoRavineGround;
    [SerializeField] private BridgeAnimation _bridgeAnimation;

    [SerializeField] private ScreenLayouter _layouter;

    [SerializeField] private ScrollableGraphicsContainer _scrollableGraphics;

    [SerializeField] private float _screenWidth;

    [SerializeField] private float _scrollDuration = 1f;

    private int _screenIndex;

    private List<ScreenRoot> _screens = new();

    private bool _moving;

    private Heart heart;
    private TextManager textManager;

    private void Start()
    {
        heart = FindObjectOfType<Heart>();
        textManager = FindObjectOfType<TextManager>();
        _screens.AddRange(_layouter.Root.GetComponentsInChildren<ScreenRoot>());
        _layouter.ScreenWidth = _screenWidth;
        _layouter.UpdateLayout();
    }

    public void MoveToNextScreen()
    {
        if (_moving)
            return;

        if(_screenIndex != 0)
        {
            heart.SetHeartSprite();
        }
        if (_screenIndex + 1 == _screens.Count)
        {
            Debug.LogWarning("No more screens.");
            OnAllScreensDone.Invoke();
            return;
        }

        _moving = true;
        textManager.SetStringToEmpty();

        OnBeginScroll.Invoke();

        var nextScreen = _screens[_screenIndex + 1];

        var scrollAmount = -_screenWidth;

        healedBro.RunOffAndOnScreen(_scrollDuration);

        _bridgeAnimation.Animate(onFinish: () =>
            {
                _layouter.Scroll(scrollAmount, _scrollDuration, callback: () =>
                {
                    _moving = false;
                    textManager.UpdateScreenName();
                    _screenIndex++;

                    OnEndScroll.Invoke();
                    OnScreenAppeared.Invoke(nextScreen);
                });

                // Graphics need to scroll in the opposite direction,
                // since they "move" relative to the screens
                _scrollableGraphics.Scroll(-scrollAmount, _scrollDuration);
            });

    }
}
