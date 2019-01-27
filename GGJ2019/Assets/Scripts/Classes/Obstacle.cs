using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Obstacle : MonoBehaviour
{
    public bool isTriggered = false;
    public bool rotateObject = false;
    public float obstacleDeathTime;
    public float obstacleTimer;
    public string obstacleName;
    public GameObject[] startState;
    public GameObject[] endState;
    public NavMeshObstacle navObstacle;

    // Start is called before the first frame update
    void Start()
    {        
        this.navObstacle = this.gameObject.GetComponent<NavMeshObstacle>();
        this.CheckRotation();  
    }

    // Update is called once per frame
    void Update()
    { 
    }

    void CheckRotation() {
        if (this.rotateObject == true) {
            this.transform.Rotate(0, -89, 0, Space.World);
                
            foreach (var obs in this.startState)
            {
                obs.transform.Rotate(0, obs.transform.rotation.y + 90f, 0, Space.World);
                obs.transform.GetChild(0).transform.Rotate(0, 360f, 0f, Space.World);
            }        

            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = new Vector2(40, 2);
            collider.offset = new Vector2(0, 1);
        }
    }

    void OnMouseDown(){
        this.isTriggered = true;

        foreach (var obs in this.startState)
        {
            obs.SetActive(false);
        }

        foreach (var obs in this.endState)
        {
            obs.SetActive(true);
        }

        this.navObstacle.enabled = true;
    }
}
