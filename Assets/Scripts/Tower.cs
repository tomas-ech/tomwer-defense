
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentEnemy;

    [Header("Tower Setup")]
    [SerializeField] private Transform towerHead;
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask enemyMask;

    private void Update()
    {
        if (currentEnemy == null)
        {
            currentEnemy = FindRandomEnemyInRange();
            return;
        }

        if (Vector3.Distance(currentEnemy.position, transform.position) > attackRange)
        {
            currentEnemy = null;
        }

        RotateTowardsEnemy();
    }

    private void RotateTowardsEnemy()
    {
        if (currentEnemy == null) return;

        Vector3 direction = currentEnemy.position - towerHead.position;

        Quaternion lookDirection = Quaternion.LookRotation(direction);

        Vector3 rotation = Quaternion.Lerp(towerHead.rotation, lookDirection, rotationSpeed * Time.deltaTime).eulerAngles;

        towerHead.rotation = Quaternion.Euler(rotation); 
    }

    private Transform FindRandomEnemyInRange()
    {
        List<Transform> possibleTargets = new List<Transform>();
        Collider[] enemiesAround = Physics.OverlapSphere(transform.position, attackRange, enemyMask);

        foreach (var enemy in enemiesAround)
        {
            possibleTargets.Add(enemy.transform);
        }

        int randomNumber = Random.Range(0, possibleTargets.Count);

        if (possibleTargets.Count <= 0)
        {
            return null;
        }

        return possibleTargets[randomNumber];
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
