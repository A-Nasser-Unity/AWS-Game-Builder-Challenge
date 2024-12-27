using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ImageScaler : MonoBehaviour
{
    [SerializeField] private Image targetImage;         // Reference to the UI Image component
    [SerializeField] private float minScale = 0.8f;     // Minimum scale value
    [SerializeField] private float maxScale = 1.2f;     // Maximum scale value
    [SerializeField] private float duration = 1.0f;     // Duration of scaling animation in seconds

    private void Start()
    {
        // Ensure we have reference to the Image component
        if (targetImage == null)
        {
            targetImage = GetComponent<Image>();
        }

        // Start the scaling animation
        StartCoroutine(ScaleImage());
    }

    private IEnumerator ScaleImage()
    {
        while (true) // Loop forever
        {
            // Scale up
            yield return StartCoroutine(ScaleTo(maxScale));

            // Scale down
            yield return StartCoroutine(ScaleTo(minScale));
        }
    }

    private IEnumerator ScaleTo(float targetScale)
    {
        Vector3 startScale = targetImage.transform.localScale;
        Vector3 endScale = Vector3.one * targetScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / duration;

            // Use smooth interpolation
            targetImage.transform.localScale = Vector3.Lerp(startScale, endScale, progress);

            yield return null;
        }

        // Ensure we reach the exact target scale
        targetImage.transform.localScale = endScale;
    }

    // Optional: Public method to manually start/restart the scaling
    public void StartScaling()
    {
        StopAllCoroutines();
        StartCoroutine(ScaleImage());
    }

    // Optional: Public method to stop scaling
    public void StopScaling()
    {
        StopAllCoroutines();
    }
}