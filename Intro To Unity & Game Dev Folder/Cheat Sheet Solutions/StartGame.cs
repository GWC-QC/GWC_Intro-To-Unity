using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 C# Script by [Fill out Name], for 'GWC: Intro to Game Dev & Unity Workshop'
 
    Exercises:
    public IEnumerator countdown()
    public IEnumerator initiateWin()
    public IEnumerator initiateGameOver()

 public class StartGame : MonoBehaviour
 This game component essentially tracks all the other scripts.
 It pauses movement, checks the player for a gameOver, and checks for the high score in order to 'win' the game.

 */
[RequireComponent(typeof(AudioSource))]
public class StartGame : MonoBehaviour
{
    [SerializeField] Text TitleText;
    [SerializeField] Text subTitleText;
    [SerializeField] StarProgress starProgress;
    [SerializeField] int highScore = 300;

    private AudioSource music; 
    private bool gameOver; 
    private GameObject player; 
    private GameObject enemy; 

    // ----------------------------------------------------------------------------------------------------
    /*
     * void Start()
     * Begins as soon as the script is initialized by the game. By default its public.
     */
    void Start()
    {
        //Play our audio from the beginning
        music = GetComponent<AudioSource>();
        music.Play(); 
        music.loop = true;

        // If our player & enemy GameObject wasn't named player, this would fail. It gets the reference and stores it as a variable.
        player = GameObject.Find("Player"); 
        enemy = GameObject.Find("Enemy");

        // Pause all movement before starting the countdown
        StartCoroutine(globalMovement(false));

        // Begin count down before the game starts
        StartCoroutine(countdown());
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * void LateUpdate()
     * Occurs after all other Updates have processed in a frame
     * This is better for when other calculations have been processed in Update. In this case, our star score. 
     */
    private void LateUpdate()
    {
        starProgress.setTextScore(starProgress.getStarScore().ToString());
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * void Update()
     * Runs once every frame.
     */
    void Update()
    {
        
        if(starProgress.getStarScore() >= highScore && !gameOver)
        {
            gameOver = true; // Must set to true, or we'll keep returning to this if statement block!
            StartCoroutine(globalMovement(false));
            StartCoroutine(initiateWin());
        }

        if ((enemy.GetComponent<EnemyScript>().getGameOver()) && !gameOver)
        {
            gameOver = true; // Must set to true, or we'll keep returning to this if statement block!
            StartCoroutine(globalMovement(false));
            StartCoroutine(initiateGameOver());
        }

        if(Input.GetKeyDown(KeyCode.Return) && gameOver)
        {
            StartCoroutine(reset());
        }

    }

    // ----------------------------------------------------------------------------------------------------
    /*
     * Exercise 11
     * public IEnumerator countdown()
     * This is the count down before the game begins!
     */
    public IEnumerator countdown()
    {
        /*
        * Exercise 10 : We want to show the instructions for the game, and count down starting at 3 for every second.
        * Tips:
        * subTitleText.text = "?";
        * yield return new WaitForSeconds(?);
        */

        yield return null;
        StartCoroutine(yieldInput());
        
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * Exercise 12
     * public IEnumerator initiateWin()
     * Sets our victory text to the two variables.
     */
    public IEnumerator initiateWin()
    {
        /*
        * Exercise 11 : Similar to the last, but customize the win message! Make sure to enable the components when showing the messages.
        * Tips:
        * subTitleText.text = "string";
        * TitleText.enabled = True/False?;
        */

        // Insert code here

        yield return null;
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * Exercise 12
     * IEnumerator initiateGameOver()
     * Sets our game over text to the two variables.
     */
    public IEnumerator initiateGameOver()
    {
        /*
        * Exercise 12 : Exact copy of the last, but customize the game over message! Make sure to enable the components when showing the messages.
        * subTitleText.text = "string";
        * TitleText.enabled = True/False?;
         */

        // Insert code here

        yield return null;
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void globalMovement(bool tf)
     * RestrictMovement is a script I made, specifically for calculating the X,Y boundaries on a top down 2d space.
     * This will disable the movement allowed within that space, for the player and enemy.
     */
    public IEnumerator globalMovement(bool tf)
    {
        // All components have a '.enabled' method to either turn them off or on! Note that
        yield return new WaitForEndOfFrame();
        player.GetComponent<RestrictMovement>().enabled = tf;
        enemy.GetComponent<RestrictMovement>().enabled = tf;
        enemy.GetComponentInChildren<EnemySightScript>().enabled = tf;
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public IEnumerator reset()
     * This is the count down before the game begins!
     */
    public IEnumerator reset()
    {
        yield return new WaitUntil(() => !Input.anyKey);
        StartCoroutine(enemy.GetComponent<EnemyMovement>().resetLeap());
        // Undo game over
        enemy.GetComponent<EnemyScript>().setGameOver(false);
        gameOver = false;

        // Create new positions
        player.GetComponent<Transform>().position = new Vector3(Random.Range(0, -4.0f), Random.Range(0, -4.0f), 0);
        enemy.GetComponent<Transform>().position = new Vector3(Random.Range(3, 8.0f), Random.Range(3, 6.0f), 0);

        // Reset Animations
        enemy.GetComponent<Animator>().enabled = true;
        player.GetComponent<Animator>().SetBool("gameOver", false);

        // Reset the coordinates of enemy and player to the random variables.
        enemy.GetComponent<EnemyMovement>().Start();
        player.GetComponent<PlayerMovement>().Start();

        // Reset the score
        starProgress.resetScore();
        starProgress.setTextScore("0");
        Start();
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public IEnumerator yieldInput()
     * Helps as a bandaid to a movement bug with the player. Once a solution is found, this will be patched and removed.
     * It basically turns on the movement components after checking that no buttons are being held.
     */
    public IEnumerator yieldInput()
    {
        yield return new WaitUntil(() => !Input.anyKey);
        StartCoroutine(globalMovement(true));
        yield return new WaitForSeconds(1);
        TitleText.enabled = false;
        subTitleText.enabled = false;
        
    }

    // ----------------------------------------------------------------------------------------------------

}
