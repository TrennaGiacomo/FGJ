using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private ScreenLayouter _layouter;

    [SerializeField] private ScrollableGraphicsContainer _scrollableGraphics;


    [SerializeField] private float _screenWidth;

    [SerializeField] private float _scrollDuration = 1f;

    private int _screenIndex;
    private bool _moving;

    private void Start()
    {
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

        _moving = true;

        var scrollAmount = -_screenWidth;
        _layouter.Scroll(scrollAmount, _scrollDuration, callback: () =>
        {
            _moving = false;
            _screenIndex++;
        });

        // Graphics need to scroll in the opposite direction,
        // since they "move" relative to the screens
        _scrollableGraphics.Scroll(-scrollAmount, _scrollDuration);
    }
}
