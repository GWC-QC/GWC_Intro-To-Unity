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
         */

        // code here

        /*
         * Exercise 13 : What are the conditions of the Enemy collision that we want to have? 
         * What should happen and how do we check that we're colliding with star?
         */
        if (collider.gameObject.tag == "Star")
        {
            collider.gameObject.GetComponent<Star>().addScoreFromStar();
        }

        else if (collider.gameObject.tag == "Enemy")
        {
            collider.gameObject.GetComponent<EnemyScript>().setGameOver(true);
            collider.gameObject.GetComponent<Animator>().enabled = false;
            GetComponent<Animator>().SetBool("gameOver", true);

        }

    }
    // ----------------------------------------------------------------------------------------------------
}
