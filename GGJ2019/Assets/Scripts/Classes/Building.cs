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

            // Turn on bubble
            transform.Find("Bubble").gameObject.SetActive(true);
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

    public void SetOn(bool isOn)
    {
        transform.Find("Bubble").gameObject.SetActive(false);

        transform.Find("Left").GetComponent<Renderer>().material = materials[3];
        transform.Find("Top").GetComponent<Renderer>().material = materials[5];
        transform.Find("Front").GetComponent<Renderer>().material = materials[4];
    }
}
