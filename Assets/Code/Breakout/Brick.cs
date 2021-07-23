using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    [SerializeField] private int pointValue;
    public int PointValue { get => pointValue; set => pointValue = value; }
}
