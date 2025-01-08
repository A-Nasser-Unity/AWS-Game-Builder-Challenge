using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartFade : MonoBehaviour
{
    [SerializeField] private float fadeDelay = 0f;    // Delay before fade starts
    [SerializeField] private float fadeDuration = 1f; // Duration of the fade effect


    private Image imageComponent;
    private bool hasFaded = false;

    private void Awake()
    {
        // Get the Image component
        imageComponent = GetComponent<Image>();
    }

    private void Start()
    {
        if (imageComponent != null && !hasFaded)
        {
            // Make sure image starts fully visible
            Color startColor = imageComponent.color;
            startColor.a = 1f;
            imageComponent.color = startColor;

            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        // Wait for the specified delay
        if (fadeDelay > 0)
        {
            yield return new WaitForSeconds(fadeDelay);
        }



        hasFaded = true;
        float elapsedTime = 0f;
        Color currentColor = imageComponent.color;

        // Gradually decrease alpha over time to zero
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            currentColor.a = newAlpha;
            imageComponent.color = currentColor;
            yield return null;
        }
    }
}