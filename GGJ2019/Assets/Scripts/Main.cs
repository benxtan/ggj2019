using UnityEngine;

public class Main : MonoBehaviour
{
    public static bool IS_DEBUG = false;
    public static int DEBUG_TEST_LEVEL = 3;

    // Set to true to run a version with the big map, no time limit and 99 people
    public static bool DEBUG_INFINITE_VERSION = false;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World!");
    }

    // Update is called once per frame
    void Update()
    {
    }
}
