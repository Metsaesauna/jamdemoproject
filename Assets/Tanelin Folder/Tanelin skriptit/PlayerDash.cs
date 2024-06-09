using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Author: Taneli Niskanen
public class PlayerDash : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    private Camera cam;
    private Vector3 mousePos;
    //private float DashDistance = 50f;
    private float DashForce = 80;
    public Vector2 rotation;
    private CharacterController2D moveScript;
    public float DashLength = 0.18f;
    public float DashStartedTime;
    public AudioClip meleeDie;
    public AudioClip rangedDie;
    public AudioClip seppoDie;
    public AudioSource playerSource;
    private GameObject dashPointerAva;
    private GameObject dashPointerNava;
    
    private void Awake()
    {
        //We find all of the components we need for the dash to function
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2d = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<CharacterController2D>();
        playerSource = GetComponent<AudioSource>();
        dashPointerNava = GetComponent<CharacterController2D>().DashPointerNava;
        dashPointerAva = GetComponent<CharacterController2D>().DashPointerAva;
    }
    public void Dash()
    {
       
        //check when dash started (was called) and save that time into a float
        DashStartedTime = Time.time;
        //disable charcontroller so no other forces apply (outdated)
       // moveScript.enabled = false;
        //find mouse position and translate into 2D direction
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rotation = ((Vector2)mousePos - (Vector2)transform.position).normalized;
        playerSource.Play(0);
        GetComponent<SpotlightController>().lightDampen += 3;


    }
    private void FixedUpdate()
    {
        //we do this if current time is less than when dash was called + the duration of the dash
        if (Time.time < DashStartedTime + DashLength)
        {
            

            //we add velocity based on dashforce
            rb2d.velocity = new Vector2(1,1) * rotation * DashForce;
            

        }
        else
        {

            //when over, we enable charcontroller again (outdated)
            //  moveScript.enabled = true;

        }

    }
    //We check if we hit anything
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //If we are not dashing, we do nothing. Return to start (enemies kill on collide when not dashing)
        if (Time.time > DashStartedTime + DashLength)
        {

            return;

        }
        //If we hit an enemy while dashing, we reset the dash cooldown. Then we destroy the enemy we hit.
        if (collision.gameObject.CompareTag("EnemyMelee"))
        {
            GetComponent<CharacterController2D>().dashCooldown = false;
            dashPointerAva.SetActive(true);
            dashPointerNava.SetActive(false);
            Destroy(collision.gameObject); // Destroy the enemy GameObject
            playerSource.PlayOneShot(meleeDie, 1f);
        }
        if (collision.gameObject.CompareTag("EnemyRanged"))
        {
            GetComponent<CharacterController2D>().dashCooldown = false;
            dashPointerAva.SetActive(true);
            dashPointerNava.SetActive(false);
            Destroy(collision.gameObject); // Destroy the enemy GameObject
            playerSource.PlayOneShot(rangedDie, 0.6f);
        }
        if (collision.gameObject.CompareTag("EnemySeppo"))
        {
            GetComponent<CharacterController2D>().dashCooldown = false;
            dashPointerAva.SetActive(true);
            dashPointerNava.SetActive(false);
            Destroy(collision.gameObject); // Destroy the enemy GameObject
            playerSource.PlayOneShot(seppoDie, 1f);
        }
    }
}
