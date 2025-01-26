using UnityEngine;
using UnityEngine.Events;

public class DraggableDetector : MonoBehaviour
{
    public UnityEvent<GameObject> OnDraggableTriggered;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("GoodThought") || col.gameObject.CompareTag("BadThought"))
            OnDraggableTriggered.Invoke(col.gameObject);
    }
}
