using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ActivateButton : MonoBehaviour
{
    [SerializeField] private Button buttonToActivate;
    [SerializeField] private float delayInSeconds = 1f;

    private void Start()
    {
        // Make sure button starts deactivated
        if (buttonToActivate != null)
        {
            buttonToActivate.gameObject.SetActive(false);
            StartCoroutine(ActivateButtonAfterDelay());
        }
    }

    private IEnumerator ActivateButtonAfterDelay()
    {
        // Wait for specified time
        yield return new WaitForSeconds(delayInSeconds);

        // Activate the button
        if (buttonToActivate != null)
        {
            buttonToActivate.gameObject.SetActive(true);
        }
    }
}