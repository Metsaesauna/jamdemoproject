using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class EnemyMelee : MonoBehaviour
{


    protected void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.CompareTag("Blade"))
        {
            Debug.Log("onnistuuko?");
            Destroy(gameObject);
        }



    }
}