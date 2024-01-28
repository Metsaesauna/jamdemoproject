using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangedAI : MonoBehaviour
{
    public Transform Player;
    private Vector2 direction;

    public GameObject BulletPrefab;
    public Transform shootPoint;
    public float fireRate = 1f;

    private float nextFireTime;

    void Update()
    {


        if (Time.time >= nextFireTime)
        {
            
            nextFireTime = Time.time + 1f / fireRate;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("pelaaja löyty");
            Player = collision.transform;
            Shoot();

            nextFireTime = Time.time + 1f / fireRate;


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
