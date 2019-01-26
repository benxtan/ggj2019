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
        agent.autoBraking = true;
        agent.autoRepath = true;
        NavMesh.avoidancePredictionTime = 0.5f;

        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > wanderTimer)
        {
            Vector3 newPos = RandomNavMeshLocation(wanderRadius, agent);
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

    public Vector3 RandomNavMeshLocation(float radius, NavMeshAgent agent)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;

        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        Vector3 bufferPosition = Vector3.zero;

        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
            bufferPosition = new Vector3(finalPosition.x * (agent.radius / 2), finalPosition.y * (agent.radius / 2), finalPosition.z * (agent.radius / 2));

            Debug.Log(finalPosition);
            Debug.Log(bufferPosition);
        }

        return finalPosition;
    }
}
