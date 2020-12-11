using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Boid : MonoBehaviour
{
    public Vector3 velocity;
    public Vector3 acceleration;
    public Vector3 force;
    public float mass = 1.0f;
    public float max = 5;

    public GameObject target;

    public int area;
    public int timeChange;
    private ParticleSystem ps;
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
        ps = GetComponent<ParticleSystem>();
        
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeTargetPosition());
    }

    IEnumerator ChangeTargetPosition()
    {
        while (true)
        {
            target.transform.position = transform.TransformPoint(new Vector3(Random.Range(-area,area),0,Random.Range(-area,area)));
            GetComponent<Renderer>().material.color = 
                Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
            //GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            //main.startColor = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1);
            yield return new WaitForSeconds(timeChange);
        }
    }
    // Update is called once per frame
    void Update()
    {
        force = Seek(target.transform);
        acceleration = force / mass;
        velocity += acceleration * Time.deltaTime;
       
        if (velocity.magnitude > 0)
        {
            transform.position += velocity * Time.deltaTime;
        }
        ParticleSystem.ColorOverLifetimeModule colouring = ps.colorOverLifetime;
        colouring.color = Color.HSVToRGB(Random.Range(0.0f, 1.0f), 1, 1); 

    }
}
