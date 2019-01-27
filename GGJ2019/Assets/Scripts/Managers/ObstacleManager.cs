using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    // Update is called once per frame
    void Update()
    {
        StartResetTimer();
    }

    // Reset the obstacle state, if able, after the timer ends
    void ResetState(Obstacle obstacle)
    {
        obstacle.isTriggered = false;

        obstacle.startState.SetActive(true);
        obstacle.endState.SetActive(false);

        obstacle.navObstacle.enabled = false;
    }

    // Check any obstacles for triggered state and start their cooldown, prior to reset
    void StartResetTimer()
    {
        foreach (var obstacle in this.obstacles)
        {
            Obstacle thisObstacle = obstacle.GetComponent<Obstacle>();

            if (thisObstacle.isTriggered && thisObstacle.obstacleDeathTime > 0)
            {
                thisObstacle.obstacleTimer += Time.deltaTime;

                if (thisObstacle.obstacleTimer > thisObstacle.obstacleDeathTime)
                {
                    this.ResetState(thisObstacle);
                    thisObstacle.obstacleTimer = 0;
                }
            }
        }
    }
}
