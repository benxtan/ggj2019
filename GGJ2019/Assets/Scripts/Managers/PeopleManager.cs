using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static FeelingManager;

public class PeopleManager : MonoBehaviour
{
    public GameObject personPrefab;
    public static GameObject person;
    public static GameObject parent;

    public static GameObject[] people;

    // Start is called before the first frame update
    void Start()
    {
        person = personPrefab;
        parent = GameObject.Find("People");
    }

    private void Update()
    {
    }

    public static GameObject CreatePerson()
    {
        GameObject newPerson = Instantiate(person);
        newPerson.transform.parent = parent.transform;
        newPerson.transform.position = GetRandomPersonPosition();
        newPerson.GetComponent<Person>().InitPerson(FeelingManager.GetRandomFeeling());

        newPerson.GetComponent<NavMeshAgent>().Warp(newPerson.transform.position);

        return newPerson;
    }

    public static Vector3 GetRandomPersonPosition()
    {
        // Get all objects with the tag "Road" and check if it is a child of the current Map
        GameObject[] roads = new List<GameObject>(GameObject.FindGameObjectsWithTag("Road")).FindAll(g => g.transform.IsChildOf(LevelManager.GetCurrentMap().transform)).ToArray();
        return roads[Random.Range(0, roads.Length)].transform.position;
    }

    public static void InitLevelPeople()
    {
        UpdateLevelPeople();
    }

    public static void UpdateLevelPeople()
    {
        PeopleManager.people = new List<GameObject>(GameObject.FindGameObjectsWithTag("People")).FindAll(g => g.activeSelf).ToArray();
        //Debug.Log("Num People: " + people.Length);
    }

    public static int GetNumActivePeople()
    {
        return new List<GameObject>(GameObject.FindGameObjectsWithTag("People")).FindAll(g => g.activeSelf).Count;
    }

    public static int GetNumPeopleAtHome()
    {
        return LevelManager.numLevelPeople - PeopleManager.GetNumActivePeople();
    }
}
