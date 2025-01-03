using UnityEngine;
using UnityEngine.UI;

public class ButtonActivator : MonoBehaviour
{
    [Header("Objects to Activate")]
    [SerializeField] private GameObject[] objectsToActivate;

    [Header("Panel to Hide")]
    [SerializeField] private GameObject panelToHide;

    private Button button;

    private void Awake()
    {
        // Get the Button component
        button = GetComponent<Button>();

        // Add click listener
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClick);
        }
    }

    private void OnButtonClick()
    {
        // Activate specified objects
        foreach (GameObject obj in objectsToActivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

        // Disable the button so it doesn't show again
        gameObject.SetActive(false);

        // Hide the panel
        if (panelToHide != null)
        {
            panelToHide.SetActive(false);
        }

        // Resume the game
        Time.timeScale = 1f;

        // Disable the button
        button.interactable = false;
    }

    private void OnDestroy()
    {
        // Clean up the listener when the object is destroyed
        if (button != null)
        {
            button.onClick.RemoveListener(OnButtonClick);
        }
    }
}