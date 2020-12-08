using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                int noise = mapGrid[i, j];
                //int noise = (int) (Mathf.PerlinNoise(w /10.0f + randomize, h /10.0f + randomize) * 10);
                Vector3 pos = new Vector3(player.transform.position.x+(w * buildingSpacing),0,player.transform.position.z + (h * buildingSpacing));
                if (noise < -2)
                {
                    GameObject crossRoads = Instantiate(crossRoad, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity).gameObject;
                    cityObjects.Add(crossRoads);
                }
                else if (noise < -1)
                {
                    GameObject roadbacks = Instantiate(roadBack, new Vector3(pos.x,-0.499f,pos.z), roadBack.transform.rotation).gameObject;
                    cityObjects.Add(roadbacks);
                }
                else if (noise < 0)
                {
                    GameObject roadfronts = Instantiate(roadFront, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity).gameObject;
                    cityObjects.Add(roadfronts);
                }
                else if (noise < 2)
                {
                    GameObject building = Instantiate(buildings[0], pos, Quaternion.identity).gameObject;
                    cityObjects.Add(building);
                }
                else if (noise < 4)
                {
                    GameObject building = Instantiate(buildings[1], pos, Quaternion.identity).gameObject;
                    cityObjects.Add(building);
                }
                else if (noise < 6)
                {
                    GameObject building = Instantiate(buildings[2], pos, Quaternion.identity).gameObject;
                    cityObjects.Add(building);
                }
                else if (noise < 8)
                {
                    GameObject building = Instantiate(buildings[3], pos, Quaternion.identity).gameObject;
                    cityObjects.Add(building);
                }
                else if (noise < 10)
                {
                    GameObject building = Instantiate(buildings[4], pos, Quaternion.identity).gameObject;
                    cityObjects.Add(building);
                }
                
              Debug.Log(pos);
                
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        /*int xMove = (int) (player.transform.position.x - startPos.x);
        int zMove = (int) (player.transform.position.z - startPos.z);

        if (Mathf.Abs(xMove) >= area || Mathf.Abs(zMove) >= area)
        {
            //int playerX = (int) (Mathf.Floor(player.transform.position.x / area) * area);
            //int playerZ = (int) (Mathf.Floor(player.transform.position.z / area) * area);

            //CreateStreet();
            //CreateBuilding();
        }

        /*foreach (GameObject cityobj in cityObjects){}
        {
            
        }*/
    }
}
