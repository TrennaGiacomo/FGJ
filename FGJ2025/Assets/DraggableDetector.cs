using UnityEngine;
using UnityEngine.Events;

public class DraggableDetector : MonoBehaviour
{
    public UnityEvent<GameObject> OnDraggableTriggered;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.gameObject.TryGetComponent<DragSprite>(out var draggable))
            return;
        
        OnDraggableTriggered.Invoke(draggable.gameObject);
    }
}
