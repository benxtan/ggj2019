using UnityEngine;
using UnityEngine.AI;
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
        newPerson.transform.position = GetRandomPosition();
        newPerson.GetComponent<Person>().InitPerson(FeelingManager.GetRandomFeeling());

        return newPerson;
    }

    public static Vector3 GetRandomPosition()
    {
        float radius = 20;
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        //randomDirection += newPerson.transform.position;

        NavMeshHit hit;
        Vector3 randomPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            randomPosition = hit.position;
        }

        return randomPosition;
    }
}
