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
        Debug.Log("New Person:" + feeling);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter:" + other.gameObject.tag);
        if (other.gameObject.tag == "Buildings")
        {
            Building building = other.gameObject.GetComponent<Building>();

            if (building.feeling != null)
            {
                if (building.feeling.feelingType == feeling.feelingType)
                {
                    Debug.Log("HOME!!!");

                    // Audio
                    other.gameObject.transform.Find("Audio/Home").GetComponent<AudioSource>().Play();

                    // Building - Change texture
                    building.SetOn(true);

                    // Person - Disappear
                    Destroy(this.gameObject);
                }
            }
        }
    }

    /*void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
        Debug.Log(collision);
    }*/
}
