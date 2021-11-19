using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 C# Script by [Fill out Name], for 'GWC: Intro to Game Dev & Unity Workshop'
 
    Complete the component:
    public void addScore()
    public void checkMultiplier()
    private Vector2 resetLastCoordinates()

 public class StarProgress : MonoBehaviour
 This game component just gets the bounds of the gameObject. You could easily give this component to other SpriteRenderers or Cameras. 
 
 */
[RequireComponent(typeof(AudioSource))]
public class StarProgress : MonoBehaviour
{
    [SerializeField] Text score;
    [SerializeField] int increment;
    [SerializeField] int scoreMultiplier = 10;

    [SerializeField] AudioClip chime;
    [SerializeField] AudioClip multiplier;

    private int starScore;
    private float lastY;
    private float lastX;

    // ----------------------------------------------------------------------------------------------------
    /*
     * void Start()
     * Randomizes our last x,y coordinates and initializes score with 0.
     */
    private void Start()
    {
        /*
         * Exercise 1: Solution
         */
        if(increment == 0)
        {
            // Default increment
            increment = 10;
        }
        starScore = 0;
        lastY = Random.Range(-7.0f, 7.0f);
        lastX = Random.Range(-9.0f, 9.0f);
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void addScore()
     * Adds the incrememnt to the score.
     */
    public void addScore()
    {
         /*
         * Exercise 3: We want to add the increment to the score every time this function is called.
         * We also want to check the multiplier.
         */
        starScore += increment;
        checkMultiplier();
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void checkMultiplier()
     * Checks our multiplier for a unique sound effect, or plays the default upon increasing the score.
     */
    public void checkMultiplier()
    {
        /*
        * Exercise 4: We want to compare the Star Score to the increment times the score multiplier.
        * If true, Increment the score multiplier by itself, and play the multiplier audio clip.
        * if its false, play the chime clip.
        */
        if (starScore == increment * scoreMultiplier)
        {
            scoreMultiplier += scoreMultiplier;
            GetComponent<AudioSource>().clip = multiplier;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().clip = chime;
            GetComponent<AudioSource>().Play();
        }
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * private Vector2 resetLastCoordinates()
     * Randomize our X,Y coordinates again and return them.
     */
    private Vector2 resetLastCoordinates()
    {
        /*
        * Exercise 5: We need coordinates in the form of Vector2. As in, new Vector2(x,y) as a new object.
        * We want to obtain a random number for both the x and y coordinates, as long as they are within the bounds of our
        * background.
        */
        Vector2 coordinates = new Vector2(lastX, lastY);
        lastY = Random.Range(-6.0f, 6.0f);
        lastX = Random.Range(-8.0f, 8.0f);

        return coordinates;
    }
    // ----------------------------------------------------------------------------------------------------
    /*
    * Getters & Setters for score
    */
    public void resetScore()
    {
        starScore = 0;
    }
    public Vector2 getLastCoords()
    {
        return resetLastCoordinates();
    }
    public int getStarScore()
    {
        return starScore;
    }
    public void setTextScore(string s)
    {
        score.text = s;
    }

    // ----------------------------------------------------------------------------------------------------
}
