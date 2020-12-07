using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class BoidFlock : MonoBehaviour
{
    public float speed,rotationSpeed;

    private Vector3 heading,pos;
    
    public float neighbours;
    

    private bool turn = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, Vector3.zero) >= CreateBoids.chosenArea)
            turn = true;
        else
        {
            turn = false;
        }

        if (turn)
        {
            Vector3 direction = (Vector3.zero) - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed * Time.deltaTime);
        }
        else
        {
            if (Random.Range(0, 5) < 1)
                Flock();
        }
        transform.Translate(0,0,speed * Time.deltaTime);
        
        
    }

    void Flock()
    {
        List<GameObject> boids;
        boids = CreateBoids.boids;

        Vector3 centre = Vector3.zero;
        Vector3 avoid = Vector3.zero;
        float averageSpeed = 0.1f;
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
