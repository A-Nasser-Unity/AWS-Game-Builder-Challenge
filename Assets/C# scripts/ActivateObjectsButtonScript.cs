// Script to attach to the button for activating objects (e.g., ActivateObjectsButtonScript.cs)
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ActivateObjectsButtonScript : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel to deactivate
    public Button activateButton; // Reference to the button itself
    public List<GameObject> objectsToActivate; // List of objects to activate

    void Start()
    {
        // Add a listener to the button
        activateButton.onClick.AddListener(OnActivateButtonClicked);
    }

    void OnActivateButtonClicked()
    {
        // Activate each object in the list
        foreach (var obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        // Deactivate the panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }

        // Set the timescale to 1
        Time.timeScale = 1f;

        // Disable the button so it doesn't show again
        activateButton.gameObject.SetActive(false);
    }
}
