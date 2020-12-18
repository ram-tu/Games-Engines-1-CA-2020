using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICars : MonoBehaviour
{
    public int speed;
    public bool front;
    private int currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            speed = 0;
        }

        if (front)
        {
            if (other.gameObject.CompareTag("Front"))
            {
                speed = 0;
            }
        }

        if (!front)
        {
            if(other.gameObject.CompareTag("Side")){}

            {
                speed = 0;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            speed = currentSpeed;
        }
        if (front)
        {
            if (other.gameObject.CompareTag("Front"))
            {
                speed = currentSpeed;
            }
        }

        if (!front)
        {
            if(other.gameObject.CompareTag("Side")){}

            {
                speed = currentSpeed;
            }
        }
    }
}
