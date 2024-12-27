using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateObjectsOnActivation : MonoBehaviour
{
    [Tooltip("List of GameObjects to deactivate when this object is activated.")]
    public List<GameObject> objectsToDeactivate;

    [Tooltip("Time in seconds to keep the objects deactivated.")]
    public float deactivationDuration = 2.0f;

    private void OnEnable()
    {
        // Start the coroutine to handle deactivating and reactivating objects
        StartCoroutine(HandleDeactivation());
    }

    private IEnumerator HandleDeactivation()
    {
        // Deactivate all objects in the list
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null) // Check if the object is valid
                obj.SetActive(false);
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(deactivationDuration);

        // Reactivate all objects in the list
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null) // Check if the object is valid
                obj.SetActive(true);
        }
    }
}
