using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorkSpwawner : MonoBehaviour
{
    public int area;
    public GameObject firework;
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(firework, new Vector3(Random.Range(-area, area), 0, Random.Range(-area, area)),Quaternion.identity);
            yield return new WaitForSeconds(timer);
        }
    }
}
