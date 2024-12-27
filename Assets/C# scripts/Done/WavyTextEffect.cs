using TMPro;
using UnityEngine;

public class WavyTextEffect : MonoBehaviour
{
    public TextMeshProUGUI tmpText;
    public float waveSpeed = 2.0f;
    public float waveHeight = 5.0f;

    void Update()
    {
        tmpText.ForceMeshUpdate();
        var textInfo = tmpText.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible) continue;

            var vertices = textInfo.meshInfo[textInfo.characterInfo[i].materialReferenceIndex].vertices;
            for (int j = 0; j < 4; j++)
            {
                var vertex = vertices[textInfo.characterInfo[i].vertexIndex + j];
                vertex.y += Mathf.Sin(Time.time * waveSpeed + vertex.x * 0.01f) * waveHeight;
                vertices[textInfo.characterInfo[i].vertexIndex + j] = vertex;
            }
        }

        tmpText.UpdateVertexData();
    }
}
