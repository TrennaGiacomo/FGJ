using System.Collections.Generic;
using UnityEngine;

public class ScrollableGraphicsContainer : MonoBehaviour
{
    private List<ScrollableGraphic> _graphics = new();

    private void Start()
    {
        _graphics.AddRange(GetComponentsInChildren<ScrollableGraphic>());
    }

    public void Scroll(float amount, float duration)
    {
        foreach(var g in _graphics)
        {
            g.Scroll(amount, duration);
        }
    }
}
