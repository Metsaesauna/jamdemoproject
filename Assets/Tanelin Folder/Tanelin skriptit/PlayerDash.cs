using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Author: Taneli Niskanen
public class PlayerDash : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    private Camera cam;
    private Vector3 mousePos;
    public float DashDistance = 20f;
    public float DashForce = 100;
    private Vector2 rotation;
    private CharacterController2D moveScript;
    public float DashLength = 0.1f;
    public float DashStartedTime;
    public GameObject originalBlade;
    private GameObject blade;
    
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
        rotation = ((Vector2)mousePos - (Vector2)transform.position).normalized;
        //instantiate Blade to kill enemies
        //blade = Instantiate(originalBlade, transform.position, Quaternion.identity);

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
            //we destroy the blade prefab so we can be killed again
            Destroy(blade);
            //when over, we enable charcontroller again
            moveScript.enabled = true;
        }

    }
    //Tarkistetaan, osuttiinko mihinkään.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Jos ei olla dashaamassa, ei tehdä mitään, palataan alkuun.
        if (Time.time > DashStartedTime + DashLength)
        {

            return;

        }
        //jos osuttiin viholliseen, resetoidaan dashCooldown ja tuhotaan vihollinen johon osuttiin
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<CharacterController2D>().dashCooldown = false;
            Destroy(collision.gameObject); // Destroy the enemy GameObject
        }
    }
}
