using UnityEngine;

// Author: Taneli Niskanen
[RequireComponent(typeof(BoxCollider2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField, Tooltip("Max speed, in units per second, that the character moves.")]
    float speed = 9;

    [SerializeField, Tooltip("Acceleration while grounded.")]
    float walkAcceleration = 45;

    [SerializeField, Tooltip("Acceleration while in the air.")]
    float airAcceleration = 30;

    [SerializeField, Tooltip("Deceleration applied when character is grounded and not attempting to move.")]
    float groundDeceleration = 25;

    [SerializeField, Tooltip("Max height the character will jump regardless of gravity")]
    float jumpHeight = 4;

    public float groundCheckDistance = .55f;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2d;

    private Vector2 velocity;

    public float moveInput;
    public bool grounded;
    
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        // We apply gravity to pull us down afterwards
        velocity.y += Physics2D.gravity.y * Time.deltaTime;
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
        // We check the value of moveInput, and separate acceleration/deceleration for when we are in the air and when we are grounded.

        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
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
        }
        else 
        {
            //We set the grounded bool to false if no ground
            grounded = false;
        }
    }

    //private void Update()
    //{   

    //    // We apply gravity to pull us down afterwards
    //    velocity.y += Physics2D.gravity.y * Time.deltaTime;
    //    //We allow jumping only if grounded.
    //    if (grounded)
    //    {
    //        velocity.y = 0;
    //        // We see if the "W" key is pressed
    //        if (Input.GetKeyDown(KeyCode.W))
    //        {
    //            // We apply vertical velocity (up)
    //            velocity.y = Mathf.Sqrt(2 * jumpHeight * Mathf.Abs(Physics2D.gravity.y));

    //        }

    //    }
    //        // We add value to moveInput when either horizontal key is pressed.
    //         moveInput = Input.GetAxisRaw("Horizontal");

    //    // We create two floats that help us define acceleration depending if we are on the ground or not.
    //    float acceleration = grounded ? walkAcceleration : airAcceleration;
    //    float deceleration = grounded ? groundDeceleration : 0;
    //    // We check the value of moveInput, and separate acceleration/deceleration for when we are in the air and when we are grounded.
    //    if (moveInput != 0)
    //    {
    //        velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, acceleration * Time.deltaTime);
    //    }
    //    else
    //    {
    //        velocity.x = Mathf.MoveTowards(velocity.x, 0, deceleration * Time.deltaTime);
    //    }

    //    // We translate velocity by framerate, keeps it frame rate dependant
    //    transform.Translate(velocity * Time.deltaTime);

    //    // We use overlap to detect what colliders we are currently touching
    //    Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size , 0);

    //    //We set the grounded bool to false each frame
    //    grounded = false;

    //    // We check each collider we are currently touching
    //    foreach (Collider2D hit in hits)
    //    {
    //        if (hit == boxCollider)
    //            continue;
    //        ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
    //        // If we are touching a collider, we move the shortest distance possible away
    //        if (colliderDistance.isOverlapped)
    //        {
    //            transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
    //            //We check to see if we are on a 90-degree platform, and that we are "moving" down. If these checks are true, we set grounded to true
    //            if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
    //            {
    //                grounded = true;
    //            }
    //        }
    //    }

    //}
}
