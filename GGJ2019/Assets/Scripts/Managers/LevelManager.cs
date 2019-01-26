using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        InitLevel(1);
    }

    void InitLevel(int level)
    {
        currentLevel = 1;
        PeopleManager.CreatePerson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
