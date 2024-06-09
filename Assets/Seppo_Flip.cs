using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seppo_Flip : MonoBehaviour
{
    private float flipInterval = 0.5f; // Interval in seconds

    private float nextFlipTime;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        nextFlipTime = Time.time + flipInterval;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Time.time >= nextFlipTime)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            nextFlipTime += flipInterval; // Corrected line to add the interval to the next flip time
        }
    }
}