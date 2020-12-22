using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextMovemet : MonoBehaviour
{
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.ForceMeshUpdate();
        var textInfo = text.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var character = textInfo.characterInfo[i];
            if (!character.isVisible)
            {
                continue;
                
            }

            Vector3[] verts = textInfo.meshInfo[character.materialReferenceIndex].vertices;
            for (int j = 0; j < 4; j++)
            {
                Vector3 orig = verts[character.vertexIndex + j];
                verts[character.vertexIndex + j] =
                    orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.01f) * 10, 0);
                    

            }
            
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshinfo = textInfo.meshInfo[i];
            meshinfo.mesh.vertices = meshinfo.vertices;
            text.UpdateGeometry(meshinfo.mesh,i);
        }
    }
}
