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

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > wanderTimer)
        {
            Vector3 newPos = PeopleManager.GetRandomPersonPosition();
            if (Main.IS_DEBUG)
            {
                GameObject[] roads = new List<GameObject>(GameObject.FindGameObjectsWithTag("Road")).FindAll(g => g.transform.IsChildOf(LevelManager.GetCurrentMap().transform)).ToArray();
                newPos = roads[10].transform.position;
            }
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
        Gizmos.DrawSphere(this.target, 1.0f);
    }
}
