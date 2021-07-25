using System;
using UnityEngine;

[Serializable]
public struct Bounds 
{
    [SerializeField] private float xMin;
    public readonly float XMin => xMin; 
    
    [SerializeField] private float xMax;
    public readonly float XMax => xMax;
    
    [SerializeField] private float yMin;
    public readonly float YMin => yMin;
    
    [SerializeField] private float yMax;
    public readonly float YMax => yMax;
    public Vector3[] BoundingBox 
    {
        get
        {
            return new Vector3[]
            {
                new Vector3(xMin, yMin, 0),
                new Vector3(xMax, yMin, 0),
                new Vector3(xMax, yMax, 0),
                new Vector3(xMin, yMax, 0),
                new Vector3(xMin, yMin, 0)
            };
        }
    }
    
    public Bounds(float xMin, float xMax, float yMin, float yMax)
    {
        this.xMin = xMin;
        this.xMax = xMax;
        this.yMin = yMin;
        this.yMax = yMax;
    }
}
