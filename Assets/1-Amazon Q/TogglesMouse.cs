using UnityEngine;

public class TogglesMouse : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel; // Reference to the UI panel

    private void Start()
    {
        // Hide and lock cursor by default
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Check if UI panel is active and update cursor state accordingly
        if (uiPanel != null)
        {
            bool isPanelActive = uiPanel.activeSelf;
            Cursor.visible = isPanelActive;
            Cursor.lockState = isPanelActive ? CursorLockMode.None : CursorLockMode.Locked;
        }
    }
}