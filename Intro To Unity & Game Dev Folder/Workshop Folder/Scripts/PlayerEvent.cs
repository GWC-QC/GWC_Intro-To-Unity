using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by [Fill out Name], for 'GWC: Intro to Game Dev & Unity Workshop'
 
    Complete the component:
    OnTriggerEnter2D(Collider2D collider)

 public class PlayerEvent : MonoBehaviour
 This is for all the event conditions pertaining to the player.

 */
[RequireComponent(typeof(Animator))]
public class PlayerEvent : MonoBehaviour
{
    // ----------------------------------------------------------------------------------------------------
    /*
     * private void OnTriggerEnter2D(Collider2D collider)
     * For detecting adding the score for the star and our game over when the player collides with the enemy.
     */
    private void OnTriggerEnter2D(Collider2D collider)
    {

        /*
        * Exercise 9 : What are the conditions of the Star collision that we want to have? 
        * What should happen and how do we check that we're colliding with star?
        * 
        * HINT: [?].gameObject.tag returns a string you can compare to another string.
        *       collider.gameObject.GetComponent<[?]>().[?]();
        */
        // code here

        /*
         * Optional : What about colliding with the enemy?
         */
    }
    // ----------------------------------------------------------------------------------------------------
}
