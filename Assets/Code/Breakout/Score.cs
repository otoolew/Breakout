using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Breakout/Score", fileName = "newScore")]
public class Score : ScriptableObject
{
    [SerializeField] private int value;
    public int Value { get => value; set => this.value = value; }
}
