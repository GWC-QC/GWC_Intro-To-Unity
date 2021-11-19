using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
C# Script by [Fill out Name], for 'GWC: Intro to Game Dev & Unity Workshop'
 
    Exercises:
    private void setBounds(GameObject ourGameObject)

 public class FindBounds : MonoBehaviour
 Creates the left and right bounds for sprites & the camera.
 
 */
public class FindBounds : MonoBehaviour
{
    private GameObject ourGameObject;
    private float boundY;
    private float boundX;

    // ----------------------------------------------------------------------------------------------------
    /*
     * public void createBounds(GameObject ourGameObject)
     * Given our game object, we'll set the game object and begin checking for bounds.
     */
    public void createBounds(GameObject ourGameObject)
    {
        this.ourGameObject = ourGameObject;
        setBounds(this.ourGameObject);
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * Exercise 1
     * private void setBounds(GameObject ourGameObject)
     * We will only set the bounds for SpriteRenderer or Camera.
     */
    private void setBounds(GameObject ourGameObject)
    {
        /*
         * Exercise 1 : How do we find the boundaries of a sprite renderer and a camera?
         */
        if (ourGameObject.GetComponent<SpriteRenderer>() != null)
        {
            // Starting at the coordinates, boundX will take half of the image size starting from the center.
            // This occurs for both of them.
            boundX = ourGameObject.GetComponent<SpriteRenderer>().bounds.extents.x;
            boundY = ourGameObject.GetComponent<SpriteRenderer>().bounds.extents.y;

        }
        else if (ourGameObject.GetComponent<Camera>() != null)
        {
            // Half of the height of our camera from its center point.
            boundY = (ourGameObject.GetComponent<Camera>().orthographicSize);
            //Half of the width of our camera from its center point.
            boundX = (ourGameObject.GetComponent<Camera>().aspect * (ourGameObject.GetComponent<Camera>().orthographicSize));

        }
        else
        {
            boundX = boundY = 0;
        }

    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * Retrieving our bounds
     */
    public float getBoundY() => boundY;
    public float getBoundX() => boundX;
}
