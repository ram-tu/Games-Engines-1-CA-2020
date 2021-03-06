﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    
    private GameObject[] lights = new GameObject[3];

    public int timeFrame;
    public bool redlight;
    public int startingLight;

    public int indicator;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            lights[i] = transform.GetChild(i + 1).gameObject;
        }
        //lights[startingLight].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
        StartCoroutine(ChangeLight());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        //StartCoroutine(ChangeLight());
    }

    IEnumerator ChangeLight()
    {
        while (true)
        {
            
            
            lights[(startingLight) % 3].GetComponent<Renderer>().material.DisableKeyword("_EMISSION");
            lights[(startingLight + 1) % 3].GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
            startingLight++;
            indicator = startingLight % 3;
            if (startingLight % 3 == 0)
            {
                redlight = true;
              
            }
            else
            {
                redlight = false;
              
            }
            yield return new WaitForSeconds(timeFrame);
        }
    }
}
