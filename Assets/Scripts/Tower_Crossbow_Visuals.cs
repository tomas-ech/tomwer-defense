using System.Collections;
using UnityEngine;

public class Tower_Crossbow_Visuals : MonoBehaviour
{
    private Tower_Crossbow crossbowTower;

    [SerializeField] private LineRenderer attackVisual;
    [SerializeField] private float visualsDuration = .12f;

    private void Awake()
    {
        crossbowTower = GetComponent<Tower_Crossbow>();
    }

    public void EnableAttackVisuals(Vector3 startPoint, Vector3 endPoint)
    {
        StartCoroutine(FxCoroutine(startPoint, endPoint));
    }

    private IEnumerator FxCoroutine(Vector3 startPoint, Vector3 endPoint)
    {
        crossbowTower.EnableRotation(false);

        attackVisual.enabled = true;
        attackVisual.SetPosition(0, startPoint);
        attackVisual.SetPosition(1, endPoint);

        yield return new WaitForSeconds(visualsDuration);

        attackVisual.enabled = false;

        crossbowTower.EnableRotation(true);
    }
}
