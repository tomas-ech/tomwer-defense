using System.Collections;
using UnityEngine;

public class Tower_Crossbow_Visuals : MonoBehaviour
{
    private Tower_Crossbow crossbowTower;

    [SerializeField] private LineRenderer attackVisual;
    [SerializeField] private float visualsDuration = .1f;

    [Header("Glowing Visuals")]
    [SerializeField] private MeshRenderer meshRenderer;
    private Material material;
    private CrossbowStrings crossbowStrings;

    [Space]
    [SerializeField] private float currentIntensity;
    [SerializeField] private float maxIntensity = 150f;

    [Space]
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;

    private void Awake()
    {
        crossbowTower = GetComponent<Tower_Crossbow>();
        crossbowStrings = GetComponent<CrossbowStrings>();

        material = new Material(meshRenderer.material);

        meshRenderer.material = material;

        StartCoroutine(ChangeEmission(1));
    }

    private void Update()
    {
        UpdateEmissionColor();
        crossbowStrings.UpdateLinesVisual();
    }

    private void UpdateEmissionColor()
    {
        Color emissionColor = Color.Lerp(startColor, endColor, currentIntensity / maxIntensity);
        emissionColor *= Mathf.LinearToGammaSpace(currentIntensity);
        material.SetColor("_EmissionColor", emissionColor);
    }

    public void PlayVFX(float duration)
    {
        float timeValue = duration / 2;

        StartCoroutine(ChangeEmission(timeValue));
        crossbowStrings.MoveRotor(timeValue);
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

    private IEnumerator ChangeEmission(float duration)
    {
        float startTime = Time.time;
        float startIntensity = 0;


        while (Time.time - startTime < duration)
        {
            float tValue = (Time.time - startTime) / duration;
            currentIntensity = Mathf.Lerp(startIntensity, maxIntensity, tValue);
            yield return null;
        }
    }
}
