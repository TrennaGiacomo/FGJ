using UnityEngine;

public class CustomCursor : MonoBehaviour
{    
    public float sensitivity;

    private Vector2 _cursorPosition;

    private void Start()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        _cursorPosition = mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        MoveWithSensitivity();
    }

    void MoveWithSensitivity()
    {
        float mx = Input.GetAxisRaw("Mouse X") * sensitivity;
        float my = Input.GetAxisRaw("Mouse Y") * sensitivity;

        _cursorPosition += new Vector2(mx, my);

        // Clamp cursor position to screen
        _cursorPosition.x = Mathf.Clamp(_cursorPosition.x, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x);
        _cursorPosition.y = Mathf.Clamp(_cursorPosition.y, Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y);

        transform.position = _cursorPosition;
    }
}
