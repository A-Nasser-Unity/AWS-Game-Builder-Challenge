// Script to deactivate objects for a time and then reactivate them (e.g., DeactivateObjectsButtonScript.cs)
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DeactivateObjectsButtonScript : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel to deactivate
    public Button deactivateButton; // Reference to the button itself
    public List<GameObject> objectsToDeactivate; // List of objects to deactivate
    public float deactivateDuration = 5f; // Time to keep objects deactivated

    void Start()
    {
        // Add a listener to the button
        deactivateButton.onClick.AddListener(OnDeactivateButtonClicked);
    }

    void OnDeactivateButtonClicked()
    {
        // Start the coroutine to deactivate and reactivate objects
        StartCoroutine(DeactivateAndReactivateObjects());

        // Deactivate the panel
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }

        // Set the timescale to 1
        Time.timeScale = 1f;

        // Disable the button so it doesn't show again
        deactivateButton.gameObject.SetActive(false);
    }

    IEnumerator DeactivateAndReactivateObjects()
    {
        // Deactivate each object in the list
        foreach (var obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Wait for the specified duration, adjusted for timescale
        float elapsed = 0f;
        while (elapsed < deactivateDuration)
        {
            yield return null;
            elapsed += Time.unscaledDeltaTime;
        }

        // Reactivate each object in the list
        foreach (var obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
