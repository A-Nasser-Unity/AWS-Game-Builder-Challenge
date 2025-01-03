using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeUI : MonoBehaviour
{
    [SerializeField] private float fadeDelay = 0f;    // Delay before fade starts
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade effect

    private Image imageComponent;
    private Color originalColor;
    private bool hasFaded = false;

    private void Awake()
    {
        // Get the Image component
        imageComponent = GetComponent<Image>();
        if (imageComponent != null)
        {
            // Store the original color (without modifying alpha)
            originalColor = imageComponent.color;
        }
    }

    private void Start()
    {
        if (imageComponent != null && !hasFaded)
        {
            // Make sure image starts fully transparent
            Color startColor = imageComponent.color;
            startColor.a = 0f;
            imageComponent.color = startColor;

            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        // Wait for the specified delay
        if (fadeDelay > 0)
        {
            yield return new WaitForSeconds(fadeDelay);
        }

        hasFaded = true;
        float elapsedTime = 0f;
        Color currentColor = imageComponent.color;

        // Gradually increase alpha over time to full visibility
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            currentColor.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            imageComponent.color = currentColor;
            yield return null;
        }

        // Ensure we end at fully visible
        currentColor.a = 1f;
        imageComponent.color = currentColor;
    }
}