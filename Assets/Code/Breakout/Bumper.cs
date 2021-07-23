using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * (Time.deltaTime * moveSpeed));
    }
}
