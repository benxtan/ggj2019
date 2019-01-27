using UnityEngine;
using UnityEngine.AI;

public class LevelManager : MonoBehaviour
{
    public static int numLevels = 3;

    public static int currentLevel = 0;
    public static float levelStartTimeInSeconds = 0;
    public static float levelMaxTimeInSeconds = 0;
    public static float levelFinishedTimeInSeconds = 0;

    private static GameObject map01;
    private static GameObject map02;

    public static bool isLevelRunning = false;
    private static bool isTimesUpDone = false;

    public static int numLevelPeople;

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

        levelStartTimeInSeconds = 0;
        levelMaxTimeInSeconds = 0;
        levelFinishedTimeInSeconds = 0;

        isTimesUpDone = false;

        // Destroy all people
        GameObject[] people = GameObject.FindGameObjectsWithTag("People");
        for (int i = 0; i < people.Length; i++)
        {
            Destroy(people[i]);
        }
          
        // Initialise level
        numLevelPeople = 0;
        if (level == 1)
        {
            InitMap(1);
            levelMaxTimeInSeconds = 60;
            numLevelPeople = 1;
        }
        else if (level == 2)
        {
            InitMap(1);
            levelMaxTimeInSeconds = 60;
            numLevelPeople = 2;
        }
        else if (level == 3)
        {
            InitMap(2);
            levelMaxTimeInSeconds = 120;
            numLevelPeople = 4;
        }

        // DEBUG
        //levelMaxTimeInSeconds = 5;

        // Initialise buildings for this level
        BuildingManager.InitLevelBuildings();
    }

    public static void InitMap(int map)
    {
        Vector3 cameraTargetPosition;
        int orthographicSize;

        if (map == 1)
        {
            cameraTargetPosition = new Vector3(9, 0, -4);
            orthographicSize = 6;
        }
        else
        {
            cameraTargetPosition = new Vector3(54, 0, -24);
            orthographicSize = 10;
        }

        // Map prefabs
        map01.SetActive(map == 1);
        map02.SetActive(map == 2);

        // Camera
        GameObject.Find("Camera Target").transform.position = cameraTargetPosition;
        Camera.main.orthographicSize = orthographicSize;
    }

    public static void StartLevel()
    {
        isTimesUpDone = false;

        // Create people and their respective homes
        for (int i = 0; i < numLevelPeople; i++)
        {
            GameObject person = PeopleManager.CreatePerson();
            BuildingManager.CreateHomeFor(person);
        }

        // Initialise people for this level
        PeopleManager.InitLevelPeople();

        // Set level start time
        LevelManager.levelStartTimeInSeconds = Time.time;

        LevelManager.isLevelRunning = true;
    }

    /*public static bool IsLevelRunning()
    {
        float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
        float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

        return LevelManager.currentLevel > 0 && timeRemaining > 0;
    }*/

    public static GameObject GetCurrentMap()
    {
        if (currentLevel == 1 || currentLevel == 2)
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
        if (LevelManager.isLevelRunning)
        {
            float timeElapsed = Time.time - LevelManager.levelStartTimeInSeconds;
            float timeRemaining = LevelManager.levelMaxTimeInSeconds - timeElapsed;

            if (timeRemaining <= 0)
            {
                isTimesUpDone = true;

                // Times up
                LevelManager.isLevelRunning = false;

                // TODO: turn off the nav mesh agent on all people to stop them from walking
                GameObject[] people = GameObject.FindGameObjectsWithTag("People");
                for (int i = 0; i < people.Length; i++)
                {
                    people[i].GetComponent<NavMeshAgent>().enabled = false;
                    people[i].GetComponent<WanderAI>().enabled = false;
                }
            }
            else
            {
                // TODO: Check if there are any people left roaming around
                if (PeopleManager.people.Length == 0)
                {
                    // You finished the level in time!
                    levelFinishedTimeInSeconds = timeRemaining;

                    // All the people got home
                    LevelManager.isLevelRunning = false;
                }
            }

        }
    }
}
