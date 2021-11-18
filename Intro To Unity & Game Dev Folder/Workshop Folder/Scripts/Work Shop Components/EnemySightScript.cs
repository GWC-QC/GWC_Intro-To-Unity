using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 C# Script by Amber Garcia, for 'GWC: Intro to Game Dev & Unity Workshop'
 
 public class EnemySightScript : MonoBehaviour
 Detects the player given a precise radius.

 */
public class EnemySightScript : MonoBehaviour
{
    [SerializeField] GameObject searching;
    private bool waiting;

    void Update()
    {
        if (GetComponent<CircleCollider2D>().radius < 8 && !gameObject.GetComponentInParent<EnemyMovement>().getLeaping())
        {
            StartCoroutine(wait());
            if (!waiting)
            {
                GetComponent<CircleCollider2D>().radius += 0.075f;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player" && !gameObject.GetComponentInParent<EnemyMovement>().getLeaping() && !waiting)
        {
            waiting = true;
            GetComponent<Collider2D>().isTrigger = false;
            GetComponent<CircleCollider2D>().radius = 0;
            gameObject.GetComponentInParent<EnemyMovement>().setOldCoords(searching.GetComponent<Transform>());
            gameObject.GetComponentInParent<EnemyMovement>().beginLeap();
        }
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(0.3f);
        waiting = false;
        GetComponent<Collider2D>().isTrigger = true;
    }

}
