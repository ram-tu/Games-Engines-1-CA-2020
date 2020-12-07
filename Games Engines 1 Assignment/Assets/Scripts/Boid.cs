using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass  = 1.0f;
    public float max = 5;

    public Transform target;

   
    public float groupSpacing;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + force);
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + velocity);
    }

    public Vector3 Seek(Transform target)
    {
        Vector3 desired = target.position - transform.position;
        desired.Normalize();
        desired *= max;

        return desired - velocity;
    }


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        force = Seek(target);
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        List<GameObject> boids = CreateBoids.boids;
        Vector3 avoid = Vector3.zero;
        if (velocity.magnitude > 0)
        {
            transform.forward = velocity;
            transform.position += velocity * Time.deltaTime;
        }
        foreach (GameObject boid in boids)
        {
            if (boid != this.gameObject)
            {
                float distance = Vector3.Distance(boid.transform.position, this.transform.position);
                if (distance <= groupSpacing)
                {
                    if (distance < 1.0f)
                    {
                        avoid = avoid + (this.transform.position - boid.transform.position);
                    }
                }
            }
        }
    }
  
}
