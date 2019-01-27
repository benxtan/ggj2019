using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject[] cloudPrefabs;

    private int maxClouds = 100;
    private int numClouds = 0;
    private float lastSpawnTime = -1;
    public int spawnInterval = 4;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float interval = numClouds < 10 ? 0 : spawnInterval;

        if (numClouds < maxClouds && (lastSpawnTime == -1 || Time.time - lastSpawnTime >= interval))
        {
            GameObject newCloud = Instantiate(cloudPrefabs[Random.Range(0, cloudPrefabs.Length)]);

            float y = Random.Range(5.0f, 12.0f);
            newCloud.transform.parent = this.gameObject.transform;
            newCloud.transform.position = new Vector3(Random.Range(-10, 30), y, Random.Range(-20, 10));
            newCloud.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            newCloud.GetComponent<Cloud>().speed = y / 40.0f;

            numClouds++;

            lastSpawnTime = Time.time;
        }
    }
}
