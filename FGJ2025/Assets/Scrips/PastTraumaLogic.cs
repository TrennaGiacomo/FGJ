using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastTraumaLogic : ScreenLogic
{
    public GameObject ghostCursorPrefab;

    private List<GameObject> ghostCursors = new();

    public override void PlayLogic()
    {
        StartCoroutine(PastTraumaCoroutine());
    }

    private IEnumerator PastTraumaCoroutine()
    {
        yield return null;

        MakeGhostCursors();

        // OnComplete.Invoke();
    }

    private void MakeGhostCursors()
    {
        const int numCursors = 16;

        for (int i = 0; i < numCursors; i++)
        {
            Vector3 randPos = new Vector3(
                Random.Range(-5.0f, 5.0f),
                Random.Range(-5.0f, 5.0f),
                0
            ) + transform.position;

            var cursor = Instantiate(ghostCursorPrefab, randPos, transform.rotation);

            ghostCursors.Add(cursor);
        }
    }

    public override void CleanUp()
    {
        foreach (var gc in ghostCursors)
        {
            Destroy(gc);
        }

        ghostCursors.Clear();
    }
}
