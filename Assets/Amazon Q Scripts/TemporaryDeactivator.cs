using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TemporaryDeactivator : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToDeactivate = new List<GameObject>();

    [SerializeField] private float duration = 5f;

    // This will run automatically when the scene starts
    private void Start()
    {
        StartCoroutine(DeactivateRoutine());
    }

    private IEnumerator DeactivateRoutine()
    {
        // Deactivate all objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(false);
            }
        }

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Reactivate all objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
