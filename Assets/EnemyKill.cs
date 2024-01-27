using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{
    
    //Vihollinen katsoo osuuko siihen.
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Jos osuma tulee pelaajasta, jatketaan ensimmäisen returnin yli. Jos ei, palataan alkuun.
        if (other.CompareTag("Player") == false)
        {
            return;
        }
        //Haetaan PlayerDash -skriptistä komponentit, joilla voidaan katsoa onko pelaaja keskellä dashia.
        PlayerDash playerDash = other.GetComponent<PlayerDash>();
        // Jos ollaan dashaamassa niin ei jatketa pidemmälle returnista
        if (Time.time < playerDash.DashStartedTime + playerDash.DashLength)
        {
            return;
        }
        //Jos pelaaja ei dashaa, tapetaan pelaaja.
        Debug.Log("Vihu Osuu Pelaajaan");
        SceneManager.LoadScene(0);
    }
    
}
