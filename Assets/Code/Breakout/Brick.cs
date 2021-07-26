using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    [SerializeField] private int hitPoints;
    public int HitPoints { get => hitPoints; set => hitPoints = value; }
    
    [SerializeField] private int pointValue;
    public int PointValue { get => pointValue; set => pointValue = value; }

    public UnityAction<int> BrickWasHit;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball hit me!");
        }
    }
    private void OnDestroy()
    {
        BrickWasHit?.Invoke(pointValue);
        BrickWasHit = null;
    }
}
