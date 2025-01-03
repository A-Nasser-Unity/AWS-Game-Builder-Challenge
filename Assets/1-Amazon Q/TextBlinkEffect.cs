using UnityEngine;
using TMPro;
using System.Collections;

public class TextBlinkEffect : MonoBehaviour
{
    [SerializeField] private float blinkInterval = 0.5f;
    [SerializeField] private bool startOnAwake = true;

    private Component targetComponent;

    private void Start()
    {
        targetComponent = GetComponent<TextMeshProUGUI>();
        if (targetComponent == null)
            targetComponent = GetComponent<SpriteRenderer>();
        if (targetComponent == null)
            targetComponent = GetComponent<MeshRenderer>();

        if (startOnAwake)
            StartBlinking();
    }

    public void StartBlinking()
    {
        StartCoroutine(BlinkRoutine());
    }

    public void StopBlinking()
    {
        StopAllCoroutines();
        if (targetComponent != null)
        {
            if (targetComponent is Behaviour behaviour)
                behaviour.enabled = true;
            else if (targetComponent is Renderer renderer)
                renderer.enabled = true;
        }
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            if (targetComponent != null)
            {
                if (targetComponent is Behaviour behaviour)
                    behaviour.enabled = !behaviour.enabled;
                else if (targetComponent is Renderer renderer)
                    renderer.enabled = !renderer.enabled;
            }
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}