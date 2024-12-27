using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInUI : MonoBehaviour
{
    private Image imageToFade;  // Reference to the UI Image
    public float fadeDuration = 1f;  // Duration of the fade effect
    public float delayBeforeFade = 0f;  // Delay before starting the fade (in seconds)

    void Awake()
    {
        // Get the Image component attached to the same GameObject
        imageToFade = GetComponent<Image>();
    }

    void Start()
    {
        // Start the fade-in process with a delay
        StartCoroutine(FadeInWithDelay());
    }

    // Coroutine to handle the fade-in with a delay
    private IEnumerator FadeInWithDelay()
    {
        // Wait for the specified delay before starting the fade
        yield return new WaitForSeconds(delayBeforeFade);

        // Start fading the image
        float elapsedTime = 0f;
        Color startColor = imageToFade.color;
        startColor.a = 0;  // Start from fully transparent
        imageToFade.color = startColor;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);  // Calculate the alpha value
            Color newColor = imageToFade.color;
            newColor.a = alpha;  // Update the alpha value
            imageToFade.color = newColor;
            yield return null;
        }

        // Ensure that the image is fully opaque after the fade
        Color finalColor = imageToFade.color;
        finalColor.a = 1f;
        imageToFade.color = finalColor;
    }
}
