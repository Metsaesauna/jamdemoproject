using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class Kill : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject); // Destroy the enemy GameObject
            }
        }
    }
