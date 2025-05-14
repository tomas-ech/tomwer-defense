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
    public List<EnemyPortal> enemyPortals;
    [SerializeField] private WaveDetails waveDetails;

    [Header("Enemies")]
    [SerializeField] private GameObject basicEnemy;
    [SerializeField] private GameObject fastEnemy;

    private void Awake()
    {
        enemyPortals = new List<EnemyPortal>(FindObjectsOfType<EnemyPortal>());
    }

    [ContextMenu("Seupt Next Wave")]
    private void SetUpNextWave()
    {
        List<GameObject> newEnemies = NewEnemyWave();
        int index = 0;

        for (int i = 0; i < newEnemies.Count; i++)
        {
            GameObject enemyToAdd = newEnemies[i];
            EnemyPortal portalToSummonEnemy = enemyPortals[index];

            portalToSummonEnemy.GetEnemyList().Add(enemyToAdd);

            index++;

            if (index >= enemyPortals.Count)
            {
                index = 0;
            }
        }
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
