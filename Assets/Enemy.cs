using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private int waypointIndex;

    [SerializeField] private Transform[] wayPointArray;
    [SerializeField] private float turnSpeed = 10f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.avoidancePriority = Mathf.RoundToInt(agent.speed * 10);
    }

    private void Update()
    {
        FaceTarget(agent.steeringTarget);

        if (agent.remainingDistance < .5f)
        {
            agent.SetDestination(GetNextWaypoint());
        }
    }

    private void FaceTarget(Vector3 newTarget)
    {
        Vector3 newDirection = newTarget - transform.position;
        newDirection.y = 0;

        Quaternion newRotation = Quaternion.LookRotation(newDirection);

        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
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
