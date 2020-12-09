﻿using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.WSA;

public class CityGenerator : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();
    public GameObject roadFront,roadBack,crossRoad;
    public int width, height, buildingSpacing;
    private int[,] mapGrid;
    public GameObject player;
    private int area;
    private Vector3 startPos;
    private float updateTime;

    private List<GameObject> cityObjects;
    int halfWidth;
    private Dictionary<string,CityObj> cityObj = new Dictionary<string, CityObj>();
    private int halfHeight;
    
    // Start is called before the first frame update
    void Start()
    {
        halfHeight = height / 2;
        halfWidth = width / 2;
        updateTime = Time.realtimeSinceStartup;
        cityObjects = new List<GameObject>();
        area = width * height;
        startPos = Vector3.zero;
        transform.position = startPos;
        //float randomize = Random.Range(20, 100);
        mapGrid = new int[width,height];
        // generate perlin noise for city
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                mapGrid[w, h] = (int) (Mathf.PerlinNoise(w / 10.0f , h / 10.0f ) * 10);
            }
        }

       
        // make the streets
        CreateStreet();
        
        // make buildings
        CreateBuilding();

    }

    void CreateStreet()
    {
        int x = 0;
        for (int n = 0; n < 50; n++)
        {
            for (int h = 0; h < height; h++)
            {
                mapGrid[x, h] = -1;
            }

            x += Random.Range(3, 3);
            if(x >= width) break;
        }
        
        int z = 0;
        for (int n = 0; n < 10; n++)
        {
            for (int w = 0; w < width; w++)
            {
                if (mapGrid[w, z] == -1)
                    mapGrid[w, z] = -3;
                else
                    mapGrid[w, z] = -2;
            }

            z += Random.Range(3, 10);
            if (z >= height) break;
        }
    }

    void CreateBuilding()
    {
        
        for (int i = 0,w = -halfWidth; w < halfWidth ; w++)
        {
            for (int j = 0,h = -halfHeight; h < halfHeight; h++)
            {
                int choice = 100;
                int noise = mapGrid[i, j];
                //int noise = (int) (Mathf.PerlinNoise(w /10.0f + randomize, h /10.0f + randomize) * 10);
                Vector3 pos = new Vector3(player.transform.position.x+(w * buildingSpacing),0,player.transform.position.z + (h * buildingSpacing));
                if (noise < -2)
                {    
                    //string objName = "Cross Road " + ((int) (pos.x)).ToString() + " " + ((int) (pos.z)).ToString();
                    GameObject crossRoads = Instantiate(crossRoad, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity).gameObject;
                    //crossRoads.name = objName;
                    CityObj obj = new CityObj(updateTime,crossRoads);
                    //cityObj[objName] = obj;
                    cityObjects.Add(crossRoads);
                   // cityObj.Add(objName,obj);
                    

                }
                else if (noise < -1)
                {
                    //string objName = "Road back " + ((int) (pos.x)).ToString() + " " + ((int) (pos.z)).ToString();
                    GameObject roadbacks = Instantiate(roadBack, new Vector3(pos.x,-0.499f,pos.z), roadBack.transform.rotation).gameObject;
                   // roadbacks.name = objName;
                    CityObj obj = new CityObj(updateTime,roadbacks);
                    //cityObj[objName] = obj;
                    cityObjects.Add(roadbacks);
                    //cityObj.Add(objName,obj);
                }
                else if (noise < 0)
                {
                    //string objName = "Road Front " + ((int) (pos.x)).ToString() + " " + ((int) (pos.z)).ToString();
                    GameObject roadfronts = Instantiate(roadFront, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity).gameObject;
                    cityObjects.Add(roadfronts);
                    //roadfronts.name = objName;
                    CityObj obj = new CityObj(updateTime,roadfronts);
                    //cityObj[objName] = obj;
                    //cityObj.Add(objName,obj);
                }
                else if (noise < 2)
                {
                    choice = 0;
                }
                else if (noise < 4)
                {
                    choice = 1;
                }
                else if (noise < 6)
                {    
                    choice = 2;
                }
                else if (noise < 8)
                {
                    choice = 3;
                }
                else if (noise < 10)
                {
                    choice = 4;
                }

                if (choice < 10)
                {
                    GameObject buildingC = Instantiate(buildings[choice], pos, Quaternion.identity).gameObject;
                    cityObjects.Add(buildingC);
                    cityObjects.Add(buildingC);
                    //buildingC.name = Name;
                    CityObj buildingss = new CityObj(updateTime,buildingC);
                }
                //string Name = "Building 5 " + ((int) (pos.x)).ToString() + " " + ((int) (pos.z)).ToString();
               
                //cityObj[Name] = buildingss;
                //cityObj.Add(Name,buildingss);

                j++;
                
                Debug.Log(pos);
                
            }

            i++;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        int xMove = (int) (player.transform.position.x - startPos.x);
        int zMove = (int) (player.transform.position.z - startPos.z);

        /*if (Mathf.Abs(xMove) >= area || Mathf.Abs(zMove) >= area)
        {
            //int playerX = (int) (Mathf.Floor(player.transform.position.x / area) * area);
            //int playerZ = (int) (Mathf.Floor(player.transform.position.z / area) * area);

            foreach (GameObject obj in cityObjects)
            {
                Destroy(obj);
            }
            CreateStreet();
            CreateBuilding();
        }*/

       
    }
}
