using UnityEngine;

public class Person : MonoBehaviour
{
    public float health;
    public Feeling feeling;

    [SerializeField]
    private string _feelingString;   // This is visible in the Inspector
    public string feelingString
    {
        get
        {
            return feeling.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void InitPerson(Feeling feeling)
    {
        feeling = FeelingManager.GetRandomFeeling();
        _feelingString = feeling.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Debug.Log(other);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(collision);
    }
}
