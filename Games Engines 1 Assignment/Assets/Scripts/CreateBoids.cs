using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoids : MonoBehaviour
{
    public GameObject boid;

    public int numBoids;

    public static List<GameObject> boids;

    public int area;


    public static int chosenArea;
    public static Vector3 goal;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        chosenArea = area;
        boids = new List<GameObject>();
        for (int i = 0; i < numBoids; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-area,area),Random.Range(-area,area),Random.Range(-area,area));
            pos = transform.TransformPoint(pos);
            GameObject newBoid = Instantiate(boid, pos, Quaternion.identity).gameObject;
            boids.Add(newBoid);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 10000) < 50)
        {
            goal = new Vector3(Random.Range(-area,area),Random.Range(-area,area),Random.Range(-area,area));
            goal = transform.TransformPoint(goal);
            Debug.Log(goal);
            target.transform.position = goal;
            
        }
    }

    public static Vector3 sendGoal()
    {
        return goal;
    }
    
}
