using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by [Fill out Name], for 'GWC: Intro to Game Dev & Unity Workshop'
 
    Complete the component:
    public void moveStar()

 public class Star : MonoBehaviour
 Updates the position of a star after we update the score, for our prefab.
 
 */
public class Star : MonoBehaviour
{
    private StarProgress starProgress;

    // ----------------------------------------------------------------------------------------------------
    /*
     * void Start()
     * Instantiates StarProgress variable.
     */
    private void Start()
    {
        /*
         * Exercise 6 : Solution
         */
        starProgress = gameObject.GetComponentInParent(typeof(StarProgress)) as StarProgress;
        moveStar();
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void moveStar()
     * Instantiates StarProgress variable.
     */
    public void moveStar()
    {
        /*
         * Exercise 7 : We need to use the function we made in exercise 6 to create a new Vector2. Once done, use it to make the new position.
         * HINT, similar to accessing the x and y of a Vector3.
         * recall, gameObject accesses the Game Object that is using our component.
         */
        Vector2 newXY = starProgress.getLastCoords();
        gameObject.GetComponent<Transform>().position = new Vector3(newXY.x, newXY.y, gameObject.GetComponent<Transform>().position.y);
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void addScoreFromStar()
     * Add to the score and move the star.
     */
    public void addScoreFromStar()
    {
        /*
         * Exercise 8 : How do we add the score from star? When we add, we also want to change our position.
         * HINT, We use moveStar(); here.
         */
        starProgress.addScore();
        moveStar();
    }

    

}
