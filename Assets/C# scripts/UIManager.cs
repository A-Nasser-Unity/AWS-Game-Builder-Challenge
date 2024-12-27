using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject uiPanel;  // Reference to your UI panel
    public GameObject targetObject;  // Reference to the game object that needs to be toggled

    void Start()
    {
        // Make sure the target object is active initially, and the panel is inactive
        targetObject.SetActive(true);
        uiPanel.SetActive(false);

        // Hide the cursor at the start (optional, depending on your needs)
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;  // Optional: locks the cursor to the center of the screen
    }

    void Update()
    {
        // Check if the UI panel is active and toggle the target object
        if (uiPanel.activeSelf) // If the panel is activated
        {
            if (targetObject.activeSelf)
            {
                targetObject.SetActive(false); // Deactivate target object
            }

            // Show the mouse cursor when the UI panel is active
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;  // Optional: unlocks the cursor for free movement
        }
        else // If the panel is deactivated
        {
            if (!targetObject.activeSelf)
            {
                targetObject.SetActive(true); // Activate target object
            }

            // Hide the mouse cursor when the UI panel is inactive
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;  // Optional: locks the cursor to the center of the screen again
        }
    }
}
