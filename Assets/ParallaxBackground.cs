using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public Transform player;
    public float[] parallaxSpeeds; // Adjust the array size and values to control the parallax effect for each layer.

    private Transform[] background;

    void Start()
    {
        // Collect all child transforms (background layers).
        int numLayers = transform.childCount;
        background = new Transform[numLayers];

        for (int i = 0; i < numLayers; i++)
        {
            background[i] = transform.GetChild(i);
        }
    }

    void Update()
    {
        // Calculate the parallax offset based on the player's movement.
        float parallaxOffset = player.position.x;

        // Update the positions of the background layers.
        for (int i = 0; i < background.Length; i++)
        {
            Vector3 layerPosition = background[i].position;
            layerPosition.x = parallaxOffset * parallaxSpeeds[i];
            background[i].position = layerPosition;
        }
    }
}
