using System.Collections;
using DG.Tweening;
using UnityEngine;

public class GhostCursor : MonoBehaviour
{
    private Vector3 _origin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _origin = transform.position;
        StartMovingAround();
    }

    void StartMovingAround()
    {
        DOTween.Sequence()
            .Append(transform.DOMove(GetRandPos(), Random.Range(0.4f, 1f)))
            .SetLoops(-1, LoopType.Incremental);
    }

    Vector3 GetRandPos()
    {
        const float offset = 1f;
        return _origin + new Vector3(Random.Range(-offset, offset), Random.Range(-offset, offset));
    }
}
