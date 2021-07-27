using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    #region Components
    [HideInInspector] private SpriteRenderer spriteRenderer;
    public SpriteRenderer SpriteRenderer { get => spriteRenderer; set => spriteRenderer = value; }
    
    [HideInInspector] private BoxCollider2D boxCollider2D;
    public BoxCollider2D BoxCollider2D { get => boxCollider2D; set => boxCollider2D = value; }
    #endregion

    #region Fields and Properties
    [SerializeField] private Vector2 bumperSize;
    public Vector2 BumperSize { get => bumperSize; set => bumperSize = value; }
    
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    
    [SerializeField] private Bounds bounds;
    public Bounds Bounds { get => bounds; set => bounds = value; }
    
    private Vector2 moveAxis;
    #endregion

    #region Monobehaviour
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
        Move(moveAxis);;
    }
    #endregion

    #region Bumper Methods
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * (Time.deltaTime * moveSpeed));
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bounds.XMin + (bumperSize.x * 0.5f), bounds.XMax - (bumperSize.x * 0.5f)),
            0,0);
    }
    #endregion
    
    #region Debugging -------------------------------------------------------------------------------------------------
    private void OnValidate()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            
        }

        if (boxCollider2D == null)
        {
            boxCollider2D = GetComponent<BoxCollider2D>();
        }

        spriteRenderer.size = bumperSize;
        boxCollider2D.size = bumperSize;
    }
    #endregion
}
