using System;
using UnityEngine;

[Serializable]
public struct Bounds 
{
    [SerializeField] private float xMin;
    public float XMin => xMin; 
    
    [SerializeField] private float xMax;
    public float XMax => xMax;
    
    [SerializeField] private float yMin;
    public float YMin => yMin;
    
    [SerializeField] private float yMax;
    public float YMax => yMax;
    
    public Bounds(float xMin, float xMax, float yMin, float yMax)
    {
        this.xMin = xMin;
        this.xMax = xMax;
        this.yMin = yMin;
        this.yMax = yMax;
    }
}
