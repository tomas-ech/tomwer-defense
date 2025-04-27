
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentEnemy;

    [SerializeField] protected float attackCooldown = 2;
    protected float lastTimeAttacked;

    [Header("Tower Setup")]
    [SerializeField] protected Transform towerHead;
    [SerializeField] protected float rotationSpeed = 10;

    [SerializeField] protected float attackRange = 2.5f;
    [SerializeField] protected LayerMask enemyMask;

    protected virtual void Update()
    {
        if (currentEnemy == null)
        {
            currentEnemy = FindRandomEnemyInRange();
            return;
        }

        if (CanAttack())
        {
            Attack();
        }

        if (Vector3.Distance(currentEnemy.position, transform.position) > attackRange)
        {
            currentEnemy = null;
        }

        RotateTowardsEnemy();
    }

    protected bool CanAttack()
    {
        if (Time.time > lastTimeAttacked + attackCooldown)
        {
            lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }

    protected virtual void Attack()
    {
        Debug.Log("Attacked at: " + Time.time);
    }

    protected virtual void RotateTowardsEnemy()
    {
        if (currentEnemy == null) return;

        Vector3 direction = currentEnemy.position - towerHead.position;

        Quaternion lookDirection = Quaternion.LookRotation(direction);

        Vector3 rotation = Quaternion.Lerp(towerHead.rotation, lookDirection, rotationSpeed * Time.deltaTime).eulerAngles;

        towerHead.rotation = Quaternion.Euler(rotation); 
    }

    protected Vector3 DirectionToEnemy(Transform startPoint)
    {
        return (currentEnemy.position - startPoint.position).normalized;
    }

    protected Transform FindRandomEnemyInRange()
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

    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
