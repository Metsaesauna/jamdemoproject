using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private KillZone killzone;

    private void Awake()
    {
        killzone = GameObject.FindGameObjectWithTag("kikeli").GetComponent<KillZone>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        {
            killzone.GetComponent<KillZone>().IsWin = true;
            Debug.Log("hihihhii kutittaa voitit pelin");
            
            SceneManager.LoadScene("WinTrans");

        }
    }
}
