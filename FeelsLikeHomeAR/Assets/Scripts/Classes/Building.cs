using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    // Off - Front
    // Off - Left
    // Off - Top
    // On  - Front
    // On  - Left
    // On  - Top
    public Material[] materials;

    public bool isPersonHome = false;

    private Feeling _feeling;
    public Feeling feeling
    {
        get
        {
            return _feeling;
        }
        set
        {
            _feeling = value;

            if (value == null)
            {
                transform.Find("Bubble").gameObject.SetActive(false);
                return;
            }

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

            // Turn on bubble
            transform.Find("Bubble").gameObject.SetActive(true);
        }
    }

    public Sprite[] icons;

    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
    }

    public bool IsEmpty()
    {
        return feeling == null;
    }

    public void SetPersonHome()
    {
        isPersonHome = true;

        transform.Find("Bubble").gameObject.SetActive(false);

        transform.Find("Left").GetComponent<Renderer>().material = materials[3];
        transform.Find("Top").GetComponent<Renderer>().material = materials[5];
        transform.Find("Front").GetComponent<Renderer>().material = materials[4];
    }

    public void Reset()
    {
        isPersonHome = false;
        this.feeling = null;
    }
}
