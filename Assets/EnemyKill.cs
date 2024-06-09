using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Authors: Taneli Niskanen & Jones Manninen
public class EnemyKill : MonoBehaviour

    
{
    public bool isIngodmode;

    private void Update()
    {
        isIngodmode = GameObject.FindGameObjectWithTag("Player").GetComponent<GodModeToggle>().sequenceDetected;
       
    }
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
        //In case the player is in godmode, we do not kill player and instead return
        if (isIngodmode == true)
        {
            Debug.Log("Pelaaja on godmodessa)");
            return;
        }
        //In case the player is not dashing, we kill the player.
        Debug.Log("Vihu Osuu Pelaajaan");
        SceneManager.LoadScene("GameOver");
    }
    
}
