using UnityEngine;
using UnityEngine.AI;
using static FeelingManager;

public class PeopleManager : MonoBehaviour
{
    public GameObject personPrefab;
    public static GameObject person;
    public static GameObject people;

    // Start is called before the first frame update
    void Start()
    {
        person = personPrefab;
        people = GameObject.Find("People");
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static GameObject CreatePerson()
    {
        GameObject newPerson = Instantiate(person);
        newPerson.transform.parent = people.transform;
        newPerson.transform.position = GetRandomPosition();
        newPerson.GetComponent<Person>().InitPerson(FeelingManager.GetRandomFeeling());

        newPerson.GetComponent<NavMeshAgent>().Warp(newPerson.transform.position);

        return newPerson;
    }

    public static Vector3 GetRandomPosition()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("Road");
        return roads[Random.Range(0, roads.Length)].transform.position;
    }
}
