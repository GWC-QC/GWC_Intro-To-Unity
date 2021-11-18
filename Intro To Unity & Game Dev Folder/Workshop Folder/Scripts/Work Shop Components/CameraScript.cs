using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class CameraScript : MonoBehaviour
 This is a behavourial component for GameObjects in Unity, specifically our Camera. This is used to obtain
 information about the Camera that is used by other classes to move and track our player.

 */
[RequireComponent(typeof(FindBounds))]
public class CameraScript : MonoBehaviour
{
    // Movement for our camera.
    [SerializeField] GameObject ourPlayer; //Our single player that the camera follows

    private FindBounds bounds; //Camera bounds starting from its center. See how it's calculated in the Findbounds class.

    // This method begins after awaking.
    void Start()
    {
        bounds = GetComponent<FindBounds>();
        bounds.createBounds(gameObject);
    }

    // A getter method for obtaining the player. 
    public GameObject getPlayer()
    {
        return ourPlayer;
    }
}
