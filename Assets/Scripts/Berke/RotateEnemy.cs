using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateEnemy : MonoBehaviour
{
    public float rotationSpeed = 50f;
    public float xRotation, yRotation;

    void Update()
    {
        transform.Rotate(xRotation, yRotation, rotationSpeed * Time.deltaTime);
    }
}
