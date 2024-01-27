using UnityEditor.UIElements;
using UnityEngine;

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
      if (Input.GetMouseButtonDown(0))
        {
            velocity = Vector2.zero;
            GetComponent<PlayerDash>().Dash();
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
        }
        else 
        {
            //We set the grounded bool to false if no ground
            grounded = false;
        }
    }

 
}
