using UnityEngine;

public class Person : MonoBehaviour
{
    public float health;
    public Feeling feeling;

    public string feelingString
    {
        get
        {
            return feeling.ToString();
        }
        set
        {

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
}
