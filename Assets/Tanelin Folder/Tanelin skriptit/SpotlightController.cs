using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class SpotlightController : MonoBehaviour
{
    //define the floats and make them public for easy tweaking in editor
    public float xVelocityMultiplier = 1.0f;
    public float falloffMultiplier = 1.0f;

    //name these so we can get them from the gameobjects
    private Rigidbody2D playerRB2D;
    private Light2D spotlight;

    // Start is called before the first frame update
    void Start()
    {
        // Find the objects that we want to modify/need to modify
        playerRB2D = GetComponent<Rigidbody2D>();
        spotlight = GetComponentInChildren<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the new intensity using the velocity of the player. Keep it in a range of 0-100
        float xVelocity = playerRB2D.velocity.x;
        float adjustedFalloff = Mathf.Clamp(Mathf.Abs(xVelocity) * xVelocityMultiplier * falloffMultiplier, 0f, 100f);

        spotlight.shapeLightFalloffSize = adjustedFalloff;
        
    }

 
}
