using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Author: Taneli Niskanen
public class RotateScript : MonoBehaviour
{
    public Transform rotationPoint;
    public float rotationSpeed = 10f;


    // Update is called once per frame
    void Update()
    {
        RotateTriangle(transform.GetChild(0), rotationSpeed);
        RotateTriangle(transform.GetChild(1), rotationSpeed);
        RotateTriangle(transform.GetChild(2), rotationSpeed);
    }
    private void RotateTriangle(Transform triangle, float speed)
    {
        Vector3 rotationAxis = rotationPoint.position;
        triangle.RotateAround(rotationAxis, Vector3.forward, speed * Time.deltaTime);
    }
}
