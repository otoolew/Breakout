using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Bumper a player controls during gameplay. 
/// </summary>
public class Bumper : MonoBehaviour
{
    // #region Components
    // [SerializeField] private SpriteRenderer spriteRenderer;
    // [SerializeField] private BoxCollider2D boxCollider2D;
    // #endregion

    #region Fields and Properties
    [SerializeField] private Vector2 bumperSize;
    /// <summary>
    /// The Width (x) and the Height (y) of the bumper
    /// </summary>
    public Vector2 BumperSize { get => bumperSize; set => bumperSize = value; }
    /// <summary>
    /// The bumpers movement speed
    /// </summary>
    [SerializeField] private float moveSpeed;
    /// <summary>
    /// The bounds the ball must stay within
    /// </summary>
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    
    [SerializeField] private Bounds bounds;
    /// <summary>
    /// The bounds the bumper must stay within
    /// </summary>
    public Bounds Bounds { get => bounds; set => bounds = value; }
    
    /// <summary>
    /// The Starting Position of the Bumper
    /// </summary>
    public Vector2 StartPosition { get; set; }
    
    private Vector2 moveAxis;
    
    #endregion

    #region Monobehaviour

    private void Start()
    {
        StartPosition = transform.position;
    }

    private void Update()
    {
        moveAxis = new Vector2();
        if (Input.GetKey(KeyCode.A))
        {
            moveAxis += new Vector2(-1, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveAxis += new Vector2(1, 0);
        }
    }

    private void FixedUpdate()
    {
        Move(moveAxis);
    }
    #endregion

    #region Bumper Methods
    /// <summary>
    /// Moves the bumper in a direction at a set speed.
    /// </summary>
    /// <param name="direction">The direction the ball is moving.</param>
    public void Move(Vector2 direction)
    {
        // Moves the bumper by translating the transform position in a direction over a distance 
        // determined by multiplying the seconds from the last frame to the current one by desired moveSpeed
        transform.Translate(direction * (Time.deltaTime * moveSpeed));
        // Clamp the bumper within its play bounds.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bounds.XMin + (bumperSize.x * 0.5f), bounds.XMax - (bumperSize.x * 0.5f)),
            0,0);
    }
    
    /// <summary>
    /// Resets the bumper to the start position.
    /// </summary>
    public void ResetToStartPosition()
    {
        transform.position = StartPosition;
    }
    #endregion
}
