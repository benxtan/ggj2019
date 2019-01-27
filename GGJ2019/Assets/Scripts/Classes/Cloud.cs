using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 0.1f;
    private float cloudTime;
    private Vector3 destinationSize;

    void Start()
    {
        cloudTime = Time.time;
        destinationSize = new Vector3(Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f), Random.Range(0.9f, 1.1f));
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // Scale up
        float t = (Time.time - cloudTime) / 4.0f;
        if (t < 1)
        {
            transform.localScale = Vector3.Slerp(transform.localScale, destinationSize, t);
        }

        // Float
        if (transform.localPosition.z > 2.0f)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Random.Range(-20, 0));
            transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            cloudTime = Time.time;
        }
    }
}
