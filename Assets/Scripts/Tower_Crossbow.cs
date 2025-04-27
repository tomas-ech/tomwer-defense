using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Crossbow : Tower
{

    [Header("Crossbow details")]
    [SerializeField] private Transform gunPoint;

    protected override void Update()
    {
        base.Update();

        Vector3 directionToEnemy = DirectionToEnemy(gunPoint);

        if (Physics.Raycast(gunPoint.position, directionToEnemy, out RaycastHit hitInfo))
        {
            Debug.DrawLine(gunPoint.position, hitInfo.point);
        }
    }
}
