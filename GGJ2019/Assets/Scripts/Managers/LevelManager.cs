using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public static void InitLevel(int level)
    {
        currentLevel = level;

        if (level == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject person = PeopleManager.CreatePerson();
                BuildingManager.CreateHomeFor(person);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
