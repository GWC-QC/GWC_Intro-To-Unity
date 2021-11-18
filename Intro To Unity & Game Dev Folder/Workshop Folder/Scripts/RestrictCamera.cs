using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 C# Script by [Fill out Name], for 'GWC: Intro to Game Dev & Unity Workshop'
 
    Exercises:
    public override void restrictingBehaviour()

 public class RestrictCamera : RestrictMovement
 This is a behavourial component for GameObjects in Unity, specifically our Camera. This uses information from
 CameraScript to make our camera follow the player object, via clamping. 

 */
[RequireComponent(typeof(CameraScript))]

public class RestrictCamera : RestrictMovement
{
    // ----------------------------------------------------------------------------------------------------
    /*
     * public override void restrictingBehaviour()
     * Clamps the camera in place using the bounds
     */
    public override void restrictingBehaviour()
    {
        /*
         * Exercise 2 : We want our camera to follow the player, at least until the outer edges of the camera reach the limit. 
         * Replace null or 0f with your solutions
         */
        GameObject camera = gameObject;
        GameObject player = camera.GetComponent<CameraScript>().getPlayer();

        // Task a: Given the above, how do we get the position of the player? (Hint: [?].position.x returns the float of x from the Transform component.)

        float xp = 0f;
        float yp = 0f;

        setCurrentCoords(xp, yp);

        // Task b: Now we need to find the bounds for the camera. We need to ensure that the camera's viewpoint doesn't go past the edge of the background.
        /*
         Hint:
          We use FindBounds Component and getter functions in it.
          camera.[?].[?]
         */

        float camX = 0f;
        float camY = 0f;

        // Task c: Given the following minimum and maximum bounds:
        float minX = getMinX() + camX;
        float maxX = getMaxX() - camX;
        float minY = getMinY() + camY;
        float maxY = getMaxY() - camY;

        // Calculate the final position of our camera.
        // (Hint:  Mathf.Clamp(getCurrX(), minX, maxX) )

        Vector3 newPos = new Vector3(0f, 0f, camera.GetComponent<Transform>().position.z);

        camera.GetComponent<Transform>().position = newPos;

    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void LateUpdate()
     * Updates the camera after the player coordinates have been processed
     */
    public void LateUpdate()
    {
        restrictingBehaviour();
    }
    // ----------------------------------------------------------------------------------------------------

}