using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class SpriteScript : MonoBehaviour
 This game component just gets the bounds of the gameObject. You could easily give this component to other SpriteRenderers or Cameras. 
 
 */
[RequireComponent(typeof(FindBounds))]
public class SpriteScript : MonoBehaviour
{
    private FindBounds bounds;
    void Start()
    {
        bounds = GetComponent<FindBounds>();
        bounds.createBounds(gameObject);
    }

}
