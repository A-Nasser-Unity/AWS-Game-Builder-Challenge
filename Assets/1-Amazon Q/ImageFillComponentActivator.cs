using UnityEngine;
using UnityEngine.UI;

public class ImageFillComponentActivator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Image targetImage;
    [SerializeField] private GameObject objectWithComponent;
    [SerializeField] private Behaviour componentToActivate;

    [Header("Settings")]
    [SerializeField] private float activationDuration = 1f;

    private float previousFillAmount;
    private float timer;
    private bool isComponentActive;

    private void Start()
    {
        if (targetImage == null)
        {
            Debug.LogError("Target Image is not assigned!");
            enabled = false;
            return;
        }

        if (objectWithComponent == null || componentToActivate == null)
        {
            Debug.LogError("Object or Component reference is missing!");
            enabled = false;
            return;
        }

        previousFillAmount = targetImage.fillAmount;
        componentToActivate.enabled = false;
    }

    private void Update()
    {
        // Check if fill amount has changed
        if (targetImage.fillAmount != previousFillAmount)
        {
            // Enable component and reset timer
            if (!isComponentActive)
            {
                componentToActivate.enabled = true;
                isComponentActive = true;
            }
            timer = activationDuration;
            previousFillAmount = targetImage.fillAmount;
        }

        // Handle timer and component deactivation
        if (isComponentActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                componentToActivate.enabled = false;
                isComponentActive = false;
            }
        }
    }
}