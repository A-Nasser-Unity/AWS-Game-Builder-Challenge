// Script to attach to the button (e.g., SpeedButtonScript.cs)
using UnityEngine;
using UnityEngine.UI;

public class SpeedButtonScript : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel to deactivate
    public Button speedButton; // Reference to the button itself
    public PlayerMovement playerMovement; // Reference to the player movement script
    public float newPlayerSpeed = 10f; // Desired player speed

    void Start()
    {
        // Add a listener to the button
        speedButton.onClick.AddListener(OnSpeedButtonClicked);
    }

    void OnSpeedButtonClicked()
    {
        // Change the player's speed
        if (playerMovement != null)
        {
            playerMovement.moveSpeed = newPlayerSpeed;
        }

        // Deactivate the panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }

        // Set the timescale to 1
        Time.timeScale = 1f;

        // Disable the button so it doesn't show again
        speedButton.gameObject.SetActive(false);
    }
}
