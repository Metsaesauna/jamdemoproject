using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform Player;
    private Vector2 direction;
    private AudioSource mainAudio;
    public GameObject BulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1f;
    public float meleeRange = 1.5f; // Range within which the enemy can perform a melee attack

    private float nextFireTime;

    private void Start()
    {
        // Initialize nextFireTime to allow the enemy to shoot immediately.
        nextFireTime = Time.time;
        mainAudio = GameObject.FindGameObjectWithTag("MainCamera").GetComponentInChildren<AudioSource>();
    }

    void Update()
    {


        // Check if it's time to fire and if the player reference is not null (player is in range).
        if (Time.time >= nextFireTime && Player != null)
        {
            // Randomly choose between ranged and melee attack
            if (Random.Range(0, 2) == 0)
            {
                // Perform ranged attack
                Shoot();
            }
            else
            {
                // Perform melee attack if the player is within melee range
                if (Vector2.Distance(transform.position, Player.position) <= meleeRange)
                {
                    MeleeAttack();
                }
                else
                {
                    // If the player is out of melee range, fallback to ranged attack
                    Shoot();
                }
            }

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
            GetComponent<AudioSource>().Play(0);
            mainAudio.Pause();
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

        Debug.Log("Shoot Point Position: " + shootPoint.position);
        // Instantiate the projectile at the shoot point
        GameObject newProjectile = Instantiate(BulletPrefab, shootPoint.position, shootPoint.rotation);

        // Calculate the direction from the enemy to the player
        Vector2 direction = (Player.position - shootPoint.position).normalized;

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        Bullet projectileScript = newProjectile.GetComponent<Bullet>();
        projectileScript.MoveDirection = direction;
    }

    void MeleeAttack()
    {
        // Perform melee attack logic here
        Debug.Log("Performing melee attack on the player!");

        // You can add melee attack animations, damage to the player, etc.
        // Example:
        // PlayerHealth playerHealth = Player.GetComponent<PlayerHealth>();
        // playerHealth.TakeDamage(meleeDamage);
    }
}
