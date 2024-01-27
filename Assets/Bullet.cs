using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.05f;
    public Vector2 MoveDirection = Vector2.zero;
    private void Update()
    {


        transform.position += new Vector3(MoveDirection.x, MoveDirection.y) * speed;

        GetComponent<Rigidbody2D>().velocity = transform.right * speed;

        if (Time.time >= 1f)
        {
            //Destroy(gameObject);
        }
    }
    

  

}
