using UnityEngine;
using TMPro;

public class TextWaveEffect : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float waveHeight = 1.0f;
    [SerializeField] private float waveSpeed = 2.0f;
    [SerializeField] private float waveLength = 0.5f;
    [SerializeField] private bool autoAssignText = true;

    private void Start()
    {
        if (autoAssignText && text == null)
        {
            text = GetComponent<TMP_Text>();
        }

        if (text == null)
        {
            Debug.LogError("TextWaveEffect: No TMP_Text component assigned!");
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        text.ForceMeshUpdate();
        var textInfo = text.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
                continue;

            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
            {
                int index = charInfo.vertexIndex + j;
                Vector3 orig = verts[index];
                verts[index] = orig + new Vector3(0,
                    Mathf.Sin(Time.time * waveSpeed + orig.x * waveLength) * waveHeight,
                    0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}