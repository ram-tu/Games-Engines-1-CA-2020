using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidFlock : MonoBehaviour
{
    public float speed,rotationSpeed;

    private Vector3 heading,pos;

    public float neighbours;
    private float averageSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
        if (Random.Range(0, 5) < 1)
            Flock();
        
    }

    void Flock()
    {
        List<GameObject> boids;
        boids = CreateBoids.boids;

        Vector3 centre = Vector3.zero;
        Vector3 avoid = Vector3.zero;

        Vector3 goal = CreateBoids.goal;
        float distance;
        int groupSize = 0;
        foreach (GameObject boid in boids)
        {
            if (boid != this.gameObject)
            {
                distance = Vector3.Distance(boid.transform.position, this.transform.position);
                if (distance <= neighbours)
                {
                    centre += boid.transform.position;
                    groupSize++;

                    if (distance < 1.0f)
                    {
                        avoid = avoid + (this.transform.position - boid.transform.position);
                    }

                    BoidFlock anotherFlock = boid.GetComponent<BoidFlock>();
                    averageSpeed = averageSpeed + anotherFlock.speed;
                    
                }
            }
        }

        if (groupSize > 0)
        {
            centre = centre / groupSize + (goal - this.transform.position);
            speed = averageSpeed / groupSize;

            Vector3 direction = (centre + avoid) - transform.position;
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed * Time.deltaTime);
            }
        }
        
    }
    
 
}
