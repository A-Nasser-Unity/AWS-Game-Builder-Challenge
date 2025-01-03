using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    private void Start()
    {
        // Show the cursor at start
        ShowCursor();
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}