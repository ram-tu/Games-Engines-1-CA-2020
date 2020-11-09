using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public int speed;

    public int rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * (speed * Time.deltaTime * vertical)); 
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime * horizontal)); 

        if (Input.GetKey(KeyCode.P))
            transform.Rotate(Vector3.left * (rotationSpeed * Time.deltaTime));
        if(Input.GetKey(KeyCode.L))
            transform.Rotate(Vector3.right * (rotationSpeed * Time.deltaTime));
    }
}