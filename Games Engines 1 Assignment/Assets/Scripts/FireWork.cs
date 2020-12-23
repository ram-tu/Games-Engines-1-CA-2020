using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWork : MonoBehaviour
{
    public int speed;

    public int explodingTime;

    private bool exploded;

    public int numwaypoints;

    public int radius;
    // Start is called before the first frame update
    void Start()
    {
        exploded = false;
        Invoke("Explode",explodingTime);
        Destroy(this,explodingTime * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(!exploded)
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        
    }

    public void Explode()
    {
        exploded = true;
        float thetaInc = (Mathf.PI * 2) / numwaypoints;
        for (int i = 0; i < 10; i++)
        {
            float theta = i * thetaInc;
            float angle = 360 / numwaypoints * i;
            Quaternion anglePos = new Quaternion(0,angle,0,0);
            //Vector3 pos = new Vector3(Mathf.Sin(theta) * radius, Mathf.Cos(theta) * radius, 0);
            //pos = transform.TransformPoint(pos);
            GameObject explodedPart = Instantiate(gameObject);
            //explodedPart.transform.position = pos;
            explodedPart.transform.rotation = new Quaternion(0.1f,0,0,0);
            //explodedPart.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            Destroy(explodedPart.GetComponent<FireWork>());
            //explodedPart.GetComponent<Rigidbody>().velocity = new Vector3(2f,0.5f,2f);
            explodedPart.GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
