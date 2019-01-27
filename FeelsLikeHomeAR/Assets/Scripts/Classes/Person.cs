using UnityEngine;

public class Person : MonoBehaviour
{
    public float health;
    public Feeling feeling;

    public Sprite[] icons;

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

        // Set bubble icon
        int iconIndex = 0;
        if (feeling.feelingType == FeelingManager.FeelingType.Beer) iconIndex = 0;
        else if (feeling.feelingType == FeelingManager.FeelingType.Fish) iconIndex = 1;
        else if (feeling.feelingType == FeelingManager.FeelingType.Love) iconIndex = 2;
        else if (feeling.feelingType == FeelingManager.FeelingType.Game) iconIndex = 3;
        else if (feeling.feelingType == FeelingManager.FeelingType.Gym) iconIndex = 4;
        else if (feeling.feelingType == FeelingManager.FeelingType.Sleep) iconIndex = 5;
        else if (feeling.feelingType == FeelingManager.FeelingType.Bath) iconIndex = 6;
        gameObject.transform.Find("Bubble/Icon").GetComponent<SpriteRenderer>().sprite = icons[iconIndex];
        gameObject.transform.Find("Bubble/MinimapIcon").GetComponent<SpriteRenderer>().sprite = icons[iconIndex];

        //Debug.Log("New Person:" + feeling);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("OnTriggerEnter:" + other.gameObject.tag);
        if (other.gameObject.tag == "Buildings")
        {
            Building building = other.gameObject.GetComponent<Building>();

            if (building.feeling != null && !building.isPersonHome)
            {
                // Check if the person has reached their designated home
                if (building.feeling.feelingType == feeling.feelingType)
                {
                    Debug.Log("HOME!!!");

                    // Audio
                    other.gameObject.transform.Find("Audio/Home").GetComponent<AudioSource>().Play();

                    // Grass
                    TownManager.CreateLitGrassTile(other.gameObject.transform.localPosition);

                    // Building
                    building.SetPersonHome();

                    // Person - Disappear
                    gameObject.SetActive(false);
                    PeopleManager.UpdateLevelPeople();
                    UIManager.UpdatePeopleScore();
                }
            }
        }
    }
}
