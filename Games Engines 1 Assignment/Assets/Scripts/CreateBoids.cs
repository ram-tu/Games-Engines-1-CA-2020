using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoids : MonoBehaviour
{
    public GameObject boid;

    public int numBoids;

    private List<GameObject> boids;

    public int area;
    // Start is called before the first frame update
    void Start()
    {
        boids = new List<GameObject>();
        for (int i = 0; i < numBoids; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-area,area),Random.Range(-area,area),Random.Range(-area,area));
            pos = transform.TransformPoint(pos);
            GameObject newBoid = Instantiate(boid, pos, Quaternion.identity).gameObject;
            boids.Add(boid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
