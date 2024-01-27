using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    private Camera cam;
    private Vector3 mousePos;
    public float DashDistance = 20f;
    public float DashForce = 5;
    private Vector3 rotation;
    private CharacterController2D moveScript;
    private float DashLength = 0.1f;
    private float DashStartedTime;
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2d = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<CharacterController2D>();

    }
    public void Dash()
    {
       
        //check when dash started (was called) and save that time into a float
        DashStartedTime = Time.time;
        //disable charcontroller so no other forces apply
        moveScript.enabled = false;
        //find mouse position and translate into 2D direction
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rotation = (mousePos - transform.position).normalized;
    
    }
    private void FixedUpdate()
    {
        //we do this if current time is less than when dash was called + the duration of the dash
        if (Time.time < DashStartedTime + DashLength)
        {
            //we add velocity based on dashforce, tie to frames with deltatime
            rb2d.velocity = new Vector2(1,1) * rotation * DashForce;
            
        }
        else
        {
            //when over, we enable charcontroller again
            moveScript.enabled = true;
        }

    }
}
