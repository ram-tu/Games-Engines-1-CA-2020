using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int speed;
    public int rotationSpeed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation,target.rotation,rotationSpeed * Time.deltaTime);
    }
}
