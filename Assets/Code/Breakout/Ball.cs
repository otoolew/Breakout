using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The Game Ball
/// </summary>
public class Ball : MonoBehaviour
{
    #region Fields and Properties -------------------------------------------------------------------------------------
    /// <summary>
    /// The desired ball velocity
    /// </summary>
    [SerializeField, Range(10,30)] private float moveSpeed;
    
    /// <summary>
    /// The balls movement direction
    /// </summary>
    [SerializeField] private Vector2 direction;
    
    [SerializeField] private Bounds bounds;
    /// <summary>
    /// The bounds the ball must stay within
    /// </summary>
    public Bounds Bounds { get => bounds; set => bounds = value; }
    
    [SerializeField] private Vector2 startPosition;
    /// <summary>
    /// The Starting Position of the Bumper
    /// </summary>
    public Vector2 StartPosition { get => startPosition; set => startPosition = value; }
    #endregion

    #region Delegates -------------------------------------------------------------------------------------------------
    /// <summary>
    /// Unity Action that fires when the ball falls into the bottom bounds aka kill zone.
    /// </summary>
    public UnityAction BallOutOfBounds;
    #endregion
    
    #region Monobehaviour ---------------------------------------------------------------------------------------------

    private void Start()
    {
        ResetToStartPosition();
    }

    private void FixedUpdate()
    {
        Move(direction);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        direction = Vector3.Reflect(direction, other.GetContact(0).normal);
    }
    
    #endregion 

    #region Ball Movement ---------------------------------------------------------------------------------------------
    /// <summary>
    /// Moves the ball in a direction at a set speed.
    /// </summary>
    /// <param name="direction">The direction the ball is moving.</param>
    public void Move(Vector2 direction)
    {
        this.direction = direction;
        // Moves the ball by translating the transform position in a direction over a distance 
        // determined by multiplying the seconds from the last frame to the current one by desired moveSpeed
        transform.Translate(direction * (Time.deltaTime * moveSpeed)); 
        
        if (OutOfBounds(out Vector2 normal))
        {
            // Compensates for over shooting the bounds by placing the ball at the intended point of contact.  
            Vector2 positionCorrection = new Vector2(Mathf.Clamp(transform.position.x, bounds.XMin, bounds.XMax),
                Mathf.Clamp(transform.position.y, bounds.YMin, bounds.YMax));

            transform.position = positionCorrection; // Move the ball to the corrected position.
            
            this.direction = Vector2.Reflect(direction, normal.normalized); // Bounce off the bounds normal. 
        }
    }
    /// <summary>
    /// Checks if the Game Ball is out of bounds.
    /// </summary>
    /// <param name="normal">The Vector2 normal use to calculate the ball bounce.</param>
    /// <returns>True if ball is out of bounds</returns>
    private bool OutOfBounds(out Vector2 normal)
    {
        Vector2 currentPosition = transform.position;
        
        if (currentPosition.x > bounds.XMax) // Out of Right bound
        {
            normal = Vector2.left;
            return true;
        }

        if (currentPosition.x < bounds.XMin) // Out of Left bound
        {
            normal = Vector2.right;
            return true;
        }
        
        if (currentPosition.y > bounds.YMax) // Out of Top bound
        {
            normal = Vector2.down;
            return true;
        }
        
        if (currentPosition.y < bounds.YMin)// Out of Bottom bound. 
        {
            direction = Vector3.zero; // Stops ball
            ResetToStartPosition();
            BallOutOfBounds?.Invoke();
        }
        
        normal = Vector2.zero; // Set the out to zero
        return false;
    }
    
    /// <summary>
    /// Resets the bumper to the start position.
    /// </summary>
    public void ResetToStartPosition()
    {
        transform.position = startPosition;
    }
    /// <summary>
    /// Resets the bumper to the start position.
    /// </summary>
    public void ResetDirection()
    {
        direction = Vector2.zero;
    }
    #endregion
}