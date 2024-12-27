using UnityEngine;

public class HideMouse : MonoBehaviour
{
    void Start()
    {
        // Lock and hide the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}