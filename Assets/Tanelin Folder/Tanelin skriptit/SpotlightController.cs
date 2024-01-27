using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

//Author: Taneli Niskanen
public class SpotlightController : MonoBehaviour
{
    //define the floats and make them public for easy tweaking in editor
    public float xVelocityMultiplier = 1.0f;
    public float falloffMultiplier = 1.0f;
    public AnimationCurve falloffCurve;

    //name these so we can get them from the gameobjects. Note that "Light2D" is different than "Light"
    private Rigidbody2D playerRB2D;
    private Light2D spotlight;

    // Start is called before the first frame update
    void Start()
    {
        // Find the objects that we want to modify/need to modify
        playerRB2D = GetComponent<Rigidbody2D>();
        spotlight = GetComponentInChildren<Light2D>();

        //if (falloffCurve == null)
        //{
        //    falloffCurve = AnimationCurve.Linear(1f, 2f, 2f, 2f);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //calculate the new intensity using the velocity of the player. Keep it in a range of 1-100
        float xVelocity = playerRB2D.velocity.x;
        float adjustedFalloff = Mathf.Clamp(Mathf.Abs(xVelocity) * xVelocityMultiplier * falloffMultiplier, 1f, 100f);

        ////We evaluate the falloff curve at a normalized time based on current velocity
        //float normalizedTime = Mathf.InverseLerp(0f, 100f, Mathf.Abs(xVelocity));
        //float curveValue = falloffCurve.Evaluate(normalizedTime); 

        ////We apply the curve to the adjusted falloff
        //adjustedFalloff *= curveValue;
        //Debug.Log(curveValue);
        //adjust the specific slider on the spotlight
        spotlight.shapeLightFalloffSize = adjustedFalloff;
        
    }

 
}
