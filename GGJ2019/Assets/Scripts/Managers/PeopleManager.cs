using System.Collections;
using System.Collections.Generic;
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

        float radius = 20;
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += newPerson.transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        newPerson.transform.position = finalPosition;

        newPerson.GetComponent<Person>().InitPerson(FeelingManager.GetRandomFeeling());

        return newPerson;
    }
}
