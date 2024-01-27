using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Author: Taneli Niskanen
public class DashPointer : MonoBehaviour
{
    private Camera cam;
    private Vector3 mousePos;
    void Start()
    {
        //we find the camera we want to use
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Update()
    {
        //we translate current mouseposition into a vector, and set the pointer to follow it from a rotatinpoint. 3D vector is fine since the pointer does not interact with anything
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
