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
        

    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * Retrieving our bounds
     */
    public float getBoundY() => boundY;
    public float getBoundX() => boundX;
}
