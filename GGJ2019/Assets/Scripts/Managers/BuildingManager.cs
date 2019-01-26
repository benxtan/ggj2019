using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static GameObject[] buildings;

    // Start is called before the first frame update
    void Start()
    {
        InitBuildings();
    }

    void InitBuildings()
    {
        buildings = GameObject.FindGameObjectsWithTag("Buildings");
        Debug.Log("Num Buildings: " + buildings.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject CreateHomeFor(GameObject person)
    {
        Feeling feeling = person.GetComponent<Person>().feeling;
        Debug.Log("TesT" + feeling.ToString());

        GameObject building = buildings[Random.Range(0, buildings.Length)];
        building = buildings[4];   // DEBUG
        building.GetComponent<Building>().feeling = feeling;
        Debug.Log("New Building:" + feeling.ToString());

        return building;
    }
}
