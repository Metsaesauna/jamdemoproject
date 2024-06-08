using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seppo_Flip : MonoBehaviour
{
    public float flipInterval = 5000f;

    private float nextFlipTime;
    private SpriteRenderer SpriteRenderer;

    private void Start()
    {
        nextFlipTime = Time.time;

        SpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (Time.time >= nextFlipTime) 
        { 
            SpriteRenderer.flipX = !SpriteRenderer.flipX;

            nextFlipTime += Time.time + flipInterval;
        }
    }

}
