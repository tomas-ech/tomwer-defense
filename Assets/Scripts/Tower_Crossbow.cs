
using UnityEngine;

public class Tower_Crossbow : Tower
{
    private Tower_Crossbow_Visuals visuals;

    [Header("Crossbow details")]
    [SerializeField] private Transform gunPoint;

    protected override void Awake()
    {
        base.Awake();
        visuals = GetComponent<Tower_Crossbow_Visuals>();
    }

    protected override void Attack()
    {

        Vector3 directionToEnemy = DirectionToEnemy(gunPoint);

        if (Physics.Raycast(gunPoint.position, directionToEnemy, out RaycastHit hitInfo))
        {
            Debug.DrawLine(gunPoint.position, hitInfo.point);
        }

        visuals.EnableAttackVisuals(gunPoint.position, hitInfo.point);
        visuals.PlayVFX(attackCooldown);
    }
}
