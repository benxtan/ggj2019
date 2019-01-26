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
        this.feeling = feeling;
        _feelingString = this.feeling.ToString();
        Debug.Log("111 New Person:" + feeling);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter:" + other.gameObject.tag);
        if (other.gameObject.tag == "Buildings" && other.gameObject.GetComponent<Building>().feeling != null)
        {
            if (other.gameObject.GetComponent<Building>().feeling.feelingType == feeling.feelingType)
            {
                Debug.Log("HOME!!!");
            }
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(collision);
    }*/
}
