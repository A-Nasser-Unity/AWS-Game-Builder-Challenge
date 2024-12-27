// Script to attach to the button (e.g., JumpButtonScript.cs)
using UnityEngine;
using UnityEngine.UI;

public class JumpButtonScript : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel to deactivate
    public Button jumpButton; // Reference to the button itself
    public PlayerMovement playerMovement; // Reference to the player movement script
    public float newPlayerJumpHeight = 10f; // Desired player jump height

    void Start()
    {
        // Add a listener to the button
        jumpButton.onClick.AddListener(OnJumpButtonClicked);
    }

    void OnJumpButtonClicked()
    {
        // Change the player's jump height
        if (playerMovement != null)
        {
            playerMovement.jumpHeight = newPlayerJumpHeight;
        }

        // Deactivate the panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }

        // Set the timescale to 1
        Time.timeScale = 1f;

        // Disable the button so it doesn't show again
        jumpButton.gameObject.SetActive(false);
    }
}
