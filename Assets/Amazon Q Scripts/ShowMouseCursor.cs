using UnityEngine;

public class ShowMouseCursor : MonoBehaviour
{
    void Start()
    {
        // Show cursor and make it interactive
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}