using UnityEngine;
using System.Collections.Generic;

public class BoundsCheck : MonoBehaviour
{
    [SerializeField] Bounds bounds;
    private List<DraggableBubble> draggableBubbles = new ();

    public void Refresh()
    {
        draggableBubbles.Clear();
        
        foreach (var draggableBubble in FindObjectsByType<DraggableBubble>(FindObjectsSortMode.None))
        {
            draggableBubbles.Add(draggableBubble);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }

    private void Start()
    {
        Refresh();
    }

    private void Update()
    {
        foreach (DraggableBubble draggableBubble in draggableBubbles)
        {
            if (!bounds.Contains(draggableBubble.transform.position))
            {
                draggableBubble.transform.position = new Vector3(
                    Mathf.Clamp(draggableBubble.transform.position.x, bounds.min.x, bounds.max.x),
                    Mathf.Clamp(draggableBubble.transform.position.y, bounds.min.y, bounds.max.y),
                    draggableBubble.transform.position.z
                );
            }
        }
    }
}
