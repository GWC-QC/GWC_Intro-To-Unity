using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class EnemyScript : MonoBehaviour
 Creates information for the enemy.

 */
[RequireComponent(typeof(FindBounds))]
public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject ourPlayer;
    private FindBounds bounds;
    private bool gameOver;
    
    void Start()
    {
        if(ourPlayer == null)
        {
            ourPlayer = GameObject.Find("Player");
        }
        bounds = GetComponent<FindBounds>();
        bounds.createBounds(gameObject);
    }
    public GameObject getPlayer()
    {
        return ourPlayer;
    }

    public void setGameOver(bool b)
    {
        gameOver = b;
    }
    public bool getGameOver()
    {
        return gameOver;
    }
}
