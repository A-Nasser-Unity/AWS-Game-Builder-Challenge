using UnityEngine;
using System.Collections.Generic;

public class ComponentRemover : MonoBehaviour
{
    [System.Serializable]
    public class ComponentToRemove
    {
        public GameObject targetObject;
        public string componentName;
    }

    [SerializeField]
    private List<ComponentToRemove> componentsToRemove = new List<ComponentToRemove>();

    private void Start()
    {
        foreach (var item in componentsToRemove)
        {
            if (item.targetObject != null)
            {
                Component componentToRemove = item.targetObject.GetComponent(item.componentName);
                if (componentToRemove != null)
                {
                    Destroy(componentToRemove);
                }
            }
        }
    }
}