using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLights : MonoBehaviour
{
   

    public AICars car;

    public bool front;

    public GameObject trafficlight;
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
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Car"))
        {
            car.speed = 0;
            car.message = "another car";
        }
        
        if (other.gameObject.CompareTag("Front") && front)
        {
            if (other.gameObject.GetComponent<TrafficLight>().redlight)
            {
                car.speed = 0;
                car.message = "front light";
                trafficlight = other.gameObject;
            }
            else if(other.gameObject.GetComponent<TrafficLight>().redlight == false)
            {
                car.speed = car.currentSpeed;
                trafficlight = null;
            }
           
        }
        if (other.gameObject.CompareTag("Side") && !front)
        {
            if (other.gameObject.GetComponent<TrafficLight>().redlight)
            {
                car.speed = 0;
                car.message = "front light";
                trafficlight = other.gameObject;
            }
            else if(other.gameObject.GetComponent<TrafficLight>().redlight == false)
            {
                car.speed = car.currentSpeed;
                trafficlight = null;
            }
           
        }
        

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Car"))
        {
            car.speed = car.currentSpeed;
        }
    }
}
