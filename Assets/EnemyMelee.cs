using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EnemyMelee : MonoBehaviour
{

    // fuckin useless, mut en uskalla poistaa t. jones
    protected void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Debug.Log("onnistuuko?");
            Destroy(gameObject);
        }



    }
}