using UnityEngine;

public class DragSprite : MonoBehaviour
{
    private Vector3 offset;
    private Camera mainCamera;

    void Start()
    {
        // Get the main camera
        mainCamera = Camera.main;
    }

    void OnMouseDown()
    {
        // Calculate the offset between the sprite and the mouse position in world space
        offset = transform.position - GetMouseWorldPosition();
    }

    void OnMouseDrag()
    {
        // Update the sprite position to follow the mouse
        transform.position = GetMouseWorldPosition() + offset;
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;
        // Convert mouse position to world space, assuming the sprite is on the Z = 0 plane
        mouseScreenPosition.z = Mathf.Abs(mainCamera.transform.position.z); // Adjust for camera depth
        return mainCamera.ScreenToWorldPoint(mouseScreenPosition);
    }
}