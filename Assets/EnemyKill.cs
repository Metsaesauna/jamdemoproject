using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{
    
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Vihu Osuu Pelaajaan");
            SceneManager.LoadScene(0);
            }
        }
    
}
