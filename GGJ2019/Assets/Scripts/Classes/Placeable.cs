using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public float placeableDeathTime;
    public float placeableTimer;
    public string placeableName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        this.placeableTimer += Time.deltaTime;

        if (this.placeableTimer > this.placeableDeathTime)
        {
            Destroy(this.gameObject);
            this.placeableTimer = 0;
        }
    }
}
