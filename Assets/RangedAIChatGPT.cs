using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAIChatGPT : MonoBehaviour
{
    public Transform Player;
    private Vector2 direction;

    public GameObject BulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1f;

    private float nextFireTime;

    private void Start()
    {
        // Initialize nextFireTime to allow the enemy to shoot immediately.
        nextFireTime = Time.time;
    }

    void Update()
    {
        // Check if it's time to fire and if the player reference is not null (player is in range).
        if (Time.time >= nextFireTime && Player != null)
        {
            // Call the Shoot method when it's time to fire
            Shoot();

            // Reset the nextFireTime
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player found");
            Player = collision.transform;
            // Reset nextFireTime to allow the enemy to shoot immediately when the player enters the trigger zone.
            nextFireTime = Time.time;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player exited");
            Player = null; // Set Player reference to null when the player exits the trigger zone.
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the shoot point
        GameObject newProjectile = Instantiate(BulletPrefab, shootPoint.position, shootPoint.rotation);

        // Calculate the direction from the enemy to the player
        Vector2 direction = (Player.position - shootPoint.position).normalized;

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        Bullet projectileScript = newProjectile.GetComponent<Bullet>();
        projectileScript.MoveDirection = direction;
    }
}
