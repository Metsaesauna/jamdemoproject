using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    public bool IsWin = false;
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !IsWin)
        {
            Debug.Log("Player collided and not a winner");
            SceneManager.LoadScene("GameOver");
            Destroy(other.gameObject); // This destroys the player object when the conditions are met.
        }


    }
}