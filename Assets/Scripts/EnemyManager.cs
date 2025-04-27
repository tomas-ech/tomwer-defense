using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveDetails
{
    public int basicEnemy;
    public int fastEnemy;
}

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private WaveDetails waveDetails;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnCooldown;
    private float spawnTimer = 1;
    private List<GameObject> enemiesToCreate;

    [Header("Enemies")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject fastEnemy;

    private void Start()
    {
        enemiesToCreate = NewEnemyWave();
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0 && enemiesToCreate.Count > 0)
        {
            CreateEnemy();
            spawnTimer = spawnCooldown;
        }
    }

    private void CreateEnemy()
    {
        GameObject newEnemy = Instantiate(GetRandomEnemy(), spawnPoint.position, Quaternion.identity);
    }

    private GameObject GetRandomEnemy()
    {
        int randomNumber = Random.Range(0, enemiesToCreate.Count);
        GameObject newEnemy = enemiesToCreate[randomNumber];

        enemiesToCreate.Remove(newEnemy);

        return newEnemy;
    }

    private List<GameObject> NewEnemyWave()
    {
        List<GameObject> newEnemyList = new List<GameObject>();

        for (int i = 0; i < waveDetails.basicEnemy; i++)
        {
            newEnemyList.Add(basicEnemy);
        }

        for (int i = 0; i < waveDetails.fastEnemy; i++)
        {
            newEnemyList.Add(fastEnemy);
        }

        return newEnemyList;
    }
}
