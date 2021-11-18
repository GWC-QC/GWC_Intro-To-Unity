using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class PlayerMovement : RestrictMovement
 This is for all the event conditions pertaining to the player.

 */
public class PlayerMovement : RestrictMovement
{
    // When will our object be restricted?
    private bool movementAllowed;
    public float speed = 0.05f;
    private float generalClampX;
    private float generalClampY;

    // ----------------------------------------------------------------------------------------------------
    /*
     * public void movePlayer()
     * Updates the necessary coordinates based on the key pressed.
     */
    public void movePlayer()
    {

        // Diagonal movement
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            generalClampY = clamping('y', speed);
            GetComponent<SpriteRenderer>().flipX = true;
            generalClampX = clamping('x', speed);
        }
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            generalClampY = clamping('y', speed);
            GetComponent<SpriteRenderer>().flipX = false;
            generalClampX = clamping('x', -1 * speed);
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            generalClampY = clamping('y', -1 * speed);
            GetComponent<SpriteRenderer>().flipX = true;
            generalClampX = clamping('x', speed);
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            generalClampY = clamping('y', -1 * speed);
            GetComponent<SpriteRenderer>().flipX = false;
            generalClampX = clamping('x', -1 * speed);
        }
        // one button is pressed
        else if (Input.GetKey(KeyCode.W))
        {
            generalClampY = clamping('y', speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            generalClampY = clamping('y', -1 * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            generalClampX = clamping('x', -1 * speed);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            generalClampX = clamping('x', speed);
        }
        else
        {
            generalClampY = getCurrY();
            generalClampX = getCurrX();
        }
        restrictingBehaviour();
    }

    // ----------------------------------------------------------------------------------------------------
    /*
     * public override void restrictingBehaviour()
     * Clamps the player position and updates.
     */
    public override void restrictingBehaviour()
    {
        setCurrentCoords(generalClampX,generalClampY);
        getRestrictor().GetComponent<Transform>().position = new Vector3(generalClampX,generalClampY,getRestrictor().GetComponent<Transform>().position.z);
    }
    // ----------------------------------------------------------------------------------------------------
    /*
     * public void Update()
     * Updates every frame.
     */
    public void Update()
    {

            movePlayer();
        
    }

}
