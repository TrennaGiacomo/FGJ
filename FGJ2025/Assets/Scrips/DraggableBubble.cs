using UnityEngine;

public class DraggableBubble : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    public bool isDragging = false;

    private CustomCursor _cursor;

    void Start()
    {
        mainCamera = Camera.main;
        _cursor = FindFirstObjectByType<CustomCursor>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + offset;
    }
    void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (Vector3.Distance(_cursor.transform.position, transform.position) < 1.0f)
        {
            if (Input.GetMouseButtonDown(0))
                OnMouseDown();
                
            if (Input.GetMouseButtonUp(0))
                OnMouseUp();
            
            if (isDragging)
            {
                OnMouseDrag();
            }
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        return _cursor.transform.position;
        
        // Vector3 mouseScreenPosition = Input.mousePosition;
        // mouseScreenPosition.z = Mathf.Abs(mainCamera.transform.position.z);
        // return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}