using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        newPerson.transform.position = Vector3.zero;
        newPerson.GetComponent<Person>().InitPerson(FeelingManager.GetRandomFeeling());

        return newPerson;
    }
}
