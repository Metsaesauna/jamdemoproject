using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Authors: Taneli Niskanen & Jones Manninen
public class EnemyKill : MonoBehaviour
{
    
    //The enemy checks wheter or not they are hit.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //If the hit is with a player, we continue.If not, we return to the start.
        if (other.CompareTag("Player") == false)
        {
            return;
        }
        //We acces PlayerDash to get components we can use to determine if player is dashing.
        PlayerDash playerDash = other.GetComponent<PlayerDash>();
        // If we are dashing, we use return to go back to start.
        if (Time.time < playerDash.DashStartedTime + playerDash.DashLength)
        {
            return;
        }
        //In case the player is not dashing, we kill the player.
        Debug.Log("Vihu Osuu Pelaajaan");
        //SceneManager.LoadScene("GameOver");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {


        //If we hit an enemy while dashing, we reset the dash cooldown. Then we destroy the enemy we hit.
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject); // Destroy self


        }

    }
}
