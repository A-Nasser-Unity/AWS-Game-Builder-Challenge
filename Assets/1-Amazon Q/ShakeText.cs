using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ShakeText : MonoBehaviour
{
    [Header("Shake Settings")]
    [SerializeField] private float shakeDuration = 0.5f;
    [SerializeField] private float shakeAmount = 5f;
    [SerializeField] private TextMeshProUGUI textToWatch;
    [SerializeField] private List<RectTransform> objectsToShake;

    private Vector3[] originalPositions;
    private string lastText;
    private bool isShaking = false;

    private void Start()
    {
        // Store original positions of UI elements
        if (objectsToShake != null)
        {
            originalPositions = new Vector3[objectsToShake.Count];
            for (int i = 0; i < objectsToShake.Count; i++)
            {
                originalPositions[i] = objectsToShake[i].localPosition;
            }
        }

        if (textToWatch != null)
        {
            lastText = textToWatch.text;
        }
    }

    private void Update()
    {
        if (textToWatch != null && textToWatch.text != lastText)
        {
            lastText = textToWatch.text;
            StartShake();
        }
    }

    private void StartShake()
    {
        if (!isShaking)
        {
            StartCoroutine(ShakeObjects());
        }
    }

    private IEnumerator ShakeObjects()
    {
        isShaking = true;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            for (int i = 0; i < objectsToShake.Count; i++)
            {
                if (objectsToShake[i] != null)
                {
                    Vector3 randomOffset = Random.insideUnitSphere * shakeAmount;
                    objectsToShake[i].localPosition = originalPositions[i] + randomOffset;
                }
            }

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Reset positions
        for (int i = 0; i < objectsToShake.Count; i++)
        {
            if (objectsToShake[i] != null)
            {
                objectsToShake[i].localPosition = originalPositions[i];
            }
        }

        isShaking = false;
    }
}