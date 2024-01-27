using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    
    private Rigidbody2D rb2d;
    private Camera cam;
    private Vector3 mousePos;
    public float DashDistance = 20f;
    public float DashForce = 10000;
    public bool isDashing;
    private Vector3 rotation;
    private Vector3 dashEndPos;
    private void Awake()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb2d = GetComponent<Rigidbody2D>();

    }
    public void Dash()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rotation = (mousePos - transform.position).normalized;
        rb2d.velocity = new Vector2(0, 0);
        isDashing = true;
        dashEndPos = rb2d.gameObject.transform.position + rotation * DashDistance;
    }
    private void Update()
    {
        if (isDashing)
        {
            rb2d.velocity = new Vector2(0, 0);
            rb2d.gameObject.transform.position += rotation * DashForce * Time.deltaTime;
            isDashing = false;
        }
        //if((gameObject.transform.position - dashEndPos).magnitude < 0.1) 
        //{
            
        //}
    }
}
