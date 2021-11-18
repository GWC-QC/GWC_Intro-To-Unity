using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class EnemyMovement : RestrictMovement
 Creates movement and random decisions for the enemy.

 */
[RequireComponent(typeof(EnemyScript))]
public class EnemyMovement : RestrictMovement
{
    [SerializeField] float speed;
    [SerializeField] float leapSpeed;
    private Vector3 oldPlayerCoords;
    private char[] directions = { 'N', '<', 'S', '>', 'E','^', 'W', 'v' }; // North, South, East, West
                                   // Let < = NorthWest
                                   // Let v = SouthWest
                                   // Let ^ = NorthEast
                                   // Let > = SouthEast
    private int size;

    private char direction;
    private float timeToChangeDir;
    //------------
    private float ourX;
    private float ourY;
    //------------
    private float leapX;
    private float leapY;
    private bool xMatch;
    private bool yMatch;
    private bool leaping;
    private bool patrolling;
    private bool waitingToChangeDir;

    new void Start()
    {
        leapX = leapY = leapSpeed;
        base.Start();
        int i = Random.Range(0, size);
        direction = directions[i];
        directions[i] = '$';
        //------------
        size = directions.Length;
        timeToChangeDir = Random.Range(1f, 3f);
        //------------
        leaping = false;
        patrolling = true;
        waitingToChangeDir = false;
    }

    void Update()
    {
        StartCoroutine(patrol());
    }
    public override void restrictingBehaviour()
    {
        //Debug.Log("VIBRATING");
        setCurrentCoords(ourX, ourY);
        getRestrictor().GetComponent<Transform>().position = new Vector3(ourX, ourY, getRestrictor().GetComponent<Transform>().position.z);
    }

    public IEnumerator patrol()
    {
        if (patrolling)
        {
            StartCoroutine(changeDirection());
            calculateSpeed(direction);
        }
        else if(leaping)
        {
            StartCoroutine(leap());
        }
        yield return null;
    }
    public IEnumerator leap()
    {
        // x
        if(leapX > 0  && getRestrictor().GetComponent<Transform>().position.x < oldPlayerCoords.x)
        {
            ourX = clamping('x', leapX);
        }
        else if (leapX < 0 && getRestrictor().GetComponent<Transform>().position.x >= oldPlayerCoords.x)
        {
            ourX = clamping('x', leapX);
        }else
        {
            xMatch = true;
        }
        // y 
        if (leapY > 0 && getRestrictor().GetComponent<Transform>().position.y < oldPlayerCoords.y)
        {
            ourY = clamping('y', leapY);
        }
        else if (leapY < 0 && getRestrictor().GetComponent<Transform>().position.y >= oldPlayerCoords.y)
        {
            ourY = clamping('y', leapY);
        }
        else
        {
            yMatch = true;
        }
        StartCoroutine(endLeap());
        restrictingBehaviour();
        
        yield return null;
    }
 
    public void calculateSpeed(char dir)
    {
        if(dir == '^' || dir == 'E' || dir == '>')
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        switch (dir)
        {
            case 'N':
                ourY = clamping('y', speed);
                break;
            case 'W':
                ourX = clamping('x', -speed);
                break;
            case 'S':
                ourY = clamping('y', -speed);
                break;
            case 'E':
                ourX = clamping('x', speed);
                break;
            case '<': //NorthWEst
                ourY = clamping('y', speed);
                ourX = clamping('x', -speed);
                break;
            case '^': //NorthEast
                ourY = clamping('y', speed);
                ourX = clamping('x', speed);
                break;
            case 'v': //SouthWest
                ourY = clamping('y', -speed);
                ourX = clamping('x', -speed);
                break;
            case '>': //SouthEast
                ourY = clamping('y', -speed);
                ourX = clamping('x', speed);
                break;
            default:
                break;
        }
        restrictingBehaviour();
    }
    public IEnumerator changeDirection()
    {
        if (waitingToChangeDir)
        {
            yield return null;
        }
        else
        {
            waitingToChangeDir = true;
            yield return new WaitForSeconds(timeToChangeDir);
            timeToChangeDir = Random.Range(1f, 3f);
            char old = direction;
            while (direction.Equals(old))
            {
                
                int i = Random.Range(0, size);

                if (!directions[i].Equals('$'))
                {
                    direction = directions[i];

                    for (int k = 0; k < size; k++)
                    {
                        if (directions[k].Equals('$'))
                        {
                            directions[k] = old;
                            break;
                        }
                    }
                }
            }
            yield return new WaitForEndOfFrame();
            waitingToChangeDir = false;
        }
    }

    public void beginLeap()
    {
        leaping = true;
        patrolling = false;
        GetComponent<Animator>().SetBool("leap", true);
        if (oldPlayerCoords.x < getRestrictor().GetComponent<Transform>().position.x)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            leapX = -leapSpeed;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (oldPlayerCoords.y < getRestrictor().GetComponent<Transform>().position.y)
        {
            leapY = -leapSpeed;
        }

        
    }
    public IEnumerator endLeap()
    {
        if (xMatch && yMatch)
        {
            yield return StartCoroutine(resetLeap());
        }
    }
    public IEnumerator resetLeap()
    {
        GetComponent<Animator>().SetBool("leap", false);
        leapY = leapSpeed;
        leapX = leapSpeed;
        xMatch = false;
        yMatch = false;
        yield return new WaitForSeconds(1);
        leaping = false;
        patrolling = true;
    }
    public void setOldCoords(Transform p)
    {
        oldPlayerCoords = new Vector3(p.position.x, p.position.y, p.position.z);
        
    }

    public bool getLeaping()
    {
        return leaping;
    }

}
