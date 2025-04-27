using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWheel : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;
    [SerializeField] private float rotationSpeed;

    private void Update()
    {
        float newSpeed = rotationSpeed * 100;
        transform.Rotate(rotationVector * newSpeed * Time.deltaTime);
    }
}
