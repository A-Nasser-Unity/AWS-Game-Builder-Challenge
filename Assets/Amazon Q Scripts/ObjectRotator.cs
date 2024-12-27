using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] private bool rotateX = false;
    [SerializeField] private bool rotateY = false;
    [SerializeField] private bool rotateZ = false;

    void Update()
    {
        Vector3 rotation = new Vector3(
            rotateX ? rotationSpeed : 0f,
            rotateY ? rotationSpeed : 0f,
            rotateZ ? rotationSpeed : 0f
        ) * Time.deltaTime;

        transform.Rotate(rotation);
    }
}
