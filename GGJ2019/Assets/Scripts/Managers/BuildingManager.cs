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
        BuildingManager.buildings = GameObject.FindGameObjectsWithTag("Buildings");
        Debug.Log("Num Buildings: " + buildings.Length);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject CreateHomeFor(GameObject person)
    {
        GameObject[] emptyBuildings = BuildingManager.GetEmptyBuildings();
        //Debug.Log(emptyBuildings.Length);

        if (emptyBuildings.Length == 0)
        {
            Debug.LogError("NO MORE EMPTY BUILDINGS :(");
            return null;
        }

        Feeling feeling = person.GetComponent<Person>().feeling;

        GameObject building = emptyBuildings[Random.Range(0, emptyBuildings.Length)];

        if (!building.GetComponent<Building>().IsEmpty()) Debug.LogError("BUILDING ALREADY ASSIGNED!!!");

        //Debug.Log(building.name + " " + building.GetComponent<Building>().IsEmpty());
        building.GetComponent<Building>().feeling = feeling;
        //Debug.Log("New Building:" + feeling.ToString());

        return building;
    }

    public static GameObject[] GetEmptyBuildings()
    {
        //GameObject[] buildings = GameObject.FindGameObjectsWithTag("Buildings");

        List<GameObject> emptyBuildings = new List<GameObject>();
        for (int i = 0; i < BuildingManager.buildings.Length; i++)
        {
            if (BuildingManager.buildings[i].GetComponent<Building>().IsEmpty())
            {
                emptyBuildings.Add(BuildingManager.buildings[i]);
            }
        }

        return emptyBuildings.ToArray();
    }

    public static int GetNumEmptyBuildings()
    {
        int numEmptyBuildings = 0;

        for (int i = 0; i < buildings.Length; i++)
        {
            if (buildings[i].GetComponent<Building>().IsEmpty())
            {
                numEmptyBuildings++;
            }
        }

        Debug.Log(numEmptyBuildings);

        return numEmptyBuildings;
    }
}
