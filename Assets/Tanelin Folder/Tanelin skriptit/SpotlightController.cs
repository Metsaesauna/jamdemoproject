using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//Author: Taneli Niskanen
public class SpotlightController : MonoBehaviour
{
    //define the floats and make them public for easy tweaking in editor
    public float xVelocityMultiplier = 1.5f;
    public float falloffMultiplier = 1.0f;
    public float lightDampen = 5;
 

    //name these so we can get them from the gameobjects. Note that "Light2D" is different than "Light"
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

        if (lightDampen > 1)
        {
            lightDampen -= 1 * Time.deltaTime;
        }
        //calculate the new intensity using the velocity of the player. Keep it in a range of 1-100
        float xVelocity = playerRB2D.velocity.x;
        // float adjustedFalloff = Mathf.Clamp(Mathf.Abs(xVelocity) * xVelocityMultiplier * falloffMultiplier, 1f, 100f); adjustedFalloff + lightDampen;


        //adjust the specific slider on the spotlight
        spotlight.shapeLightFalloffSize = Mathf.Abs(xVelocity) + lightDampen;
        
    }

 
}
