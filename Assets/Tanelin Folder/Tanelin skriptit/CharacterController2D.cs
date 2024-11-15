﻿using UnityEngine;

// Author: Taneli Niskanen

// we require a boxcollider for some functions
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    public float MaxSpeed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    public float walkAcceleration = 45;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    public float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    public float groundDeceleration = 25;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    public float jumpHeight = 4;

    public float groundCheckDistance = .55f;

    private BoxCollider2D boxCollider;
    public Rigidbody2D rb2d;

    public Vector2 velocity;
    
    public float moveInput;
    public bool grounded;
    public bool dashCooldown = false;
    public float cooldownTimer = 0.5f;
    private float Timer;
    public GameObject DashPointerAva;
    public GameObject DashPointerNava;
    private bool hasResetOnLand = false;

    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
       
        
    }
    
    private void Update()
    {
        

        // We apply gravity to pull us down afterwards, but only if we are not on the ground
        if (!grounded)
        {
            velocity.y += Physics2D.gravity.y * Time.deltaTime;
        }
        //we call the Dash function from PlayerDash if we press the left mouse button and dashCooldown is false
      if (Input.GetMouseButtonDown(0) && !dashCooldown)
        {
            //we reset velocity before dashing to let PlayerDash handle all of the physics for the duration of the dash
           // velocity = Vector2.zero;
            //we set dashCooldown to true and the Timer to the value of cooldownTimer, then call for Dash
            dashCooldown = true;
            DashPointerAva.SetActive(false);
            DashPointerNava.SetActive(true);
            Timer = cooldownTimer;

            GetComponent<PlayerDash>().Dash();
            
        }
      //we check if dashCooldown is true
      if (dashCooldown == true)
        {
            //start subtracting actual time from timer
            Timer -= Time.deltaTime;
            //if timer reaches or bypasses 0, we set dashCooldown to false
            if (Timer <= 0f)
            {
                dashCooldown = false;
                DashPointerAva.SetActive(true);
                DashPointerNava.SetActive(false);
                Debug.Log("Cooldown elapsed");
            }
        }
        //We allow jumping only if grounded.
        if (grounded)
        {
            
            // We see if the "W" key is pressed
            if (Input.GetKeyDown(KeyCode.W))
            {
                // We apply vertical velocity (up)
                velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));


            }

        }
        // We add value to moveInput when either horizontal key is pressed.
        moveInput = Input.GetAxisRaw("Horizontal");

        // We create two floats that help us define acceleration depending if we are on the ground or not.
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundDeceleration : 0;


        // We check the value of moveInput, and separate acceleration/deceleration for when we are pressing movement keys and when we are not.
        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, MaxSpeed * moveInput, acceleration * Time.deltaTime);
   
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
        }

        // We add calculated velocity to the rigidbody's velocity
        rb2d.velocity = velocity;
        // we use a ray to see if anything is beneath us. if yes (other than null), we are on the ground. If not, we are in the air.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, LayerMask.GetMask("Ground"));
        if (hit.collider != null)
        {
            //we see ground! grounded is true
            grounded = true;
            // we check if we have reset the y velocity during this landing. if we have not, we reset it.
            if (hasResetOnLand == false)
            {
                velocity.y = 0;
                hasResetOnLand = true;
                return;
            }
        }
        else 
        {
            //We set the grounded bool to false if no ground
            grounded = false;
            hasResetOnLand = false;
        }
    }

 
}
