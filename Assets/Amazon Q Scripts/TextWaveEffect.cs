using UnityEngine;
using TMPro;

public class TextWaveEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    [SerializeField] private float waveSpeed = 2f;
    [SerializeField] private float waveHeight = 10f;
    [SerializeField] private float characterSpacing = 0.5f;

    private TMP_TextInfo textInfo;
    private Vector3[] originalVertexPositions;

    private void Start()
    {
        if (textMeshPro == null)
            textMeshPro = GetComponent<TMP_Text>();

        textInfo = textMeshPro.textInfo;
        CacheOriginalVertexPositions();
    }

    private void CacheOriginalVertexPositions()
    {
        textMeshPro.ForceMeshUpdate();
        int totalVertices = textInfo.meshInfo[0].vertices.Length;
        originalVertexPositions = new Vector3[totalVertices];
        for (int i = 0; i < totalVertices; i++)
        {
            originalVertexPositions[i] = textInfo.meshInfo[0].vertices[i];
        }
    }

    private void Update()
    {
        AnimateText();
    }

    private void AnimateText()
    {
        if (!textMeshPro.havePropertiesChanged)
        {
            for (int i = 0; i < textInfo.characterCount; i++)
            {
                TMP_CharacterInfo charInfo = textInfo.characterInfo[i];

                if (!charInfo.isVisible)
                    continue;

                int materialIndex = charInfo.materialReferenceIndex;
                int vertexIndex = charInfo.vertexIndex;
                Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

                for (int j = 0; j < 4; j++)
                {
                    Vector3 orig = originalVertexPositions[vertexIndex + j];
                    float wave = Mathf.Sin(Time.time * waveSpeed + i * characterSpacing) * waveHeight;
                    vertices[vertexIndex + j] = orig + new Vector3(0, wave, 0);
                }
            }

            // Update the mesh
            for (int i = 0; i < textInfo.meshInfo.Length; i++)
            {
                textInfo.meshInfo[i].mesh.vertices = textInfo.meshInfo[i].vertices;
                textMeshPro.UpdateGeometry(textInfo.meshInfo[i].mesh, i);
            }
        }
    }
}
