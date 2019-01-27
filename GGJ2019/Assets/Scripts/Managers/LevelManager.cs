using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 0;
    public static float levelStartTimeInSeconds = 0;
    public static float levelMaxTimeInSeconds = 0;

    void Start()
    {
    }

    public static void InitLevel(int level)
    {
        currentLevel = level;

        // Initialise level
        int numPeople = 0;
        if (level == 1)
        {
            levelMaxTimeInSeconds = 10;
            numPeople = 1;
            GameObject.Find("Camera Target").transform.position = new Vector3(9, 0, -4);
        }
        if (level == 2)
        {
            levelMaxTimeInSeconds = 120;
            numPeople = 5;
            GameObject.Find("Camera Target").transform.position = new Vector3(9, 0, -4);
        }

        // Create people and their respective homes
        for (int i = 0; i < numPeople; i++)
        {
            GameObject person = PeopleManager.CreatePerson();
            BuildingManager.CreateHomeFor(person);
        }

        // Set level start time
        LevelManager.levelStartTimeInSeconds = Time.time;
    }

    public static bool IsLevelRunning()
    {
        float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
        float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

        return LevelManager.currentLevel > 0 && timeRemaining > 0;
    }

    void Update()
    {
        if (LevelManager.currentLevel > 0)
        {
            float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
            float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

            if (timeRemaining <= 0)
            {
                // Times up!
                // TODO: turn off the nav mesh agent on all people to stop them from walking
                GameObject[] people = GameObject.FindGameObjectsWithTag("People");
                for (int i = 0; i < people.Length; i++)
                {
                    people[i].GetComponent<NavMeshAgent>().enabled = false;
                }
            }
        }
    }
}
