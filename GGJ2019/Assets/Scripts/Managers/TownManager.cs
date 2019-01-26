using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownManager : MonoBehaviour
{
    public GameObject grass;

    private int townWidth = 25;
    private int townHeight = 25;

    private GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = GameObject.Find("Environment");
        
        CreateGrassTown();

        string map =
           "GRRRRRRRRRRRRRRRRRRRRRRRG" +
           "GRGGGGGGGGGGGGGGGGGGGGGRG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG" +
           "GGGGGGGGGGGGGGGGGGGGGGGGG";

        //CreateTown(map);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateGrassTown()
    {
        for (int x = 0; x < townWidth; x++)
        {
            for (int z = 0; z < townHeight; z++)
            {
                GameObject newGrass = Instantiate(grass);
                newGrass.transform.parent = parent.transform;
                newGrass.transform.position = new Vector3(x * 2, 0, z * 2);
            }
        }
    }

    private void CreateTown(string map)
    {
        for (int x = 0; x < townWidth; x++)
        {
            for (int z = 0; z < townHeight; z++)
            {

            }
        }
    }
}
