using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    public List<GameObject> buildings = new List<GameObject>();
    public GameObject roadFront,roadBack,crossRoad;
    public int width, height, buildingSpacing;
    private int[,] mapGrid;
    // Start is called before the first frame update
    void Start()
    {
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

        
        // make buildings
       
        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                int noise = mapGrid[w, h];
                //int noise = (int) (Mathf.PerlinNoise(w /10.0f + randomize, h /10.0f + randomize) * 10);
                Vector3 pos = new Vector3(w * buildingSpacing,0,h * buildingSpacing);
                if (noise < -2)
                    Instantiate(crossRoad, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity);
                else if (noise < -1)
                    Instantiate(roadBack, new Vector3(pos.x,-0.499f,pos.z), roadBack.transform.rotation);
                else if (noise < 0)
                    Instantiate(roadFront, new Vector3(pos.x,-0.499f,pos.z), Quaternion.identity);
                else if (noise < 2)
                    Instantiate(buildings[0], pos, Quaternion.identity);
                else if (noise < 4)
                    Instantiate(buildings[1], pos, Quaternion.identity);
                else if (noise < 6)
                    Instantiate(buildings[2], pos, Quaternion.identity);
                else if (noise < 8)
                    Instantiate(buildings[3], pos, Quaternion.identity);
                else if (noise < 10)
                    Instantiate(buildings[4], pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
