using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    [SerializeField, Range(1,40)] private float maxVelocity;
    public float MaxVelocity { get => maxVelocity; set => maxVelocity = value; }
    
    private Vector2 direction;
    
    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }

    public UnityAction onBallOutOfBounds;
    
    #region Monobehaviour ---------------------------------------------------------------------------------------------
    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(1); //Skip one frame
        direction = Vector2.up;
    }
    
    private void FixedUpdate()
    {
        Move(direction);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        direction = Vector3.Reflect(direction, other.GetContact(0).normal);
        // if (other.gameObject.CompareTag("Brick"))
        // {
        //     Destroy(other.gameObject,0.01f);
        // }
    }
    #endregion 

    #region Ball Movement ---------------------------------------------------------------------------------------------
    public void Move(Vector2 direction)
    {
        this.direction = direction;
        
        transform.Translate(direction * (Time.deltaTime * maxVelocity));
        
        if (OutOfBounds(out Vector2 normal))
        {
            Vector2 positionCorrection = new Vector2(Mathf.Clamp(transform.position.x, bounds.XMin, bounds.XMax),
                Mathf.Clamp(transform.position.y, bounds.YMin, bounds.YMax));

            transform.position = positionCorrection;
            
            this.direction = Vector2.Reflect(direction, normal.normalized);
            Debug.DrawRay(transform.position, this.direction * 2, Color.yellow, 600);
        }
    }

    private bool OutOfBounds(out Vector2 normal)
    {
        Vector2 currentPosition = transform.position;
        
        if (currentPosition.x > bounds.XMax)
        {
            normal = Vector2.left;
            return true;
        }

        if (currentPosition.x < bounds.XMin)
        {
            normal = Vector2.right;
            return true;
        }


        if (currentPosition.y > bounds.YMax)
        {
            normal = Vector2.down;
            return true;
        }
        
        if (currentPosition.y < bounds.YMin)
        {
            onBallOutOfBounds?.Invoke();
        }
        
        normal = Vector2.zero; 
        return false;
    }
    #endregion

    #region Debugging -------------------------------------------------------------------------------------------------
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction * 1.0f);


    }
    #endregion

}