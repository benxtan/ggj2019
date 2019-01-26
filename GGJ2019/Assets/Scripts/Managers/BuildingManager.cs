using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] buildings;

    // Start is called before the first frame update
    void Start()
    {
        InitBuildings();
    }

    void InitBuildings()
    {
        buildings = GameObject.FindGameObjectsWithTag("Buildings");
        Debug.Log("Num Buildings: " + buildings.Length);

        // Assign feelings

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Building CreateHomeFor(GameObject person)
    {
        return null;
    }
}
