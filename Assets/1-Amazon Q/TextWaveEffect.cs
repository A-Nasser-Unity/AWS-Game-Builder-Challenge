using UnityEngine;
using TMPro;
using System.Collections;

public class TextWaveEffect : MonoBehaviour
{
    [Header("Wave Settings")]
    [SerializeField] private float waveSpeed = 2f;
    [SerializeField] private float waveHeight = 5f;
    [SerializeField] private float characterOffset = 0.2f;

    private TextMeshProUGUI textMesh;
    private Mesh mesh;
    private Vector3[] vertices;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        textMesh.ForceMeshUpdate();
        mesh = textMesh.mesh;
        vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 offset = new Vector3(0,
                Mathf.Sin(Time.time * waveSpeed + vertices[i].x * characterOffset) * waveHeight,
                0);
            vertices[i] = vertices[i] + offset;
        }

        mesh.vertices = vertices;
        textMesh.canvasRenderer.SetMesh(mesh);
    }
}