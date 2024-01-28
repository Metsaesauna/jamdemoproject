using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") == true)
        {
            Debug.Log("fucking dead");
            SceneManager.LoadScene("GameOver");

        }

        Destroy(other.gameObject);

    }   

}
