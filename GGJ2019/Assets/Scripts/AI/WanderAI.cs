using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderAI : MonoBehaviour
{
    public float wanderRadius;
    public float wanderTimer;

    private Vector3 target;
    private NavMeshAgent agent;
    private float timer;


    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > wanderTimer)
        {
            Vector3 newPos = RandomNavMeshLocation(wanderRadius);
            agent.SetDestination(newPos);
            target = newPos;
            timer = 0;
        }	   
    }

   void OnDrawGizmosSelected()
    {
        // Display the wander radius when selected
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, this.wanderRadius);

        // Displays the navmesh target when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(this.target, 2.0f);
    }

    public Vector3 RandomNavMeshLocation(float radius)
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("Road");
        return roads[Random.Range(0, roads.Length)].transform.position;
    }
}
