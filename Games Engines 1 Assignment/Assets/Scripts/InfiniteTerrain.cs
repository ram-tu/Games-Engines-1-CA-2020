using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
public class InfiniteTerrain : MonoBehaviour
{
    public GameObject tilePrefab1,
        tilePrefab2,
        tilePrefab3,tilePrefab4,
        tilePrefab5,
        tilePrefab6,tilePrefab7,
        tilePrefab8;
    public Transform player;
    public int quadsPerTile;

    public int halfTile = 5;

    // Use this for initialization

    private int[,] mapGrid;
    private int fullTile;
    public int width, height;
    private int Hwidth, Hheight;
    void Start()
    {


        Hheight = height / 2;
        Hwidth = width / 2;
        if (player == null)
        {
            player = Camera.main.transform;
        }
        CreateNoise();
        StartCoroutine(GenerateWorldAroundPlayer());

    }
    
    void CreateNoise()
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

    Queue<GameObject> oldGameObjects = new Queue<GameObject>();
    Dictionary<string, Tile> tiles = new Dictionary<string, Tile>();

    private IEnumerator GenerateWorldAroundPlayer()
    {        
        // Make sure this happens at once at the start
        int xMove = int.MaxValue;
        int zMove = int.MaxValue;

        // Adapted from https://www.youtube.com/watch?v=dycHQFEz8VI

        while (true)
        {
            if (oldGameObjects.Count > 0)
            {
                GameObject.Destroy(oldGameObjects.Dequeue());
            }
            if (Mathf.Abs(xMove) >= quadsPerTile|| Mathf.Abs(zMove) >= quadsPerTile)
            {
                Debug.Log("Noise from Grid");
                StringBuilder sb = new StringBuilder();
                for(int i=0; i< mapGrid .GetLength(1); i++)
                {
                    for(int j=0; j<mapGrid .GetLength(0); j++)
                    {
                        sb.Append(mapGrid [i,j]);
                        sb.Append(' ');				   
                    }
                    sb.AppendLine();
                }
                Debug.Log(sb.ToString());
                float updateTime = Time.realtimeSinceStartup;
                
                

                //force integer position and round to nearest tilesize
                int playerX = (int)(Mathf.Floor((player.transform.position.x) / (quadsPerTile)) * quadsPerTile);
                int playerZ = (int)(Mathf.Floor((player.transform.position.z) / (quadsPerTile)) * quadsPerTile);
                List<Vector3> newTiles = new List<Vector3>();
                List<int> tileNoise = new List<int>();

                for (int i = 0, x = -Hwidth; x < Hwidth; x++)
                {
                    for (int j = 0, z = -Hheight; z < Hheight; z++)
                    {
                        int noise = mapGrid[i,j];
                        Vector3 pos = new Vector3((x * quadsPerTile + playerX),
                            0,
                            (z * quadsPerTile + playerZ));
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        if (!tiles.ContainsKey(tilename))
                        {
                            newTiles.Add(pos);
                            tileNoise.Add(noise);
                        }
                        else
                        {
                            (tiles[tilename] as Tile).creationTime = updateTime;
                        }
                        j++;
                    }
                    i++;
                }
                // Sort in order of distance from the player
                //newTiles.Sort((a, b) => (int)Vector3.SqrMagnitude(player.transform.position - a) - (int)Vector3.SqrMagnitude(player.transform.position - b));
                int noiseIndex = 0;
                Debug.Log("Noise from Index");
                StringBuilder nb = new StringBuilder();
                for(int i=0; i<  tileNoise.Count; i++)
                {
                    nb.Append(newTiles[i] + "->" + tileNoise[i]);
                    nb.Append(' ');				   
                    
                    nb.AppendLine();
                }
                Debug.Log(nb.ToString());
                foreach (Vector3 pos in newTiles)
                {
                    GameObject t;
                    if (tileNoise[noiseIndex] < -2)
                    {
                        t = GameObject.Instantiate<GameObject>(tilePrefab1, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < -1)
                    {
                        t = GameObject.Instantiate<GameObject>(tilePrefab2, pos, tilePrefab2.transform.rotation);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < 0)
                    { 
                        t = GameObject.Instantiate<GameObject>(tilePrefab3, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < 2)
                    { 
                        t = GameObject.Instantiate<GameObject>(tilePrefab4, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < 4)
                    { 
                        t = GameObject.Instantiate<GameObject>(tilePrefab5, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < 6)
                    { 
                        t = GameObject.Instantiate<GameObject>(tilePrefab6, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < 8)
                    { 
                        t = GameObject.Instantiate<GameObject>(tilePrefab7, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    else if (tileNoise[noiseIndex] < 10)
                    { 
                        t = GameObject.Instantiate<GameObject>(tilePrefab8, pos, Quaternion.identity);
                        t.transform.parent = this.transform;
                        string tilename = "Tile_" + ((int)(pos.x)).ToString() + "_" + ((int)(pos.z)).ToString();
                        t.name = tilename;
                        Tile tile = new Tile(t, updateTime);
                        tiles[tilename] = tile;
                    }
                    noiseIndex++;
                    yield return null;
                }

                //destroy all tiles not just created or with time updated
                //and put new tiles and tiles to be kepts in a new hashtable
                Dictionary<string, Tile> newTerrain = new Dictionary<string, Tile>();
                foreach (Tile tile in tiles.Values)
                {
                    if (tile.creationTime != updateTime)
                    {
                        oldGameObjects.Enqueue(tile.theTile);
                    }
                    else
                    {
                        newTerrain[tile.theTile.name] = tile;
                    }
                }
                //copy new hashtable contents to the working hashtable
                tiles = newTerrain;
                startPos = player.transform.position;
            }
            yield return null;
            //determine how far the player has moved since last terrain update
            xMove = (int)(player.transform.position.x - startPos.x);
            zMove = (int)(player.transform.position.z - startPos.z);
        }
    }

    Vector3 startPos;

    class Tile
    {
        public GameObject theTile;
        public float creationTime;


        public Tile(GameObject t, float ct)
        {
            theTile = t;
            creationTime = ct;
        }
    }


}