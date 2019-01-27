using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static int numLevels = 2;

    public static int currentLevel = 0;
    public static float levelStartTimeInSeconds = 0;
    public static float levelMaxTimeInSeconds = 0;

    private static GameObject map01;
    private static GameObject map02;

    private static bool isTimesUpDone = false;

    private static int numPeople;

    void Start()
    {
        map01 = GameObject.Find("Map01");
        map01.SetActive(true);

        map02 = GameObject.Find("Map02");
        map02.SetActive(false);
        
        LevelManager.InitNextLevel();
    }

    public static void InitNextLevel()
    {
        InitLevel(currentLevel + 1);
    }

    public static void InitLevel(int level)
    {
        currentLevel = level;

        isTimesUpDone = false;

        // Destroy all people
        GameObject[] people = GameObject.FindGameObjectsWithTag("People");
        for (int i = 0; i < people.Length; i++)
        {
            Destroy(people[i]);
        }
          
        // Initialise level
        numPeople = 0;
        if (level == 1)
        {
            map01.SetActive(true);
            map02.SetActive(false);

            levelMaxTimeInSeconds = 2;
            numPeople = 1;
            GameObject.Find("Camera Target").transform.position = new Vector3(9, 0, -4);
            Camera.main.orthographicSize = 6;
        }
        if (level == 2)
        {
            map01.SetActive(false);
            map02.SetActive(true);

            levelMaxTimeInSeconds = 2;
            numPeople = 5;
            GameObject.Find("Camera Target").transform.position = new Vector3(54, 0, -24);
            Camera.main.orthographicSize = 10;
        }

        // Buildings
        BuildingManager.InitLevelBuildings();
    }

    public static void StartLevel()
    {
        isTimesUpDone = false;

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

    public static GameObject GetCurrentMap()
    {
        if (currentLevel == 1)
        {
            return map01;
        }
        else
        {
            return map02;
        }
    }

    void Update()
    {
        if (LevelManager.currentLevel > 0)
        {
            if (!isTimesUpDone)
            {
                float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
                float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

                if (timeRemaining <= 0)
                {
                    isTimesUpDone = true;

                    // Times up!
                    // TODO: turn off the nav mesh agent on all people to stop them from walking
                    GameObject[] people = GameObject.FindGameObjectsWithTag("People");
                    for (int i = 0; i < people.Length; i++)
                    {
                        people[i].GetComponent<NavMeshAgent>().enabled = false;
                        people[i].GetComponent<WanderAI>().enabled = false;
                    }
                }
            }
        }
    }
}
