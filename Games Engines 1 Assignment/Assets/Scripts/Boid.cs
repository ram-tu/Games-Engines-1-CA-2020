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

    float angle, radius = 10;
    public float Speed = 2;
    float radialSpeed = 5f;

    public float height;
    public float width;
    public float groupSpacing;
    public float rotationSpeed;
    private float timeCounter = 0;
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

    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        width = 4;
        height = 7;
        
    }

    // Update is called once per frame
    void Update()
    {
        /*force = Seek(target);
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
        List<GameObject> boids = CreateBoids.boids;
        Vector3 avoid = Vector3.zero;
        if (velocity.magnitude > 0)
        {
            transform.forward = velocity;
            timeCounter += Time.deltaTime * Speed; 
        
            var xPos = Mathf.Sin(timeCounter) * height ;
            var yPos = Mathf.Cos(timeCounter) * width;
            transform.Translate(0,0,Speed * Time.deltaTime);
            transform.position = new Vector3(xPos,yPos,transform.position.z);
            
            //transform.position = new Vector3(xPos,yPos,);
            //transform.position += velocity * Time.deltaTime;
           /* angle += Time.deltaTime * angleSpeed;
            radius -= Time.deltaTime * radialSpeed;
 
            float x = radius * Mathf.Cos(Mathf.Deg2Rad*angle);
            float z = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
            float y = transform.position.y;
 
            transform.position = new Vector3(x, y, z);*/
        
            //transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            //float x = radius * Mathf.Cos(Mathf.Deg2Rad*angle);
            //float z = radius * Mathf.Sin(Mathf.Deg2Rad*angle);
            //transform.Translate(x,0,z);

            speed = 5;
            width = 4;
            height = 7;

            timeCounter = Time.deltaTime;
            float x = radius * Mathf.Cos(timeCounter) * width;
            float y = radius * Mathf.Sin(timeCounter) * height;
            
            transform.position = new Vector3(x,y,0);
            //ransform.Translate(x,y,0);


    }
        
        
         
        
 
        
       
       /* foreach (GameObject boid in boids)
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
     
        Vector3 direction =  avoid - transform.position;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(direction),rotationSpeed * Time.deltaTime);
        }
        
    }*/
  
}
