using System.Collections;
using UnityEngine;

public class CrossbowStrings : MonoBehaviour
{
    [Header("Line InitialPoints")]
    [SerializeField] private LineRenderer firstLineL;
    [SerializeField] private LineRenderer secondLineL;

    [SerializeField] private LineRenderer firstLineR;
    [SerializeField] private LineRenderer secondLineR;

    [Header("Line Endpoints")]
    [SerializeField] private Transform firstEndpointL;
    [SerializeField] private Transform secondEndpointL;

    [SerializeField] private Transform firstEndpointR;
    [SerializeField] private Transform secondEndpointR;

    [Header("Rotor Points")]
    [SerializeField] private Transform rotor;
    [SerializeField] private Transform rotorInitialPoint;
    [SerializeField] private Transform rotorFinalPoint;

    public void UpdateLinesVisual()
    {
        SetLine(firstLineL, firstLineL.gameObject.transform, firstEndpointL);
        SetLine(secondLineL, secondLineL.gameObject.transform, secondEndpointL);

        SetLine(firstLineR, firstLineR.gameObject.transform, firstEndpointR);
        SetLine(secondLineR, secondLineR.gameObject.transform, secondEndpointR);
    }

    private void SetLine(LineRenderer lineRenderer, Transform startPoint, Transform endPoint)
    {
        lineRenderer.SetPosition(0, startPoint.position);
        lineRenderer.SetPosition(1, endPoint.position);
    }

    public void MoveRotor(float duration)
    {
        StartCoroutine(UpdateRotosPosition(duration));
    }

    private IEnumerator UpdateRotosPosition(float duration)
    {
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float value = (Time.time - startTime) / duration;
            rotor.position = Vector3.Lerp(rotorInitialPoint.position, rotorFinalPoint.position, value);
            yield return null;
        }

        rotor.position = rotorFinalPoint.position;
    }

}
