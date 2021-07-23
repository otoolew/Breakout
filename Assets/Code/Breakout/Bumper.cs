using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    
    public Vector2 moveAxis;
    
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
        Move(moveAxis);
    }
    
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * (Time.deltaTime * moveSpeed));
    }
}
