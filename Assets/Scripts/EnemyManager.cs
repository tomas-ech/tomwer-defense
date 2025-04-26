using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private float spawnCooldown;
    private float spawnTimer;

    [SerializeField] private Transform spawnPoint;
    [Header("Enemies")]
    [SerializeField] private GameObject basicEnemy;

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            CreateEnemy();
            spawnTimer = spawnCooldown;
        }
    }

    private void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(basicEnemy, spawnPoint.position, Quaternion.identity);
    }
}
