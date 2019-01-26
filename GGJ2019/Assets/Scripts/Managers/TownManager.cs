using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public GameObject grassTile;
    public GameObject[] roadTiles;
    public GameObject[] houseTiles;

    private int townWidth = 25;
    private int townHeight = 25;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Environment");
        
        //CreateGrassTown();

        string map =
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GRRRGGGGHHHGHGHGHGGGGGGGG" +
           "GRGRHGRRRRRRRRRRRRHGGGGGG" +
           "GRHRGHRHHRHHRHHRGRRGHGHGG" +
           "GRGRHGRGGRGGRGGRHGRRRRRRG" +
           
           "GRHRGHRHHRHHRHHRGGHRHGHRG" +
           "GRGRHGRGGRGGRGGRHGGRGGGRG" +
           "GRHRGHRHHRHHRHHRGGHRHGHRG" +
           "GRGRHGRGGRGGRGGRHGGRGGGRG" +
           "GRHRGHRHHRHHRHHRGGHRHGHRG" +

           "GRRRHGRGGRGGRGGRHGGRGGGRG" +
           "GRHRGGRHHRHHRHHRGGHRHGHRG" +
           "GRGRRRRRRRRRRRRRRRRRRRRRG" +
           "GRHRGGGGGRGGGGGRGGGGGGGRG" +
           "GRGRRRRRRRRRRRRRRRRRRRRRG" +
           
           "GRHRGHGRGHGRGGGRGGGRGGGRG" +
           "GRGRHGHRHGHRHGHRGGGRGHRRG" +
           "GRRRGGGRGGGRGGGRGGGRGGGRG" +
           "GRHRHGHRHGHRHGHRGGGRGHRRG" +
           "GRHRGGGRGGGRGGGRGGGRGGGRG" +
           
           "GRGRHGHRHGHRGHRRGGGRRGGRG" +
           "GRHRGGGRGGGRGRRGGGGGRRGRG" +
           "GRHRGHGRGHGRRRHGGGGGGRRRG" +
           "GRRRRRRRRRRRGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG";

        //CreateTown(map);

        townWidth = 10;
        townHeight = 5;
        string map2 =
            "RRRRRRRRRR" +
            "RHRHGGHRHR" +
            "RHRHGGHRHR" +
            "RHRHGGHRHR" +
            "RRRRRRRRRR";

        CreateTown(map2);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateGrassTown()
    {
        for (int z = 0; z < townHeight; z++)
        {
            for (int x = 0; x < townWidth; x++)
            {
                GameObject newGrass = Instantiate(grassTile);
                newGrass.transform.parent = parent.transform;
                newGrass.transform.position = new Vector3(x * 2, 0, z * 2);
            }
        }
    }

    private void CreateTown(string map)
    {
        // 0 0 0
        // 0 R 0
        // 0 0 0

        for(int y = 0; y < townHeight; y++)
        {
            for (int x = 0; x < townWidth; x++)
            {
                string mapCharacter = GetMapCharacterAt(map, x, y);

                if (mapCharacter == "R")
                {
                    string grid = GetRoadGrid(map, x, y);

                    // T right
                    if (grid == "1110") CreateTile(roadTiles[0], x, y);
                    // T left
                    else if (grid == "1011") CreateTile(roadTiles[1], x, y);
                    // T down
                    else if (grid == "0111") CreateTile(roadTiles[2], x, y);
                    // T up
                    else if (grid == "1101") CreateTile(roadTiles[3], x, y);

                    // Cross
                    else if (grid == "1111") CreateTile(roadTiles[Random.Range(4, 5)], x, y);   // 2 crosses

                    // Straight Up
                    else if (grid == "1010") CreateTile(roadTiles[6], x, y);
                    // Straight Across
                    else if (grid == "0101") CreateTile(roadTiles[7], x, y);

                    // Corner Down Right
                    else if (grid == "0110") CreateTile(roadTiles[8], x, y);
                    // Corner Down Left
                    else if (grid == "0011") CreateTile(roadTiles[9], x, y);
                    // Corner Up Right
                    else if (grid == "1100") CreateTile(roadTiles[10], x, y);
                    // Corner Up Left
                    else if (grid == "1001") CreateTile(roadTiles[11], x, y);

                }
                else if (mapCharacter == "H")
                {
                    CreateTile(grassTile, x, y);
                    CreateTile(houseTiles[0], x, y);
                }
                else
                {
                    CreateTile(grassTile, x, y);
                }
            }
        }
    }

    private string GetMapCharacterAt(string map, int x, int y)
    {
        return map.Substring(x + (y * townWidth), 1);
    }

    // Returns a string of the NSEW values, e.g. 0000, 0100, etc.
    private string GetRoadGrid(string map, int x, int y)
    {
        string grid = "";

        // --------------------------------------------------------------------

        // Top left
        if (x == 0 || y == 0) grid += "0";
        else grid += IsRoad(map, x - 1, y - 1) ? "1" : "0";

        // Top middle
        if (y == 0) grid += "0";
        else grid += IsRoad(map, x, y - 1) ? "1" : "0";

        // Top right
        if (x == townWidth - 1 || y == 0) grid += "0";
        else grid += IsRoad(map, x + 1, y - 1) ? "1" : "0";

        // --------------------------------------------------------------------

        // Left
        if (x == 0) grid += "0";
        else grid += IsRoad(map, x - 1, y) ? "1" : "0";

        grid += "1";

        // Right
        if (x == townWidth - 1) grid += "0";
        else grid += IsRoad(map, x + 1, y) ? "1" : "0";

        // --------------------------------------------------------------------

        // Bottom left
        if (x == 0 || y == townHeight - 1) grid += "0";
        else grid += IsRoad(map, x - 1, y + 1) ? "1" : "0";

        // Bottom middle
        if (y == townHeight - 1) grid += "0";
        else grid += IsRoad(map, x, y + 1) ? "1" : "0";

        // Bottom right
        if (x == townWidth - 1 || y == townHeight - 1) grid += "0";
        else grid += IsRoad(map, x + 1, y + 1) ? "1" : "0";

        // --------------------------------------------------------------------

        Debug.Log(grid);

        // Just return NESW values - e.g. 0000
        // 0 1 2
        // 3 4 5
        // 6 7 8
        grid = grid.Substring(1, 1) + grid.Substring(5, 1) + grid.Substring(7, 1) + grid.Substring(3, 1);

        return grid;
    }

    // Check if there is a road at (x, y)
    private bool IsRoad(string map, int x, int y)
    {
        string charAt = GetMapCharacterAt(map, x, y);
        return charAt == "R" || charAt == "H";
    }

    private void CreateTile(GameObject go, int x, int y)
    {
        GameObject tile = Instantiate(go);
        tile.transform.parent = parent.transform;
        tile.transform.position = new Vector3(x * 2, 0, -y * 2 - 10);
    }
}
