﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Feeling feeling
    {
        set
        {
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
}
