
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    private Transform currentEnemy;

    protected float lastTimeAttacked;

    [Header("Tower Setup")]
    [SerializeField] protected Transform towerHead;
    [SerializeField] protected float attackCooldown = 2;
    [SerializeField] protected float rotationSpeed = 10;

    [SerializeField] protected float attackRange = 2.5f;
    [SerializeField] protected LayerMask enemyMask;

    private bool canRotate = true;

    protected virtual void Awake()
    {

    }

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
        var angle = Quaternion.Angle(towerHead.rotation, Quaternion.LookRotation(currentEnemy.position - towerHead.position));
        
        if (Time.time > lastTimeAttacked + attackCooldown && angle < 5)
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

    public void EnableRotation(bool isRotating)
    {
        canRotate = isRotating;
    }

    protected virtual void RotateTowardsEnemy()
    {
        if (currentEnemy == null || canRotate == false) return;

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
