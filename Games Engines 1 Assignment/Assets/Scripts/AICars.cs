using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICars : MonoBehaviour
{
    public int speed;
    public bool front; 
    public int currentSpeed;
    private GameObject lights;

    public string message;
    // Start is called before the first frame update
    void Start()
    {
        lights = transform.GetChild(0).gameObject;
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,speed * Time.deltaTime);
    }
    
    
   
}
