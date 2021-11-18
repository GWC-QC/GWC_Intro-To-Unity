using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class PlayerScript : MonoBehaviour
 This behaviourial component stores data for the player, such as its bounds and our player

 */
[RequireComponent(typeof(FindBounds))]
public class PlayerScript : MonoBehaviour
{
    private FindBounds bounds;
    void Start()
    {
        bounds = GetComponent<FindBounds>();
        bounds.createBounds(gameObject);
    }

    public GameObject getOurPlayer()
    {
        return gameObject;
    }
}
