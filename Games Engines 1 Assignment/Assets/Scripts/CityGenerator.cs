using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.WSA;
using Random = UnityEngine.Random;

public class CityGenerator : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();
    public GameObject roadFront,roadBack,crossRoad;
    public int width, height, buildingSpacing;
    private int[,] mapGrid;
    public GameObject player;
    private int area;
    private Vector3 startPos;
    

   
    int halfWidth;
    private Dictionary<string, CityObj> cityObj;
    private int halfHeight;
    Queue<GameObject> oldObjects =new Queue<GameObject>();

   
    
    // Start is called before the first frame update
    void Start()
    {
       
        halfHeight = height / 2;
        halfWidth = width / 2;

   
        startPos = Vector3.zero;
        transform.position = startPos;
        //float randomize = Random.Range(20, 100);
        //mapGrid = new int[width,height];
        // generate perlin noise for city


        area = width * height;
     
        // make the streets
        CreateStreet();
        StartCoroutine(GenerateCity());
        

        // make buildings
        // CreateBuilding();

    }

    void CreateStreet()
    {
        mapGrid = new int[width,height];
        for (int h = 0; h < height; h++)
        {
            for (int w = 0; w < width; w++)
            {
                mapGrid[w, h] = (int) (Mathf.PerlinNoise(w / 10.0f , h / 10.0f ) * 10);
            }
        }
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

    
    

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GenerateCity()
    {
       
        int xMove = int.MaxValue;
        int zMove = int.MaxValue;
        while (true)
        {
            
            
            if (oldObjects.Count > 0)
            {
                Destroy(oldObjects.Dequeue());
            }

          

            if (Mathf.Abs(xMove) >= buildingSpacing || Mathf.Abs(zMove) >= buildingSpacing)
            {
                float updateTime = Time.realtimeSinceStartup;
                int playerX = (int) (Mathf.Floor(player.transform.position.x / buildingSpacing) * buildingSpacing);
                int playerZ = (int) (Mathf.Floor(player.transform.position.z / buildingSpacing) * buildingSpacing);
                
                //CreateStreet();
                cityObj = new Dictionary<string, CityObj>();
                List<int>newCities = new List<int>();
                List<Vector3>positions = new List<Vector3>();
                for (int i = 0,w = -halfWidth; w < halfWidth ; w++)
                {
                    for (int j = 0,h = -halfHeight; h < halfHeight; h++)
                    {
                    
                        int choice = 100;
                        int noise = mapGrid[i, j];
                        Vector3 pos = new Vector3(playerX+(w * buildingSpacing),0, playerZ+(h * buildingSpacing));
                        if (noise < -2)
                        {    
                          
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                            if (!cityObj.ContainsKey(tilename))
                            {
                                
                                newCities.Add(noise);
                                positions.Add(pos);
                            }
                            else
                            {
                                (cityObj[tilename] as CityObj).creationTime = updateTime;
                            }
                        }
                        else if (noise < -1)
                        {
                           
                           
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                            
                            if (!cityObj.ContainsKey(tilename))
                            {
                                newCities.Add(noise);
                                positions.Add(pos);
                            }
                            else
                            {
                                (cityObj[tilename] as CityObj).creationTime = updateTime;
                            }
                   
                        }
                        else if (noise < 0)
                        {
                            
                            
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                   
                            if (!cityObj.ContainsKey(tilename))
                            {
                                newCities.Add(noise);
                                positions.Add(pos);
                            }
                            else
                            {
                                (cityObj[tilename] as CityObj).creationTime = updateTime;
                            }
                    
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
                           
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                            if (!cityObj.ContainsKey(tilename))
                            {
                                newCities.Add(noise);
                                positions.Add(pos);
                            }
                            else
                            {
                                (cityObj[tilename] as CityObj).creationTime = updateTime;
                            }
                           
                        }
                        j++;
                    }
                    i++;
                }
                int posI = 0;
               
                foreach (int noise in newCities)
                {
                        
                        int choice = 100;
                        Vector3 pos = positions[posI];
                    
                        if (noise < -2)
                        {    
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                            GameObject crossRoads = Instantiate(crossRoad, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity).gameObject;
                            crossRoads.name = tilename;
                            CityObj obj = new CityObj(updateTime,crossRoads,crossRoads.transform.position,Quaternion.identity);
                            cityObj[tilename] = obj;
                        }
                        else if (noise < -1)
                        {
                           string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                           GameObject roadbacks = Instantiate(roadBack, new Vector3(pos.x,-0.499f,pos.z), roadBack.transform.rotation).gameObject;
                           roadbacks.name = tilename;
                           CityObj obj = new CityObj(updateTime,roadbacks,roadbacks.transform.position,roadBack.transform.rotation);
                           cityObj[tilename] = obj;

                        }
                        else if (noise < 0)
                        {
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                            GameObject roadfronts = Instantiate(roadFront, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity).gameObject;
                           
                            roadfronts.name = tilename;
                            CityObj obj = new CityObj(updateTime,roadfronts,roadfronts.transform.position,Quaternion.identity);
                            cityObj[tilename] = obj;
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
                            string tilename = "Road" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                            GameObject building = Instantiate(buildings[choice], pos, Quaternion.identity).gameObject;
                     
                            building.name = tilename;
                            CityObj obj = new CityObj(updateTime,building,pos,Quaternion.identity);
                            cityObj[tilename] = obj;
                        }

                        posI++;
                }
          
              
                Dictionary<string,CityObj>newObjects = new Dictionary<string, CityObj>();
                foreach (CityObj obj in cityObj.Values)
                {
                   
                    if (obj.creationTime != updateTime)
                    {
                    
                        oldObjects.Enqueue(obj.prefab);
                        Debug.Log("Added in " + obj.prefab.name);
                    }
                    else
                    { 
                        newObjects[obj.prefab.name] = obj;
                    }
                }

                
                cityObj = newObjects;
                startPos = player.transform.position;
              
            }
            yield return null;
            //determine how far the player has moved since last terrain update
             xMove = (int)(player.transform.position.x - startPos.x);
             zMove = (int)(player.transform.position.z - startPos.z);
            
        }

      
    }
    
}
