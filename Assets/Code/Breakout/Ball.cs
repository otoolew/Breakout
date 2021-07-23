using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Range(1,40)] private float maxVelocity;
    public float MaxVelocity { get => maxVelocity; set => maxVelocity = value; }
    
    private Vector2 direction;
    
    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }
    #region Monobehaviour ---------------------------------------------------------------------------------------------
    private void Start()
    {
        direction = Vector2.up;
    }
    
    private void FixedUpdate()
    {
        Move(direction);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        direction = Vector3.Reflect(direction, other.GetContact(0).normal);
        if (other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }
    }
    #endregion --------------------------------------------------------------------------------------------------------
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
        if (currentPosition.x < bounds.XMin)
        {
            normal = Vector2.right;
            return true;
        }
        if (currentPosition.x > bounds.XMax)
        {
            normal = Vector2.left;
            return true;
        }
        if (currentPosition.y < bounds.YMin)
        {
            normal = Vector2.up;
            return true;
        }
        if (currentPosition.y > bounds.YMax)
        {
            normal = Vector2.down;
            return true;
        }
        normal =Vector2.zero; 
        return false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction * 1.0f);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector2(bounds.XMin,bounds.YMin),new Vector2(bounds.XMax,bounds.YMin)); // 0-1
        Gizmos.DrawLine(new Vector2(bounds.XMax,bounds.YMin),new Vector2(bounds.XMax,bounds.YMax)); // 1-2
        Gizmos.DrawLine(new Vector2(bounds.XMax,bounds.YMax),new Vector2(bounds.XMin,bounds.YMax)); // 2-3
        Gizmos.DrawLine(new Vector2(bounds.XMin,bounds.YMax),new Vector2(bounds.XMin,bounds.YMin)); // 3-4
    }
}