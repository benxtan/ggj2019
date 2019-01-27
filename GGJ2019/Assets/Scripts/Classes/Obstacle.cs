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
    public GameObject startState;
    public GameObject endState;
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
            this.startState.transform.Rotate(0, 90, 0, Space.World);
            //this.startState.transform.GetChild(0).transform.position()


            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.size = new Vector2(40, 2);
            collider.offset = new Vector2(0, 1);
        }
    }

    void OnMouseDown(){
        this.isTriggered = true;

        this.startState.SetActive(false);
        this.endState.SetActive(true);

        this.navObstacle.enabled = true;
    }
}
