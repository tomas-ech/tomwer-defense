using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IDamageable
{
    private NavMeshAgent agent;
    private int waypointIndex;

    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float turnSpeed = 10f;

    public int healthPoints = 4;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.avoidancePriority = Mathf.RoundToInt(agent.speed * 10);
    }

    private void Start()
    {
        waypoints = FindFirstObjectByType<WaypointManager>().GetWaypoints;
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

        if (newDirection != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(newDirection);

            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, turnSpeed * Time.deltaTime);
        }

    }

    private Vector3 GetNextWaypoint()
    {
        if (waypointIndex >= waypoints.Length)
        {
            return transform.position;
        }

        Vector3 targetWaypoint = waypoints[waypointIndex].position;
        waypointIndex++;

        return targetWaypoint;
    }

    public void TakeDamage(int damage)
    {
        healthPoints -= damage;

        if (healthPoints <= 0) Destroy(gameObject);
    }
}
