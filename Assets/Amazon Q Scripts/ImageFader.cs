using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageFader : MonoBehaviour
{
    [SerializeField] private float delayBeforeFade = 0f;
    [SerializeField] private float fadeDuration = 1f;

    private Image image;

    void Start()
    {
        image = GetComponent<Image>();

        // Make sure image starts fully transparent
        Color startColor = image.color;
        startColor.a = 0f;
        image.color = startColor;

        // Start the fade
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        // Wait for the delay
        yield return new WaitForSeconds(delayBeforeFade);

        // Get the starting color
        Color currentColor = image.color;
        float startAlpha = currentColor.a;

        // Fade over time
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            currentColor.a = Mathf.Lerp(startAlpha, 1f, elapsedTime / fadeDuration);
            image.color = currentColor;
            yield return null;
        }

        // Ensure we end at fully visible
        currentColor.a = 1f;
        image.color = currentColor;
    }
}