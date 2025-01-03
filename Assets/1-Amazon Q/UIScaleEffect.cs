using UnityEngine;
using UnityEngine.UI;

public class UIScaleEffect : MonoBehaviour
{
    [SerializeField] private float minScale = 0.8f;
    [SerializeField] private float maxScale = 1.2f;
    [SerializeField] private float scaleSpeed = 1f;

    private RectTransform rectTransform;
    private bool scalingUp = true;
    private Vector3 originalScale;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalScale = rectTransform.localScale;
    }

    private void Update()
    {
        if (scalingUp)
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale,
                originalScale * maxScale, Time.deltaTime * scaleSpeed);

            if (Vector3.Distance(rectTransform.localScale, originalScale * maxScale) < 0.01f)
            {
                scalingUp = false;
            }
        }
        else
        {
            rectTransform.localScale = Vector3.Lerp(rectTransform.localScale,
                originalScale * minScale, Time.deltaTime * scaleSpeed);

            if (Vector3.Distance(rectTransform.localScale, originalScale * minScale) < 0.01f)
            {
                scalingUp = true;
            }
        }
    }

    public void SetScaleSpeed(float speed)
    {
        scaleSpeed = speed;
    }

    public void SetScaleRange(float min, float max)
    {
        minScale = min;
        maxScale = max;
    }
}