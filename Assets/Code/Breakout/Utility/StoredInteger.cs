using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Breakout/Stored Variables/Integer", fileName = "newStoredValueInt")]
public class StoredInteger : ScriptableObject
{
    [SerializeField] private int value;
    public int Value { get => value; set => value = value; }
    
    public UnityAction<int> ValueChanged;
    public void ChangeValue(int value)
    {
        this.value = value;
        ValueChanged?.Invoke(value);
    }

    private void OnDisable()
    {
        ValueChanged = null;
    }
}
