using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeCollider : MonoBehaviour
{
    
    
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Blade"))
            {
                // Blade collision detected, perform actions
                Debug.Log("Blade collision detected");
            }
        }

  
 
}

