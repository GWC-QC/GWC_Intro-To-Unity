using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public abstract class RestrictMovement : MonoBehaviour
{
    // -------------------------------------------------------------------------------------------------------------
    // Restrict movement will be for anything that will move in the scene for a 2D game.
    // This includes the camera, player, and enemy.
    // It will use clamping to stop anything from moving outside of the bounds we set for each item.
    // ------------------------------------------------------------------------------------------------------------
    [SerializeField] GameObject restrictor;
    [SerializeField] GameObject limiter;
    private FindBounds limits;
    private Transform center;
    private float currX;
    private float currY;

    private float minX, minY, maxX, maxY;

    public void Start()
    {
        createDetection(restrictor, limiter);
    }
    // Z will remain the same value throughout the rest of this game.

    /* createDetection
     * This GameObject will be taken, and we'll detect if it has FindBounds or not. 
     * If not, we'll add the component and instantiate it for the object.
     */
    public void createDetection(GameObject restrictor, GameObject limits)
    {
        
        this.restrictor = restrictor;
        if(limits.GetComponent<FindBounds>() == null)
        {
            limits.AddComponent<FindBounds>();

        }
        
        limits.GetComponent<FindBounds>().createBounds(limits);
        this.limits = limiter.GetComponent<FindBounds>();
        assignCurrentValues(restrictor, limits);
    }

    private void assignCurrentValues(GameObject restrictor, GameObject limits)
    {

        center = limits.GetComponent<Transform>(); // Mainly we're trying to get the xyz for the middle of our restricting object.
        currX = restrictor.GetComponent<Transform>().position.x;
        currY = restrictor.GetComponent<Transform>().position.y;
        minX = center.position.x - this.limits.getBoundX();
        minY = center.position.y - this.limits.getBoundY();
        maxX = center.position.x + this.limits.getBoundX();
        maxY = center.position.y + this.limits.getBoundY();
    }
    public float clamping(char coord, float speed)
    {
        float clamped;
        if (char.ToLower(coord).Equals('y'))
        {
  
            clamped = Mathf.Clamp(currY + speed,
                               minY + restrictor.GetComponent<FindBounds>().getBoundY(),
                                 maxY - restrictor.GetComponent<FindBounds>().getBoundY());

        }
        else if (char.ToLower(coord).Equals('x'))
        {
            clamped = Mathf.Clamp(currX + speed,
                               minX + restrictor.GetComponent<FindBounds>().getBoundX(),
                                 maxX - restrictor.GetComponent<FindBounds>().getBoundX());

        }
        else
        {
            clamped = 0;
        }
        return clamped;
    }
    // When/how will our object be restricted?
    public abstract void restrictingBehaviour();

    // -------------------------------------------------------------------------------------------------------------
    /*
     * Getters and Setters for children classes
     */
    // -------------------------------------------------------------------------------------------------------------

    // [SerializeField] GameObject restrictor;
    public GameObject getRestrictor()
    {
        return restrictor;
    }
    public void setRestrictor(GameObject restrictor)
    {
        this.restrictor = restrictor;
    }
    //private FindBounds limits;
    public FindBounds getLimits()
    {
        return limits;
    }
    private void setLimits(FindBounds limits)
    {
        this.limits = limits;
    }
    //private Transform center;
    public Transform getCenter()
    {
        return center;
    }
    public void setCenter(Transform center)
    {
        this.center = center;
    }
    public void setCurrentCoords(float x, float y)
    {
        currX = x;
        currY = y;
    }
    //private float currX;
    public float getCurrX()
    {
        return currX;
    }
    //private float currY;
    public float getCurrY()
    {
        return currY;
    }

    //private float minX, minY, maxX, minY;
    public float getMinX()
    {
        return minX;
    }
    public float getMinY()
    {
        return minY;
    }
    public float getMaxX()
    {
        return maxX;
    }
    public float getMaxY()
    {
        return maxY;
    }
}
