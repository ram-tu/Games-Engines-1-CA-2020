using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz : MonoBehaviour
{
    public float scale = 80;
    List<GameObject>objects = new List<GameObject>();

    public float radius = 10;
    
    
    // Start is called before the first frame update
    void Start()
    {
        float spacing = 70;
        for (int i = 0; i < 15; i++)
        {
            Vector3 p = new Vector3(0,0,i*spacing);
            p = transform.TransformPoint(p);
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(p, Quaternion.identity);
            cube.transform.parent = this.transform;
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float)10
                , 1
                , 1
            );
            objects.Add(cube);
            /*Vector3 p = new Vector3(
                Mathf.Sin(theta * i) * radius
                , 0
                , Mathf.Cos(theta * i) * radius
            );
            p = transform.TransformPoint(p);
            Quaternion q = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            q = transform.rotation * q;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.SetPositionAndRotation(p, q);
            cube.transform.parent = this.transform;
            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB(
                i / (float) AudioAnalyzer.frameSize
                , 1
                , 1
            );
            objects.Add(cube);*/

        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].transform.localScale = new Vector3(60,100 + (AudioAnalyzer.spectrum[i]*50) * scale,60);
            Debug.Log(AudioAnalyzer.spectrum[i]);
        }
    }
}
