using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int currentLevel = 0;
    public static float levelStartTimeInSeconds = 0;
    public static float levelMaxTimeInSeconds = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public static void InitLevel(int level)
    {
        currentLevel = level;

        int numPeople = 0;
        if (level == 1)
        {
            levelMaxTimeInSeconds = 60;
            numPeople = 1;
            GameObject.Find("Camera Target").transform.position = new Vector3(9, 0, -4);
        }
        if (level == 2)
        {
            levelMaxTimeInSeconds = 120;
            numPeople = 5;
            GameObject.Find("Camera Target").transform.position = new Vector3(9, 0, -4);
        }

        for (int i = 0; i < numPeople; i++)
        {
            GameObject person = PeopleManager.CreatePerson();
            BuildingManager.CreateHomeFor(person);
        }

        // Start timer
        LevelManager.levelStartTimeInSeconds = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
