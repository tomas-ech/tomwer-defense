using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    [SerializeField] private List<Waypoint> waypointsList;
    [SerializeField] private float spawnCooldown;
    private float spawnTimer = 1;

    public List<GameObject> enemiesToCreate;

    private void Awake()
    {
        CollectWaypoints();
    }

    private void Update()
    {
        if (CanSummonEnemy())
        {
            CreateEnemy();
        }
    }

    private bool CanSummonEnemy()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0 && enemiesToCreate.Count > 0)
        {
            spawnTimer = spawnCooldown;
            return true;
        }

        return false;
    }

    private void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(GetRandomEnemy(), transform.position, Quaternion.identity);

        newEnemy.GetComponent<Enemy>().SetUpEnemy(waypointsList);
    }

    private GameObject GetRandomEnemy()
    {
        int randomNumber = Random.Range(0, enemiesToCreate.Count);
        GameObject newEnemy = enemiesToCreate[randomNumber];

        enemiesToCreate.Remove(newEnemy);

        return newEnemy;
    }

    public List<GameObject> GetEnemyList() => enemiesToCreate;

    [ContextMenu("Collect Waypoints")]
    private void CollectWaypoints()
    {
        waypointsList = new List<Waypoint>();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Waypoint waypoint))
            {
                waypointsList.Add(waypoint);
            }
        }
    }
}
