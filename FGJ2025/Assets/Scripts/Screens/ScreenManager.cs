using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ScreenManager : MonoBehaviour
{
    public UnityEvent<ScreenRoot> OnScreenAppeared = new();

    [SerializeField] private ScreenLayouter _layouter;

    [SerializeField] private ScrollableGraphicsContainer _scrollableGraphics;

    [SerializeField] private float _screenWidth;

    [SerializeField] private float _scrollDuration = 1f;

    private int _screenIndex;

    private List<ScreenRoot> _screens = new();

    private bool _moving;

    private void Start()
    {
        _screens.AddRange(_layouter.Root.GetComponentsInChildren<ScreenRoot>());
        _layouter.ScreenWidth = _screenWidth;
        _layouter.UpdateLayout();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToNextScreen();
        }
    }

    public void MoveToNextScreen()
    {
        if (_moving)
            return;


        if (_screenIndex + 1 == _screens.Count)
        {
            Debug.LogWarning("No more screens.");
            return;
        }

        _moving = true;
        
        var nextScreen = _screens[_screenIndex + 1];

        var scrollAmount = -_screenWidth;
        _layouter.Scroll(scrollAmount, _scrollDuration, callback: () =>
        {
            _moving = false;
            _screenIndex++;

            OnScreenAppeared.Invoke(nextScreen);
        });

        // Graphics need to scroll in the opposite direction,
        // since they "move" relative to the screens
        _scrollableGraphics.Scroll(-scrollAmount, _scrollDuration);
    }
}
