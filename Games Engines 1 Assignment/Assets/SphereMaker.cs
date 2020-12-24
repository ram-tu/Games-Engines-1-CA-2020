using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMaker : MonoBehaviour
{
    public int numberOfPoints = 100;
    public float scale = 3.0f;
 
    // Use this for initialization
    void Start () {
 
        GameObject innerSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        innerSphere.transform.localScale = innerSphere.transform.localScale * (scale * 2);
        innerSphere.transform.name = "Inner Sphere";
        innerSphere.transform.parent = this.transform;
 
        Vector3[] myPoints = GetPointsOnSphere(numberOfPoints);
 
        foreach (Vector3 point in myPoints)
        {
            GameObject outerSphere = GameObject.CreatePrimitive(PrimitiveType.Cube);
            outerSphere.transform.position = point * scale;
            outerSphere.transform.localScale = new Vector3(1,1,0);
            outerSphere.transform.parent = innerSphere.transform;
        }
   
    }
 
    Vector3[] GetPointsOnSphere(int nPoints)
    {
        float fPoints = (float)nPoints;
 
        Vector3[] points = new Vector3[nPoints];
 
        float inc = Mathf.PI * (3 - Mathf.Sqrt(5));
        float off = 2 / fPoints;
 
        for (int k = 0; k < nPoints; k++)
        {
            float y = k * off - 1 + (off / 2);
            float r = Mathf.Sqrt(1 - y * y);
            float phi = k * inc;
 
            points[k] = new Vector3(Mathf.Cos(phi) * r, y, Mathf.Sin(phi) * r);
        }
 
        return points;
    }
}
