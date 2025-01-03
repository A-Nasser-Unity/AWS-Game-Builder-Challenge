using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameObjectsActivator : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> objectsToDeactivate = new List<GameObject>();

    [SerializeField]
    private float deactivationDuration = 5f;

    private void Start()
    {
        StartCoroutine(DeactivateAndActivateObjects());
    }

    private IEnumerator DeactivateAndActivateObjects()
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
        yield return new WaitForSeconds(deactivationDuration);

        // Activate all objects
        foreach (GameObject obj in objectsToDeactivate)
        {
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }
    }
}
