using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private int waypointIndex;

    [SerializeField] private Transform[] wayPointArray;


    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (agent.remainingDistance < .5f)
        {
            agent.SetDestination(GetNextWaypoint());
        }
    }

    private Vector3 GetNextWaypoint()
    {
        if (waypointIndex >= wayPointArray.Length)
        {
            return transform.position;
        }

        Vector3 targetWaypoint = wayPointArray[waypointIndex].position;
        waypointIndex++;

        return targetWaypoint;
    }
}
