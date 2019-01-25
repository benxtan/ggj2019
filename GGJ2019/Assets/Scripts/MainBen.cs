using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBen : MonoBehaviour
{
    public GameObject Tile;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject newTile = GameObject.Instantiate(Tile);
            newTile.transform.position = new Vector3(0.64f * i, -0.33f * i, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
