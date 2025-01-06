using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImageShakeEffect : MonoBehaviour
{
    [Header("Shake Settings")]
    [SerializeField] private float shakeIntensity = 5f;
    [SerializeField] private float shakeDuration = 0.2f;


    [Header("Secondary Image")]
    [SerializeField] private Image secondaryImage;
    [Tooltip("If true, the secondary image will shake with the same offset as the main image")]
    [SerializeField] private bool useMatchingShake = true;

    private Image imageComponent;
    private float lastFillAmount;
    private Vector3 originalPosition;
    private float shakeTimeRemaining;
    private Vector3 randomShakeOffset;

    private void Start()
    {
        imageComponent = GetComponent<Image>();
        lastFillAmount = imageComponent.fillAmount;
        originalPosition = transform.localPosition;
    }

    private void Update()
    {
        // Check if fill amount changed
        if (imageComponent.fillAmount != lastFillAmount)
        {
            shakeTimeRemaining = shakeDuration;
            lastFillAmount = imageComponent.fillAmount;
        }

        // Apply shake effect
        if (shakeTimeRemaining > 0)
        {
            // Generate random shake offset
            randomShakeOffset = new Vector3(
                Random.Range(-1f, 1f),
                Random.Range(-1f, 1f),
                0
            ) * shakeIntensity;

            // Apply shake
            transform.localPosition = originalPosition + randomShakeOffset;

            // Apply shake to secondary image if assigned
            if (secondaryImage != null)
            {
                if (useMatchingShake)
                {
                    // Use the same shake offset for synchronized movement
                    secondaryImage.transform.localPosition = originalPosition + randomShakeOffset;
                }
                else
                {
                    // Generate a different random offset for independent movement
                    Vector3 secondaryOffset = new Vector3(
                        Random.Range(-1f, 1f),
                        Random.Range(-1f, 1f),
                        0
                    ) * shakeIntensity;
                    secondaryImage.transform.localPosition = originalPosition + secondaryOffset;
                }
            }

            shakeTimeRemaining -= Time.deltaTime;

            // Reset position when shake is complete
            if (shakeTimeRemaining <= 0)
            {
                transform.localPosition = originalPosition;
                if (secondaryImage != null)
                {
                    secondaryImage.transform.localPosition = originalPosition;
                }
            }
        }
    }
}