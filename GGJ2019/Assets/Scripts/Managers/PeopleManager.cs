﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public static Person CreatePerson()
    {
        GameObject newPerson = Instantiate(person);
        newPerson.transform.parent = people.transform;
        newPerson.transform.position = Vector3.zero;

        return null;
    }
}
