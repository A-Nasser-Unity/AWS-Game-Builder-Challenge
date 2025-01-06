using UnityEngine;
using UnityEngine.UI;

public class SpeedButtonScript : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel to deactivate
    public Button speedButton; // Reference to the button itself
    public ChickenController chickenController; // Reference to the chicken controller script
    public float newPlayerSpeed = 10f; // Desired player speed

    void Start()
    {
        // Add a listener to the button
        speedButton.onClick.AddListener(OnSpeedButtonClicked);
    }

    void OnSpeedButtonClicked()
    {
        // Change the player's speed
        if (chickenController != null)
        {
            chickenController.moveSpeed = newPlayerSpeed;
        }

        // Deactivate the panel
        // Disable the button so it doesn't show again
        speedButton.gameObject.SetActive(false);
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