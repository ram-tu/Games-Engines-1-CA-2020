using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
   

    public AICars car;

    public bool front;
    // Start is called before the first frame update
    void Start()
    {
        car = transform.parent.gameObject.GetComponent<AICars>();
        if (car.front)
        {
            front = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            car.speed = 0;
            car.message = "another car";
        }

   
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            car.speed = car.currentSpeed;
            car.message = "car 2";
          
        }

    }
}
