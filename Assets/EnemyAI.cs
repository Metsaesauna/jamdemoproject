using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float EnemySpeed = 10f; // Enemy movement speed
    public Transform Player; // Player's transform
    private Rigidbody2D parentRigidbody;

    private void Start()
    {
        // Get the parent object's Rigidbody2D component
        parentRigidbody = transform.parent.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Player != null)
        {
            // Calculate the direction to move towards the player
            Vector2 direction = ((Vector2)Player.position - parentRigidbody.position).normalized;

            direction.y = 0;

            // Move the parent (melee enemy) using the parent's Rigidbody2D
            parentRigidbody.velocity = direction * EnemySpeed;
        }
        else
        {
            // No player found, stop moving
            parentRigidbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player detected, set the target to the player's transform
            Player = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Player left the enemy's detection range, stop chasing
            Player = null;
        }
    }
    



    }
