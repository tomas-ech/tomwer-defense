
using UnityEngine;

public class Tower : MonoBehaviour
{
    public Transform currentEnemy;

    [Header("Tower Setup")]
    [SerializeField] private Transform towerHead;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        RotateTowardsEnemy();
    }

    private void RotateTowardsEnemy()
    {
        Vector3 direction = currentEnemy.position - towerHead.position;

        Quaternion lookDirection = Quaternion.LookRotation(direction);

        Vector3 rotation = Quaternion.Lerp(towerHead.rotation, lookDirection, rotationSpeed * Time.deltaTime).eulerAngles;

        towerHead.rotation = Quaternion.Euler(rotation); 
    }
}
